using Models.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public static class PaymentPropertiesExt
    {
        public static PaymentPropertiesDetailsVM ToDetailsViewModel(this PaymentProperties paymentProperties)
        {
            return new PaymentPropertiesDetailsVM
            {
                Id = paymentProperties.Id,
                Amount = paymentProperties.Amount,
                PaymentMethod = paymentProperties.PaymentMethod,
                PaymentStatus = paymentProperties.PaymentStatus,
                TransactionDateTime = paymentProperties.TransactionDateTime,
                AmountPaid = paymentProperties.AmountPaid,
                CommissionDeducted = paymentProperties.CommissionDeducted,
                CodeApplied = paymentProperties.CodeApplied
            };
        }
    }
}
