using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels.HomeServices.ServiceRequest
{
    public class ServiceRequestDetailsVM
    {
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public string Date { get; set; }
        public RequestStatus Status { get; set; }
        public double StartPrice { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string? ImageUrl { get; set; }
        public int ProposalsCount { get; set; }
        //public PaymentStatus Payment{ get; set; }
    }
}
