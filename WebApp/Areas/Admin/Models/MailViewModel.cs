namespace WebApp.Areas.Admin.Models
{
    public class MailViewModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string SenderMail { get; set; }
        public string receiverMail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

    }
}
