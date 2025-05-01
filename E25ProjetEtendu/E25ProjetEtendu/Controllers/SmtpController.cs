using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace E25ProjetEtendu.Controllers
{
    public class SmtpController : Controller
    {
        private readonly IEmailSender _emailSender;

        public SmtpController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public async Task<IActionResult> Index()
        {


            var to = "kevin.marwick@hotmail.com"; // change this to your real test recipient
            var subject = "Test d'envoi SMTP";
            var message = "<h2> Email envoyé depuis l'application ASP.NET Core !</h2>";

            try
            {
                await _emailSender.SendEmailAsync(to, subject, message);
                return Content(" Email envoyé avec succès à : " + to);
            }
            catch (Exception ex)
            {
                return Content(" Échec de l'envoi : " + ex.Message);
            }
        }
    }
}
