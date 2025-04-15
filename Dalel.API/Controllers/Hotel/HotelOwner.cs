using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using Dalel.Services.HotelService;
using Dalel.ViewModels;           
using Microsoft.Extensions.Logging;
using Models.Hotel;
using Utilities;

namespace Dalel.Controllers
{
    [Authorize(Roles = "HotelOwner")]
    [ApiController]
    [Route("api/[controller]")]
    public class OwnerController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        private readonly ILogger<OwnerController> _logger;

        public OwnerController(IHotelService hotelService, ILogger<OwnerController> logger)
        {
            _hotelService = hotelService;
            _logger = logger;
        }

        
        // Retrieves the hotel for the current owner.
     
        [HttpGet("hotel")]
        public IActionResult GetOwnerHotel()
        {
            try
            {
                string ownerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(ownerId))
                {
                    _logger.LogWarning("GetOwnerHotel: Owner ID not found in token.");
                    return Unauthorized("Owner ID not found in token.");
                }

                var result = _hotelService.GetHotelByOwnerId(ownerId);
                if (!result.Success)
                {
                    _logger.LogWarning("GetOwnerHotel: {Message}", result.Message);
                    return NotFound(result.Message);
                }

                var hotelDetails = result.Data.ToDetailsViewModel();
                _logger.LogInformation("GetOwnerHotel: Successfully retrieved hotel for owner {OwnerId}", ownerId);
                return Ok(hotelDetails);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetOwnerHotel: Error retrieving hotel for owner.");
                return StatusCode(500, "An error occurred while retrieving the hotel.");
            }
        }

  
        // Creates a new hotel for the owner.
   
        [HttpPost("hotel")]
        public IActionResult CreateHotel([FromForm] HotelCreation hotelCreation)
        {
            try
            {
                string ownerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(ownerId))
                {
                    _logger.LogWarning("CreateHotel: Owner ID not found in token.");
                    return Unauthorized("Owner ID not found in token.");
                }

                hotelCreation.OwnerId = ownerId;

                var hotelModel = hotelCreation.ToModel();
                var result = _hotelService.AddHotel(hotelModel);
                if (!result.Success)
                {
                    _logger.LogWarning("CreateHotel: {Message}", result.Message);
                    return BadRequest(result.Message);
                }

                _logger.LogInformation("CreateHotel: Hotel created successfully for owner {OwnerId}", ownerId);
                return Ok(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CreateHotel: Error creating hotel for owner.");
                return StatusCode(500, "An error occurred while creating the hotel.");
            }
        }

     
        // Updates the hotel specified by id.
  
        [HttpPut("hotel/{id}")]
        public IActionResult UpdateHotel(int id, [FromForm] HotelCreation hotelUpdate)
        {
            try
            {
                string ownerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(ownerId))
                {
                    _logger.LogWarning("UpdateHotel: Owner ID not found in token.");
                    return Unauthorized("Owner ID not found in token.");
                }

                var getResult = _hotelService.GetHotelById(id);
                if (!getResult.Success)
                {
                    _logger.LogWarning("UpdateHotel: {Message}", getResult.Message);
                    return NotFound(getResult.Message);
                }

                var existingHotel = getResult.Data;
                if (!string.Equals(existingHotel.OwnerId, ownerId, StringComparison.OrdinalIgnoreCase))
                {
                    _logger.LogWarning("UpdateHotel: Owner {OwnerId} does not own hotel with ID {Id}", ownerId, id);
                    return Forbid("You are not authorized to update this hotel.");
                }

                var updatedHotel = hotelUpdate.ToModel();
                updatedHotel.Id = id;

                var updateResult = _hotelService.UpdateHotel(updatedHotel);
                if (!updateResult.Success)
                {
                    _logger.LogWarning("UpdateHotel: {Message}", updateResult.Message);
                    return BadRequest(updateResult.Message);
                }

                _logger.LogInformation("UpdateHotel: Hotel with ID {Id} updated successfully for owner {OwnerId}", id, ownerId);
                return Ok(updateResult.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "UpdateHotel: Error updating hotel with ID {Id}", id);
                return StatusCode(500, "An error occurred while updating the hotel.");
            }
        }

     
        // Deletes the hotel specified by id.

        [HttpDelete("hotel/{id}")]
        public IActionResult DeleteHotel(int id)
        {
            try
            {
                string ownerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(ownerId))
                {
                    _logger.LogWarning("DeleteHotel: Owner ID not found in token.");
                    return Unauthorized("Owner ID not found in token.");
                }

                // Ensure the hotel belongs to the current owner.
                var getResult = _hotelService.GetHotelById(id);
                if (!getResult.Success)
                {
                    _logger.LogWarning("DeleteHotel: {Message}", getResult.Message);
                    return NotFound(getResult.Message);
                }

                if (!string.Equals(getResult.Data.OwnerId, ownerId, StringComparison.OrdinalIgnoreCase))
                {
                    _logger.LogWarning("DeleteHotel: Owner {OwnerId} does not own hotel with ID {Id}", ownerId, id);
                    return Forbid("You are not authorized to delete this hotel.");
                }

                var deleteResult = _hotelService.DeleteHotel(id);
                if (!deleteResult.Success)
                {
                    _logger.LogWarning("DeleteHotel: {Message}", deleteResult.Message);
                    return BadRequest(deleteResult.Message);
                }

                _logger.LogInformation("DeleteHotel: Hotel with ID {Id} deleted successfully for owner {OwnerId}", id, ownerId);
                return Ok(deleteResult.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DeleteHotel: Error deleting hotel with ID {Id}", id);
                return StatusCode(500, "An error occurred while deleting the hotel.");
            }
        }

        // Retrieves all hotels (for demonstration; typically, an owner would have one hotel).
      
        [HttpGet("hotels")]
        public IActionResult GetAllHotels()
        {
            try
            {
                var result = _hotelService.GetAllHotels();
                if (!result.Success)
                {
                    _logger.LogWarning("GetAllHotels: {Message}", result.Message);
                    return NotFound(result.Message);
                }
                _logger.LogInformation("GetAllHotels: Retrieved {Count} hotels.", result.Data?.Count() ?? 0);
                return Ok(result.Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetAllHotels: Error retrieving hotels.");
                return StatusCode(500, "An error occurred while retrieving hotels.");
            }
        }

        
        // Retrieves hotels by city.
       
        [HttpGet("hotels/city")]
        public IActionResult GetHotelsByCity([FromQuery] string city)
        {
            try
            {
                if (string.IsNullOrEmpty(city))
                {
                    _logger.LogWarning("GetHotelsByCity: City parameter is missing.");
                    return BadRequest("City parameter is required.");
                }
                var result = _hotelService.GetHotelsByCity(city);
                if (!result.Success)
                {
                    _logger.LogWarning("GetHotelsByCity: {Message}", result.Message);
                    return NotFound(result.Message);
                }
                _logger.LogInformation("GetHotelsByCity: Retrieved {Count} hotels in city {City}.", result.Data?.Count() ?? 0, city);
                return Ok(result.Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetHotelsByCity: Error retrieving hotels by city.");
                return StatusCode(500, "An error occurred while retrieving hotels by city.");
            }
        }
    }
}
