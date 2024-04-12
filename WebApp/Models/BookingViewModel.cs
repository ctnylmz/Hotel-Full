namespace WebApp.Models
{
    public class BookingViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string mail { get; set; }
        public DateTime checkin { get; set; }
        public DateTime checkOut { get; set; }
        public int adultCount { get; set; }
        public int childCount { get; set; }
        public int roomCount { get; set; }
        public string specialRequest { get; set; }
        public string Status { get; set; }
        public string description { get; set; }

    }
}
