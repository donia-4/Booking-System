using BookingSystem.DTOs;
using BookingSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private static List<Booking> _bookings = new();
       
        [HttpGet("user/{userId}")]
        public IActionResult GetUserBookings(int userId)
        {
            var userBookings = _bookings.Where(b => b.UserId == userId).ToList();

            if (!userBookings.Any())
                return NotFound("No bookings found for this user.");

            return Ok(userBookings);
        }
        [HttpPost("add")]
        public IActionResult CreateBooking([FromBody] BookingCreateDto dto)
        {
            if (dto.PackageIds == null || !dto.PackageIds.Any())
                return BadRequest("At least one package must be selected.");

            var booking = new Booking
            {
                BookingId = _bookings.Count + 1,
                UserId = dto.UserId,
                BookingDate = DateTime.UtcNow,
                PackageIds = dto.PackageIds
            };

            _bookings.Add(booking);

            return Ok(booking);
        }

    }
}
