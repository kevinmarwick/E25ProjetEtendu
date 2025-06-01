using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using E25ProjetEtendu.Models;
using E25ProjetEtendu.Services.IServices;

public class SmsService
{
    private readonly HttpClient _httpClient;
   

    private readonly IOrderService _orderService;

    public SmsService(IOrderService orderService)
    {
        //TwilioClient.Init(_accountSid, _authToken);
        _orderService = orderService;
    }

    public async Task<bool> EnvoyerLienConfirmationAuLivreur(string phoneNumber, int orderId)
    {
        Order? order = await _orderService.GetOrderById(orderId);

        try
        {
            var confirmationUrl = $"https://localhost:7135/Order/EndOrder?orderId={orderId}";
            var messageText = $"La commande {orderId} pour {order.Buyer.FullName} vous a bien été assignée. Cliquez ici pour la conclure ou pour l'annuler : {confirmationUrl}";

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
