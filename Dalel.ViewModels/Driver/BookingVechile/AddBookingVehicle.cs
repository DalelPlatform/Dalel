using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels.Driver.BookingVechile
{
    public class AddBookingVehicle
    {
        public string PickupLocation { get; set; }
        public string DropoffLocation { get; set; }
        public decimal SuggestedPrice { get; set; }
        public BookingStatus BookingStatus { get; set; }
        public bool IsDeleted { get; set; }
        public int PassengersNo { get; set; }
        public DateTime StartedDateTime { get; set; }
        public DateTime EndedDateTime { get; set; }
        public string ClientId { get; set; }
    }

}
