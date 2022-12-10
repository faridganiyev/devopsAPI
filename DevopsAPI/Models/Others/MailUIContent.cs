namespace DevopsAPI.Models.Others
{
    public class MailUIContent
    {
        public string title { get; set; }
        public string description { get; set; }
        public string link { get; set; }
        public string buttonTitle { get; set; }
        public string copyright { get; set; }
    }

    public enum MailTemplate
    {
        email_confirmation,
        forgot_password,
        info
    }
}
