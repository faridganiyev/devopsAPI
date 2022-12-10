using DevopsAPI.Models.Base;
using DevopsAPI.Models.Others;
using DevopsAPI.Services.Interfaces;
using Microsoft.Extensions.Options;
using Mustachio;
using System.Dynamic;
using System.Net;
using System.Net.Mail;

namespace DevopsAPI.Services.Classes
{
    public class MailService : IMailer
    {
        private readonly MailOptions _mailOptions;

        public MailService(IOptions<MailOptions> mailOptions)
        {
            _mailOptions = mailOptions.Value;
        }

        private static string CreateHtmlContent(MailUIContent mailContent, MailTemplate template)
        {
            var templateContent = Parser.Parse(File.ReadAllText($"./wwwroot/htmls/{template}.html"));
            dynamic model = new ExpandoObject();
            model.title = mailContent.title;
            model.description = mailContent.description;
            model.link = mailContent.link;
            model.buttonTitle = mailContent.buttonTitle;
            return templateContent(model);
        }


        public bool SendAsHtml(string toAddress, MailUIContent mailContent, MailTemplate template)
        {
            var from = new MailAddress(_mailOptions.Username, "Dind.io");
            var to = new MailAddress(toAddress);
            using var smtp = new SmtpClient
            {
                Host = _mailOptions.SmtpServer,
                Port = _mailOptions.Port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_mailOptions.Username, _mailOptions.Password)
            };
            using var message = new MailMessage(from, to)
            {
                Subject = mailContent.title,
                Body = CreateHtmlContent(mailContent, template),
                IsBodyHtml = true
            };
            smtp.SendAsync(message, null);
            return true;
        }


        public bool Send(string toAddress, string title, string content)
        {
            var from = new MailAddress(_mailOptions.Username, "Dind.io");
            var to = new MailAddress(toAddress);
            var smtp = new SmtpClient
            {
                Host = _mailOptions.SmtpServer,
                Port = _mailOptions.Port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_mailOptions.Username, _mailOptions.Password)
            };
            using var message = new MailMessage(from, to)
            {
                Subject = title,
                Body = content,
                IsBodyHtml = false
            };
            smtp.SendAsync(message, null);
            return true;
        }
    }
}


