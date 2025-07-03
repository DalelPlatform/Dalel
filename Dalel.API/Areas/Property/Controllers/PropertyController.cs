using Dalel.Services;
using Dalel.ViewModels;
using Dalel.ViewModels.Agency.PackageBookingPayment;
using Dalel.ViewModels.Property.PaymentPropertiesDeails;
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
        private UploadMedia uploader;
        public PropertyController(PropertyService propertyService, UploadMedia uploader)
        {
            this.propertyService = propertyService;
            this.uploader = uploader;
        }
        [HttpGet("search")]
        public IActionResult SearchProperties(
            [FromQuery] string searchText = "",
            [FromQuery] string city = null,
            [FromQuery] string region = null,
            [FromQuery] string street = null,
            [FromQuery] string address = null,
            [FromQuery] int NumberOfRooms = 0,
            [FromQuery] int BuildingNo = 0,
            [FromQuery] int FloorNo = 0,
            [FromQuery] VerificationStatus? verificationStatus = null,
            [FromQuery] string sortBy = "id",
            [FromQuery] bool descending = false,
            [FromQuery] int pageSize = 5,
            [FromQuery] int pageIndex = 1)
        {
            var result = propertyService.SearchProperties(
                    searchText, city, region, street, address, NumberOfRooms, BuildingNo, FloorNo, verificationStatus,
                    sortBy, descending, pageSize, pageIndex);
            if (!result.Success)
                return new JsonResult(result);
            return new JsonResult(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetProperty(int id)
        {
            var result =  propertyService.GetPropertyByID(id);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpPost("Property")]
        [Authorize(Roles = "PropertyOwner")]
        public  IActionResult AddProperty([FromForm] AddPropertiesVM property)
        {
            if (!ModelState.IsValid)
            property.OwnerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            property.Paths = uploader.addimage(property.PropertyImages);
            var result =  propertyService.AddProperty(property.ToModel());
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditProperty([FromBody] AddPropertiesVM property, int id)
        {
            var result = await propertyService.EditProperty(property,id);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }
        [HttpDelete("delete-property/{id}")]
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
            var result =  propertyService.BookProperty(booking);
            if (!result.Success)
                return new JsonResult(result);
            return new JsonResult(result);
        }

        [HttpDelete("cancel-booking/{bookingId}")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> CancelBooking(int bookingId)
        {
            var result = await propertyService.CancelBooking(bookingId);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpPost("Payment")]
        public async Task<IActionResult> AddPayment(AddPaymentPropertiesVM payment)
        {
            var result = await propertyService.AddPayment(payment.ToModel());
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
