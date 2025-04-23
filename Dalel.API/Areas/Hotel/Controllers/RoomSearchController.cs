using Microsoft.AspNetCore.Mvc;
using Dalel.Services;
using Models.Enums;
using Microsoft.AspNetCore.Authorization;

namespace Dalel.Api.Controllers
{
    [ApiController]
    [Route("api/rooms")]
    [AllowAnonymous]
    public class RoomSearchController : ControllerBase
    {
        private readonly HotelServices _hotelService;
        private readonly ILogger<RoomSearchController> _logger;

        public RoomSearchController(
            HotelServices hotelService,
            ILogger<RoomSearchController> logger)
        {
            _hotelService = hotelService;
            _logger = logger;
        }

        #region Search

        [HttpGet("search")]
        public IActionResult SearchRooms(
            [FromQuery] int? roomTypeId = null,
            [FromQuery] string viewType = null,
            [FromQuery] AvaliabilityStatus? availability = null,
            [FromQuery] bool descending = false,
            [FromQuery] int pageSize = 5,
            [FromQuery] int pageIndex = 1)
        {
            _logger.LogInformation(
                "SearchRooms called with roomTypeId={RoomTypeId}, viewType={ViewType}, availability={Availability}, descending={Descending}, pageSize={PageSize}, pageIndex={PageIndex}",
                roomTypeId, viewType, availability, descending, pageSize, pageIndex);

            var result = _hotelService.SearchRooms(
                roomTypeId, viewType, availability,
                descending, pageSize, pageIndex);

            _logger.LogInformation(
                "SearchRooms returned {Count} rooms",
                result.Data?.Data?.Count ?? 0);

            return new JsonResult(result);
        }

        #endregion

        #region Details

        [HttpGet("{id}")]
        public IActionResult GetRoomDetails(int id)
        {
            _logger.LogInformation("GetRoomDetails called for id={Id}", id);

            var result = _hotelService.GetRoomById(id);

            _logger.LogInformation(
                "GetRoomDetails for id={Id} success={Success}",
                id, result.Success);

            return new JsonResult(result);
        }

        #endregion
    }
}
