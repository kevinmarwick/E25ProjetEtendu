using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

public class SmsService
{
    private readonly HttpClient _httpClient;
   

    public SmsService()
    {
        //TwilioClient.Init(_accountSid, _authToken);
    }

    public async Task<bool> EnvoyerLienConfirmationAuLivreur(string phoneNumber, int orderId)
    {
        try
        {
            var confirmationUrl = $"https://localhost:7135/Order/EndOrder?orderId={orderId}";
            var messageText = $"Votre commande a été livrée. Cliquez ici pour la confirmer : {confirmationUrl}";

            var message = await MessageResource.CreateAsync(
                to: new PhoneNumber(phoneNumber),
               // from: new PhoneNumber(_twilioNumber),
                body: messageText
            );

            Console.WriteLine($"SMS envoyé. SID : {message.Sid}");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($" Erreur d'envoi SMS : {ex.Message}");
            return false;
        }
    }
}
