using Dalel.Services;
using Dalel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Models.Driver;
using Models.Enums;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Dalel.API.Areas
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly VehicleService _driverService;

        public DriverController(VehicleService driverService)
        {
            _driverService = driverService;
        }

        [HttpPost("AddDriver")]
        public async Task<IActionResult> AddDriver([FromBody] AddVehicle driver)
        {
            driver.DriverId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await _driverService.AddVehicle(driver.ToModel());
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpPut("EditDriver")]
        public async Task<IActionResult> EditDriver([FromBody] AddVehicle driver)
        {

            var result = await _driverService.EditVehicle(driver.ToModel());
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpDelete("Driver/{id}")]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            var result = await _driverService.DeleteVehicle(id);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

     

        [HttpPost("Payment")]
        public async Task<IActionResult> AddPayment([FromBody] AddPaymentVehicle payment)
        {
            var result = await _driverService.AddPayment(payment.ToModel());
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpPut("Payment")]
        public async Task<IActionResult> UpdatePaymentStatus(int paymentId, PaymentStatus newStatus)
        {
            var result = await _driverService.UpdatePaymentStatus(paymentId, newStatus);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpPost("Review")]
        public async Task<IActionResult> AddReview([FromBody] AddReviewVehicle review)
        {
            var result = await _driverService.AddReview(review.ToModel());
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpPut("Review")]
        public async Task<IActionResult> EditReview([FromBody] AddReviewVehicle review)
        {
            var result = await _driverService.EditReview(review.ToModel());
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpDelete("Review/{reviewId}")]
        public async Task<IActionResult> DeleteReview(int reviewId)
        {
            var result = await _driverService.DeleteReview(reviewId);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }
    }
}
