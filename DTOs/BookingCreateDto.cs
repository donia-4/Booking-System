namespace BookingSystem.DTOs
{
    public class BookingCreateDto
    {
        public int UserId { get; set; }
        public List<int> PackageIds { get; set; } = new();
    }

}
