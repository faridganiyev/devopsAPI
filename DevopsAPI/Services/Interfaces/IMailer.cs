using DevopsAPI.Models.Others;

namespace DevopsAPI.Services.Interfaces
{
    public interface IMailer
    {
        bool SendAsHtml(string toAddress, MailUIContent mailContent, MailTemplate template);

        bool Send(string toAddress, string title, string content);

    }
}
