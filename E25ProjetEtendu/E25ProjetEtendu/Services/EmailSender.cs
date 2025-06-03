using E25ProjetEtendu.Configuration;
using E25ProjetEtendu.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace E25ProjetEtendu.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly SmtpSettings _smtp;

        public EmailSender(IOptions<SmtpSettings> smtpOptions)
        {
            _smtp = smtpOptions.Value;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SmtpClient(_smtp.Host, _smtp.Port)
            {
                EnableSsl = _smtp.EnableSsl,
                Credentials = new NetworkCredential(_smtp.UserName, _smtp.Password),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false
            };

            var mailMessage = new MailMessage(_smtp.UserName, email, subject, message)
            {
                IsBodyHtml = true
            };

            return client.SendMailAsync(mailMessage);
        }


        public async Task SendEmailAsync(string toEmail, string subject, string messageBody, Order order)
        {
            var fullMessage = messageBody + BuildOrderSummaryHtml(order);

            await SendEmailAsync(toEmail, subject, fullMessage);
        }

        private string BuildOrderSummaryHtml(Order order)
        {
            if (order.OrderItems == null || !order.OrderItems.Any())
                return "<br/><br/><strong>Détails de la commande :</strong><br/><em>Aucun produit dans cette commande.</em>";

            var sb = new StringBuilder();
            sb.Append("<br/><br/><strong>Détails de la commande :</strong>");
            sb.Append("<ul>");
            foreach (var item in order.OrderItems)
            {
                sb.Append($"<li>{item.Quantity} × {item.Product.Nom}</li>");
            }
            sb.Append("</ul>");
            sb.Append($"<strong>Total :</strong> {order.TotalPrice.ToString("C", CultureInfo.GetCultureInfo("fr-CA"))}");

            return sb.ToString();
        }


    }
}
