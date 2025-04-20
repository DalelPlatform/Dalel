using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Dalel.Services.HotelService;
using Dalel.ViewModels;
using Microsoft.Extensions.Logging;
using Models.Hotel;
using Utilities;

namespace Dalel.API.Areas.Hotel.Controllers
{
    [Authorize(Roles = "HotelOwner")]
    [ApiController]
    [Route("api/[controller]")]
    public class HotelOwnerController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        private readonly ILogger<HotelOwnerController> _logger;

        public HotelOwnerController(IHotelService hotelService, ILogger<HotelOwnerController> logger)
        {
            _hotelService = hotelService;
            _logger = logger;
        }

        [HttpGet("hotel")]
        public async Task<IActionResult> GetOwnerHotel()
        {
            try
            {
                var ownerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(ownerId))
                {
                    _logger.LogWarning("GetOwnerHotel: Owner ID not found in token.");
                    return new JsonResult("Owner ID not found in token.");
                }

                var result = await _hotelService.GetHotelByOwnerIdAsync(ownerId);
                if (!result.Success || result.Data == null)
                {
                    _logger.LogWarning("GetOwnerHotel: {Message}", result.Message);
                    return new JsonResult(result.Message);
                }

                var hotelDetails = result.Data.ToDetailsViewModel();
                return new JsonResult(hotelDetails);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetOwnerHotel: Error retrieving hotel for owner.");
                return new JsonResult(500, "An error occurred while retrieving the hotel.");
            }
        }

        [HttpPost("hotel")]
        public async Task<IActionResult> CreateHotel([FromForm] HotelCreation hotelCreation)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return new JsonResult(ModelState);
                }

                var ownerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(ownerId))
                {
                    _logger.LogWarning("CreateHotel: Owner ID not found in token.");
                    return new JsonResult("Owner ID not found in token.");
                }

                hotelCreation.OwnerId = ownerId;
                var hotelModel = hotelCreation.ToModel();

                var result = await _hotelService.AddHotelAsync(hotelModel);
                if (!result.Success)
                {
                    _logger.LogWarning("CreateHotel: {Message}", result.Message);
                    return new JsonResult(result.Message);
                }

                return CreatedAtAction(nameof(GetOwnerHotel), new { id = hotelModel.Id }, result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CreateHotel: Error creating hotel for owner.");
                return new JsonResult(500, "An error occurred while creating the hotel.");
            }
        }

        [HttpPut("hotel/{id}")]
        public async Task<IActionResult> UpdateHotel(int id, [FromForm] HotelCreation hotelUpdate)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return new JsonResult(ModelState);
                }

                var ownerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(ownerId))
                {
                    _logger.LogWarning("UpdateHotel: Owner ID not found in token.");
                    return new JsonResult("Owner ID not found in token.");
                }

                var getResult = await _hotelService.GetHotelByIdAsync(id);
                if (!getResult.Success || getResult.Data == null)
                {
                    _logger.LogWarning("UpdateHotel: {Message}", getResult.Message);
                    return new JsonResult(getResult.Message);
                }

                var existingHotel = getResult.Data;
                if (!string.Equals(existingHotel.OwnerId, ownerId, StringComparison.OrdinalIgnoreCase))
                {
                    _logger.LogWarning("UpdateHotel: Authorization failed for owner {OwnerId}", ownerId);
                    return Forbid();
                }

                var updatedHotel = hotelUpdate.ToModel();
                updatedHotel.Id = id;
                updatedHotel.VerificationStatus = existingHotel.VerificationStatus; // Preserve status

                var updateResult = await _hotelService.UpdateHotelAsync(updatedHotel);
                if (!updateResult.Success)
                {
                    return new JsonResult(updateResult.Message);
                }

                return new JsonResult(updateResult.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "UpdateHotel: Error updating hotel {Id}", id);
                return new JsonResult(500, "An error occurred while updating the hotel.");
            }
        }

        [HttpDelete("hotel/{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            try
            {
                var ownerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(ownerId))
                {
                    _logger.LogWarning("DeleteHotel: Owner ID not found in token.");
                    return new JsonResult("Owner ID not found in token.");
                }

                var getResult = await _hotelService.GetHotelByIdAsync(id);
                if (!getResult.Success || getResult.Data == null)
                {
                    return new JsonResult(getResult.Message);
                }

                if (!string.Equals(getResult.Data.OwnerId, ownerId, StringComparison.OrdinalIgnoreCase))
                {
                    _logger.LogWarning("DeleteHotel: Authorization failed for owner {OwnerId}", ownerId);
                    return Forbid();
                }

                var deleteResult = await _hotelService.DeleteHotelAsync(id);
                if (!deleteResult.Success)
                {
                    return new JsonResult(deleteResult.Message);
                }

                return new JsonResult(deleteResult.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DeleteHotel: Error deleting hotel {Id}", id);
                return new JsonResult(500, "An error occurred while deleting the hotel.");
            }
        }

        [HttpGet("hotels")]
        public async Task<IActionResult> GetAllHotels()
        {
            try
            {
                var result = await _hotelService.GetAllHotelsAsync();
                if (!result.Success)
                {
                    return new JsonResult(result.Message);
                }
                return new JsonResult(result.Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetAllHotels: Error retrieving hotels");
                return new JsonResult(500, "An error occurred while retrieving hotels.");
            }
        }

        [HttpGet("hotels/city")]
        public async Task<IActionResult> GetHotelsByCity([FromQuery] string city)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(city))
                {
                    return new JsonResult("City parameter is required.");
                }

                var result = await _hotelService.GetHotelsByCityAsync(city);
                if (!result.Success)
                {
                    return new JsonResult(result.Message);
                }
                return new JsonResult(result.Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetHotelsByCity: Error retrieving hotels in {City}", city);
                return new JsonResult(500, "An error occurred while retrieving hotels.");
            }
        }
    }
}