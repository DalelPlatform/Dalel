using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public class PaymentPropertiesDetailsVM
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal? CommissionDeducted { get; set; }
        public string? CodeApplied { get; set; }
    }
}
