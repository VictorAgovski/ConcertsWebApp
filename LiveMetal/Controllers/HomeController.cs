using LiveMetal.Core.Contracts;
using LiveMetal.Core.Models.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

namespace LiveMetal.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INewsService _newsService;

        public HomeController(ILogger<HomeController> logger, INewsService newsService)
        {
            _logger = logger;
            _newsService = newsService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var topThreeNews = await _newsService.GetTopThreeNewsAsync();
            return View(topThreeNews);
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400)
            {
                return View("Error400");
            }

            if (statusCode == 401)
            {
                return View("Error401");
            }

            if (statusCode == 404)
            {
                return View("Error404");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(ContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await SendEmailAsync(model);
                ViewBag.Message = "Your message has been sent successfully!";
            }
            catch (Exception)
            {
                ViewBag.Error = "There was an error sending your message. Please try again later.";
            }

            return View();
        }

        private async Task SendEmailAsync(ContactViewModel model)
        {
            var fromAddress = new MailAddress("your-email@example.com", "Your Name or Company");
            var toAddress = new MailAddress("receiver@example.com", "Receiver's Name");
            const string fromPassword = "your-email-password";
            const string subject = "New Contact Us Message";
            string body = $"Name: {model.Name}\nEmail: {model.Email}\nMessage: {model.Message}";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                await smtp.SendMailAsync(message);
            }
        }
    }
}
