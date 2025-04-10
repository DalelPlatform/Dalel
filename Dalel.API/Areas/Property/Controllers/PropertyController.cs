using Dalel.Services;
using Dalel.ViewModels;
using Dalel.ViewModels.Agency.PackageBookingPayment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Enums;
using Models.Property;
using Utilities;

namespace Dalel.API.Areas.Property.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private PropertyService propertyService;
        public PropertyController(PropertyService propertyService)
        {
            this.propertyService = propertyService;
        }

        [HttpPost("Property")]
        public async Task<IActionResult> AddProperty([FromBody] AddPropertiesVM property)
        {
            var result = await propertyService.AddProperty(property.ToModel());
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }
        [HttpPut("Property")]
        public async Task<IActionResult> EditProperty([FromBody] AddPropertiesVM property)
        {
            var result = await propertyService.EditProperty(property.ToModel());
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            var result = await propertyService.DeleteProperty(id);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpPost("Booking")]
        public async Task<IActionResult> BookProperty(AddBookingPropertiesVM booking)
        {
            var result = await propertyService.BookProperty(booking.ToModel());
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }
        [HttpDelete("{bookingId}")]
        public async Task<IActionResult> CancelBooking(int bookingId)
        {
            var result = await propertyService.CancelBooking(bookingId);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpPost("Payment")]
        public async Task<IActionResult> AddPayment(PaymentProperties payment)
        {
            var result = await propertyService.AddPayment(payment);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }
        [HttpPut("Payment")]
        public async Task<IActionResult> UpdatePaymentStatus(int paymentId, PaymentStatus newStatus)
        {
            var result = await propertyService.UpdatePaymentStatus(paymentId, newStatus);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

        // complete the view model
        //[HttpPost]
        //public async Task<IActionResult> AddReview(AddReviewPropertiesVM review)
        //{
        //    var result = await propertyService.AddReview(review.ToModel());
        //    if (!result.Success)
        //        return BadRequest(result.Message);
        //    return Ok(result);
        //}

        [HttpPut("Review")]
        public async Task<IActionResult> EditReview(ReviewProperties review)
        {
            var result = await propertyService.EditReview(review);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }
        [HttpDelete("{reviewId}")]
        public async Task<IActionResult> DeleteReview(int reviewId)
        {
            var result = await propertyService.DeleteReview(reviewId);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }

    }
}
