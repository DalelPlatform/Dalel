using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public class AddCarProposal
    {
        public decimal Price { get; set; }
        public ProposalStatus ProposalStatus { get; set; }
        public bool IsAccepted { get; set; }
        public decimal SuggestedPrice { get; set; }
        public DateTime StartedDateTime { get; set; }
        public string DriverId { get; set; }
        public int BookingVehicleId { get; set; }
    }

}
