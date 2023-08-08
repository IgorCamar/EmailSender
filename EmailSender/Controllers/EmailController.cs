using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using EmailSender.Models;

namespace EmailSender.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(EmailModel model)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Your Name", model.ToEmail));
            message.To.Add(new MailboxAddress("", model.ToEmail));
            message.Subject = "Test Email";
            message.Body = new TextPart("plain")
            {
                Text = "Email enviado com sucesso"
            };

            using (var client = new SmtpClient())
            {
                client.Connect(model.SmtpServer, model.SmtpPort, false);
                client.Authenticate(model.ToEmail, model.Password);
                client.Send(message);
                client.Disconnect(true);
            }

            return RedirectToAction("Index.cshtml");
        }
    }
}
