# Booking-System
I  created a minimal “booking” system: each checkout from .NET Dev #3 spawns a new “booking record.” Then travelers can post a review for each package they booked. Endpoints must allow retrieval of a user’s booking history and package reviews. No external DB needed—everything is static/in-memory.

# Requirements <br>
● ASP.NET Core <br>
○ .NET 6/7, same or separate from the basket solution. <br>
● In-Memory Models <br>
○ Booking { BookingId, UserId, DateTime BookingDate, List<int>
PackageIds } <br>
○ Review { ReviewId, PackageId, UserId, int Rating, string
Comment } <br>
# Endpoints  <br>
○ Bookings: GET /api/bookings/user/{userId} to see a user’s past
bookings.

○ Reviews: POST /api/reviews to submit a new review, GET
/api/packages/{id}/reviews to fetch reviews for a package.

# Validation
○ If rating <1 or >5, return 400.
○ Optionally, require that a user must have a completed booking for that package
before they can review.
● Testing
○ Confirm bookings are created after checkout, that retrieving them works, and that
reviews are saved properly.
Task Description
1. Task 1  <br>
○ Set Up Booking Model & Storage: private static List<Booking>
_bookings = new();.
○ Each checkout from Dev #3 triggers a new booking record in _bookings.
2. Task 2 <br>
○ Retrieve Bookings: GET /api/bookings/user/{userId} returns that
user’s booking history.
○ Provide status code 404 or 400 if no user or no bookings found (optional).
3. Task 3 <br>
○ Implement Reviews: a new Review model + POST /api/reviews.
○ Possibly a GET /api/packages/{id}/reviews to show all reviews for one
package.
