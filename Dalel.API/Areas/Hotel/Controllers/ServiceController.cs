using Dalel.Services.HotelService;
using Dalel.ViewModels.Hotel.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Hotel;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dalel.API.Areas.Hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly AmenitiesService _amenitiesService;
        private readonly ILogger<ServiceController> _logger;

        public ServiceController(AmenitiesService amenitiesService, ILogger<ServiceController> logger)
        {
            _amenitiesService = amenitiesService;
            _logger = logger;
        }

        // Get all services
       
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _amenitiesService.GetAllAsync();
                if (!result.Success)
                {
                    _logger.LogWarning("GetAll failed: {Message}", result.Message);
                    return new JsonResult(result.Message);
                }

                var viewModel = result.Data.Select(s => s.ToServiceDetailsViewModel());
                return new JsonResult(viewModel);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred in GetAll");
                return new JsonResult(500, "An error occurred while fetching data.");
            }
        }

        // Get service by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _amenitiesService.GetByIdAsync(id);
                if (!result.Success)
                {
                    _logger.LogWarning("GetById failed for Id={Id}: {Message}", id, result.Message);
                    return new JsonResult(result.Message);
                }

                return new JsonResult(result.Data.ToServiceDetailsViewModel());
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred in GetById");
                return new JsonResult(500, "An error occurred while fetching the service.");
            }
        }

        // Bulk insert new services
        [HttpPost("bulk-insert")]
        [Authorize(Roles = "HotelOwner")]
        public async Task<IActionResult> BulkInsert([FromBody] List<ServiceCreation> models)
        {
            if (!ModelState.IsValid)
                return new JsonResult(ModelState);

            try
            {
                var entities = models.Select(m => m.ToService()).ToList();
                var result = await _amenitiesService.BulkInsertAsync(entities);

                if (!result.Success)
                {
                    _logger.LogError("BulkInsert failed: {Message}", result.Message);
                    return new JsonResult(result.Message);
                }

                return new JsonResult(result.Message);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred in BulkInsert");
                return new JsonResult(500, "An error occurred while inserting services.");
            }
        }

        // Bulk update existing services
        [HttpPut("bulk-update")]
        [Authorize(Roles = "HotelOwner")]
        public async Task<IActionResult> BulkUpdate([FromBody] List<ServiceDetails> models)
        {
            if (!ModelState.IsValid)
                return new JsonResult(ModelState);

            try
            {
                var services = models.Select(m => new Service
                {
                    Id = m.Id,
                    Name = m.Name,
                    Description = m.Description,
                    IsActive = m.IsActive,
                    ModifiedBy = "CurrentUser",
                    ModifiedDate = DateTime.Now
                }).ToList();

                var result = await _amenitiesService.BulkUpdateAsync(services);

                if (!result.Success)
                {
                    _logger.LogError("BulkUpdate failed: {Message}", result.Message);
                    return new JsonResult(result.Message);
                }

                return new JsonResult(result.Message);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred in BulkUpdate");
                return new JsonResult(500, "An error occurred while updating services.");
            }
        }

        // Bulk update IsActive status
        [HttpPut("bulk-update-status")]
        [Authorize(Roles = "HotelOwner")]
        public async Task<IActionResult> BulkUpdateStatus([FromBody] List<ServiceDetails> models)
        {
            if (!ModelState.IsValid)
                return new JsonResult(ModelState);

            try
            {
                var services = models.Select(m => new Service
                {
                    Id = m.Id,
                    IsActive = m.IsActive,
                    ModifiedBy = "CurrentUser",
                    ModifiedDate = DateTime.Now
                }).ToList();

                var result = await _amenitiesService.BulkUpdateStatusAsync(services);

                if (!result.Success)
                {
                    _logger.LogError("BulkUpdateStatus failed: {Message}", result.Message);
                    return new JsonResult(result.Message);
                }

                return new JsonResult(result.Message);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred in BulkUpdateStatus");
                return new JsonResult(500, "An error occurred while updating statuses.");
            }
        }
    }
}
