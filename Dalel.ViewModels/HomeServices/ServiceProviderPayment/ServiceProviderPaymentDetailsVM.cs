using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public class ServiceProviderPaymentDetailsVM
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public string ServiceProviderId { get; set; }
        public string ServiceProviderName { get; set; }
        public double Amount { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}
