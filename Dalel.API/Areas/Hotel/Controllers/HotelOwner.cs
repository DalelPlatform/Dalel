using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Dalel.Services;
using Dalel.ViewModels;
using Dalel.ViewModels.Hotel;
using Models.Enums;
using Serilog;

namespace Dalel.Api.Controllers
{
    [ApiController]
    [Route("api/hotel-owner")]
    [Produces("application/json")]
    [Authorize(Roles = "HotelOwner")]

    public class HotelOwnerController : ControllerBase
    {
        private readonly HotelService _hotelService;
        private readonly ILogger<HotelOwnerController> _logger;

        public HotelOwnerController(HotelService hotelService, ILogger<HotelOwnerController> logger)
        {
            _hotelService = hotelService;
            _logger = logger;
        }

        #region Hotels Management
       
        [HttpPost("hotels")]
        public IActionResult CreateHotel([FromBody] HotelCreation model)
        {
            _logger.LogInformation("Creating hotel");
            var result = _hotelService.CreateHotel(model);
            return new JsonResult(result);
        }

        [HttpPut("hotels/{id}")]
        public IActionResult UpdateHotel(int id, [FromBody] HotelCreation model)
        {
            _logger.LogInformation("Updating hotel {HotelId}", id);
            var result = _hotelService.UpdateHotel(id, model);
            return new JsonResult(result);
        }

        [HttpDelete("hotels/{id}")]
        public IActionResult DeleteHotel(int id)
        {
            _logger.LogWarning("Deleting hotel {HotelId}", id);
            var result = _hotelService.DeleteHotel(id);
            return new JsonResult(result);
        }

        [HttpGet("hotels/{id}")]
        public IActionResult GetHotelDetails(int id)
        {
            _logger.LogInformation("Fetching hotel {HotelId}", id);
            var result = _hotelService.GetHotelById(id);
            return new JsonResult(result);
        }

        [HttpGet("hotels")]
        public IActionResult GetAllHotels()
        {
            _logger.LogInformation("Fetching all hotels");
            var result = _hotelService.GetAllHotels();
            return new JsonResult(result);
        }

        [HttpGet("hotels/search")]
        public IActionResult SearchHotels(string name, string city, VerificationStatus? status, int pageSize = 5, int pageIndex = 1)
        {
            _logger.LogInformation("Searching hotels");
            var result = _hotelService.SearchHotels(name, city, null, status, false, false, pageSize, pageIndex);
            return new JsonResult(result);
        }
        #endregion

        #region Room Types Management
        [HttpPost("room-types")]
        [Authorize(Roles = "HotelOwner")]
        [HttpPost("room-types")]
        public IActionResult CreateRoomType([FromBody] RoomTypeCreation model)
        {
            _logger.LogInformation("CreateRoomType called");
            var result = _hotelService.CreateRoomType(model);
            return new JsonResult(result);
        }

        [Authorize(Roles = "HotelOwner")]
        [HttpPut("room-types/{id}")]
        public IActionResult UpdateRoomType(int id, [FromBody] RoomTypeCreation model)
        {
            _logger.LogInformation("UpdateRoomType {Id} called", id);
            var result = _hotelService.UpdateRoomType(id, model);
            return new JsonResult(result);
        }

        [Authorize(Roles = "HotelOwner")]
        [HttpDelete("room-types/{id}")]
        public IActionResult DeleteRoomType(int id)
        {
            _logger.LogWarning("DeleteRoomType {Id} called", id);
            var result = _hotelService.DeleteRoomType(id);
            return new JsonResult(result);
        }

        [AllowAnonymous]
        [HttpGet("room-types/{id}")]
        public IActionResult GetRoomTypeById(int id)
        {
            _logger.LogInformation("GetRoomTypeById {Id} called", id);
            var result = _hotelService.GetRoomTypeById(id);
            return new JsonResult(result);
        }

        [AllowAnonymous]
        [HttpGet("room-types")]
        public IActionResult GetAllRoomTypes()
        {
            _logger.LogInformation("GetAllRoomTypes called");
            var result = _hotelService.GetAllRoomTypes();
            return new JsonResult(result);
        }

        [AllowAnonymous]
        [HttpGet("room-types/search")]
        public IActionResult SearchRoomTypes(
            [FromQuery] HotelRoomType? type,
            [FromQuery] int? maxOccupancy,
            [FromQuery] bool? hasBreakfast,
            [FromQuery] float? minPrice,
            [FromQuery] float? maxPrice,
            [FromQuery] int? hotelId,
            [FromQuery] int pageSize = 5,
            [FromQuery] int pageIndex = 1)
        {
            _logger.LogInformation("SearchRoomTypes called");
            var result = _hotelService.SearchRoomTypes(type, maxOccupancy, hasBreakfast, minPrice, maxPrice, hotelId, false, pageSize, pageIndex);
            return new JsonResult(result);
        }
        #endregion

        #region Rooms Management
        [Authorize(Roles = "HotelOwner")]
        [HttpPost("rooms")]
        public IActionResult CreateRoom([FromBody] RoomCreation model)
        {
            _logger.LogInformation("CreateRoom called");
            var result = _hotelService.CreateRoom(model);
            return new JsonResult(result);
        }

        [Authorize(Roles = "HotelOwner")]
        [HttpPut("rooms/{id}")]
        public IActionResult UpdateRoom(int id, [FromBody] RoomCreation model)
        {
            _logger.LogInformation("UpdateRoom {Id} called", id);
            var result = _hotelService.UpdateRoom(id, model);
            return new JsonResult(result);
        }

        [Authorize(Roles = "HotelOwner")]
        [HttpDelete("rooms/{id}")]
        public IActionResult DeleteRoom(int id)
        {
            _logger.LogWarning("DeleteRoom {Id} called", id);
            var result = _hotelService.DeleteRoom(id);
            return new JsonResult(result);
        }

        [AllowAnonymous]
        [HttpGet("rooms/{id}")]
        public IActionResult GetRoomById(int id)
        {
            _logger.LogInformation("GetRoomById {Id} called", id);
            var result = _hotelService.GetRoomById(id);
            return new JsonResult(result);
        }

        [AllowAnonymous]
        [HttpGet("rooms")]
        public IActionResult GetAllRooms()
        {
            _logger.LogInformation("GetAllRooms called");
            var result = _hotelService.GetAllRooms();
            return new JsonResult(result);
        }

        [AllowAnonymous]
        [HttpGet("rooms/search")]
        public IActionResult SearchRooms(
            [FromQuery] int? roomTypeId,
            [FromQuery] string viewType,
            [FromQuery] AvaliabilityStatus? availability,
            [FromQuery] int pageSize = 5,
            [FromQuery] int pageIndex = 1)
        {
            _logger.LogInformation("SearchRooms called");
            var result = _hotelService.SearchRooms(roomTypeId, viewType, availability, false, pageSize, pageIndex);
            return new JsonResult(result);
        }

        public IActionResult CheckRoomAvailability(DateTime startDate, DateTime endDate, int roomTypeId)
        {
            _logger.LogInformation("Checking room availability for RoomTypeId {RoomTypeId}", roomTypeId);
            return new JsonResult(new { success = true, message = "Availability logic placeholder." });
        }
        #endregion

        #region Bookings Management
        [HttpGet("bookings")]
        public IActionResult GetAllBookings(DateTime? checkinFrom, DateTime? checkinTo, BookingStatus? status)
        {
            _logger.LogInformation("Fetching all bookings");
            var result = _hotelService.SearchBookings(checkinFrom, checkinTo, null, status, null);
            return new JsonResult(result);
        }

        [Authorize(Roles = "HotelOwner")]
        [HttpPut("bookings/{id}/status")]
        public IActionResult UpdateBookingStatus(int id, [FromBody] BookingHotelRoomCreation model)
        {
            _logger.LogInformation("Updating booking status for {BookingId}", id);
            return new JsonResult(new { success = true, message = "Booking status update placeholder." });
        }
        #endregion

        #region Financial Operations
        [HttpGet("payments/reports")]
        public IActionResult GenerateFinancialReport(DateTime fromDate, DateTime toDate)
        {
            _logger.LogInformation("Generating financial report");
            return new JsonResult(new { success = true, message = "Report generation logic placeholder." });
        }

        [HttpGet("payments/summary")]
        public IActionResult GetPaymentSummary()
        {
            _logger.LogInformation("Getting payment summary");
            return new JsonResult(new { success = true, message = "Summary logic placeholder." });
        }
        #endregion

        #region Reviews & Ratings
        [HttpGet("reviews")]
        public IActionResult GetAllReviews(float? minRating, float? maxRating)
        {
            _logger.LogInformation("Fetching reviews with rating between {Min} and {Max}", minRating, maxRating);
            var result = _hotelService.SearchReviews(null, minRating, maxRating, null, null, null, null);
            return new JsonResult(result);
        }

        [Authorize(Roles = "HotelOwner")]
        [HttpPost("reviews/{id}/response")]
        public IActionResult AddReviewResponse(int id, [FromBody] ReviewDetails model)
        {
            _logger.LogInformation("Adding review response for {ReviewId}", id);
            return new JsonResult(new { success = true, message = "Review response placeholder." });
        }
        #endregion

        #region Service Management
        [Authorize(Roles = "HotelOwner")]
        [HttpPost("services")]
        public IActionResult CreateHotelService([FromBody] ServiceCreation model)
        {
            _logger.LogInformation("CreateHotelService called");
            var result = _hotelService.CreateService(model);
            return new JsonResult(result);
        }

        [Authorize(Roles = "HotelOwner")]
        [HttpPut("services/{id}/availability")]
        public IActionResult UpdateServiceAvailability(int id, [FromBody] bool isActive)
        {
            _logger.LogInformation("UpdateServiceAvailability {Id} -> {Active}", id, isActive);
            var result = _hotelService.UpdateService(id, new ServiceCreation { IsActive = isActive });
            return new JsonResult(result);
        }

        [AllowAnonymous]
        [HttpGet("services")]
        public IActionResult GetAllServices()
        {
            _logger.LogInformation("GetAllServices called");
            var result = _hotelService.GetAllServices();
            return new JsonResult(result);
        }

        #endregion

        #region Analytics
        [HttpGet("analytics/occupancy")]
        public IActionResult GetOccupancyRates(DateTime startDate, DateTime endDate)
        {
            _logger.LogInformation("Fetching occupancy rates");
            return new JsonResult(new { success = true, message = "Occupancy analysis placeholder." });
        }

        [HttpGet("analytics/revenue")]
        public IActionResult GetRevenueAnalytics(string period)
        {
            _logger.LogInformation("Fetching revenue analytics for {Period}", period);
            return new JsonResult(new { success = true, message = "Revenue analysis placeholder." });
        }
        #endregion
    }
}
