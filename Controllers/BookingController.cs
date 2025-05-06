using BookingSystem.DTOs;
using BookingSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private static List<Booking> _bookings = new();
        private static List<Review> _reviews = new();

        [HttpPost("add-booking")]
        public IActionResult AddBooking([FromBody] BookingCreateDto dto)
        {
            var booking = new Booking
            {
                BookingId = _bookings.Count + 1,
                UserId = dto.UserId,
                BookingDate = DateTime.Now,
                PackageIds = dto.PackageIds
            };

            _bookings.Add(booking);
            return Ok(booking);
        }
        [HttpGet("user/{userId}")]
        public IActionResult GetUserBookings(int userId)
        {
            var userBookings = _bookings.Where(b => b.UserId == userId).ToList();

            if (!userBookings.Any())
                return NotFound("No bookings found for this user.");

            return Ok(userBookings);
        }

        [HttpPost("add-review")]
        public IActionResult AddReview([FromBody] ReviewCreateDto review)
        {
            if (review.Rating < 1 || review.Rating > 5)
                return BadRequest("Rating must be between 1 and 5.");

            var hasBooking = _bookings.Any(b =>
                b.UserId == review.UserId && b.PackageIds.Contains(review.PackageId));

            if (!hasBooking)
                return BadRequest("User has not booked this package.");

            var newReview = new Review
            {
                ReviewId = _reviews.Count + 1,
                UserId = review.UserId,
                PackageId = review.PackageId,
                Rating = review.Rating,
                Comment = review.Comment
            };

            _reviews.Add(newReview);
            return Ok(newReview);
        }

        [HttpGet("packages/{id}/reviews")]
        public IActionResult GetPackageReviews(int id)
        {
            var packageReviews = _reviews.Where(r => r.PackageId == id).ToList();

            if (!packageReviews.Any())
                return NotFound("No reviews for this package.");

            return Ok(packageReviews);
        }
    }
}
