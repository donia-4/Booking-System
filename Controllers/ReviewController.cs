using BookingSystem.DTOs;
using BookingSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ReviewController : ControllerBase
    {
        private static List<Review> _reviews = new();
        private static List<Booking> _bookings = new(); 
        [HttpPost]
        public IActionResult AddReview([FromBody] ReviewCreateDto review)
        {
            if (review.Rating < 1 || review.Rating > 5)
                return BadRequest("Rating must be between 1 and 5.");

            // Optional: تحقق إن المستخدم فعلاً حجز الباكدج ده
            var hasBooking = _bookings.Any(b => b.UserId == review.UserId && b.PackageIds.Contains(review.PackageId));
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
