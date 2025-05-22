
using System.Net.Http;
using System.Text;
using System.Text.Json;
namespace E25ProjetEtendu.Services;
public class SmsService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;
    private readonly string _apiKey;

    public SmsService()
    {
        _httpClient = new HttpClient();
        _baseUrl = "https://textbelt.com/text"; // ou URL d’un autre service SMS
        _apiKey = "textbelt"; // Clé test gratuite (1 SMS/jour). Remplace par ta vraie clé pour production.
    }

    public async Task<bool> EnvoyerLienConfirmationAuLivreur(string phoneNumber, int orderId)
    {
        var confirmationUrl = $"https://localhost:7135/Delivery/TerminerCommandeParLien?orderId={orderId}";
        var message = $"Votre commande a été livrée. Cliquez ici pour la confirmer : {confirmationUrl}";

        var payload = new Dictionary<string, string>
        {
            { "phone", phoneNumber },
            { "message", message },
            { "key", _apiKey }
        };

        var content = new FormUrlEncodedContent(payload);

        var response = await _httpClient.PostAsync(_baseUrl, content);
        var responseString = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<TextbeltResponse>(responseString);
        return result?.Success ?? false;
    }

    private class TextbeltResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
