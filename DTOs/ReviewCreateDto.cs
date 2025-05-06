namespace BookingSystem.DTOs
{
    public class ReviewCreateDto
    {
        public int PackageId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; } // 1 to 5
        public string? Comment { get; set; }
    }
}
