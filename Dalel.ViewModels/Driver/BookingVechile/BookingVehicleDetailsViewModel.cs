using System;

namespace Dalel.ViewModels
{
    public class BookingVehicleDetailsViewModel
    {
        public int Id { get; set; }
        public string PickupLocation { get; set; }
        public string DropoffLocation { get; set; }
        public decimal SuggestedPrice { get; set; }
        public string BookingStatus { get; set; }
        public int PassengersNo { get; set; }
        public DateTime StartedDateTime { get; set; }
        public DateTime EndedDateTime { get; set; }
        public string ClientName { get; set; }  // اسم العميل
        public string ClientEmail { get; set; } // بريد العميل الإلكتروني
    }
}

