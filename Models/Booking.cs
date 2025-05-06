namespace BookingSystem.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.UtcNow;
        public List<int> PackageIds { get; set; } = new();
    }

}
