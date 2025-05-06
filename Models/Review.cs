namespace BookingSystem.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int PackageId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; } // 1 to 5
        public string Comment { get; set; }
    }

}
