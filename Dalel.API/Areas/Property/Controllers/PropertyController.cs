using Dalel.Services;
using Dalel.ViewModels;
using Dalel.ViewModels.Agency.PackageBookingPayment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Enums;
using Models.Property;
using System.Security.Claims;
using Utilities;

namespace Dalel.API.Areas
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
        [Authorize(Roles = "PropertyOwner")]
        public  IActionResult AddProperty([FromBody] AddPropertiesVM property)
        {
            property.OwnerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result =  propertyService.AddProperty(property.ToModel());
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpPut("Property")]
        public async Task<IActionResult> EditProperty([FromBody] AddPropertiesVM property)
        {
            var result = await propertyService.EditProperty(property.ToModel());
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            var result = await propertyService.DeleteProperty(id);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpPost("Booking")]
        [Authorize(Roles = "Client")]
        public  IActionResult BookProperty([FromBody]AddBookingPropertiesVM booking)
        {
            booking.ClientId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result =  propertyService.BookProperty(booking.ToModel(), booking.ClientId);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpDelete("{bookingId}")]
        [Authorize("Client")]
        public async Task<IActionResult> CancelBooking(int bookingId)
        {
            var result = await propertyService.CancelBooking(bookingId);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpPost("Payment")]
        public async Task<IActionResult> AddPayment(PaymentProperties payment)
        {
            var result = await propertyService.AddPayment(payment);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }
        [HttpPut("Payment")]
        public async Task<IActionResult> UpdatePaymentStatus(int paymentId, PaymentStatus newStatus)
        {
            var result = await propertyService.UpdatePaymentStatus(paymentId, newStatus);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
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
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }
        [HttpDelete("{reviewId}")]
        public async Task<IActionResult> DeleteReview(int reviewId)
        {
            var result = await propertyService.DeleteReview(reviewId);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

    }
}
