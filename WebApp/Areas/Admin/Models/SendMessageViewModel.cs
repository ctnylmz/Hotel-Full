namespace WebApp.Areas.Admin.Models
{
    public class SendMessageViewModel 
    {
        public int id { get; set; }
        public string title { get; set; }
        public string receiverName { get; set; }
        public string receiverMail { get; set; }
        public string content { get; set; }
        public string senderName { get; set; }
        public string senderMail { get; set; }
        public DateTime date { get; set; } = DateTime.UtcNow;

    }
}
