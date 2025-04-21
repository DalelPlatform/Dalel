using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels.Restaurant;
using Microsoft.IdentityModel.Tokens;
using Models.Enums;
using Models.Restaurant;

namespace Dalel.ViewModels
{
    public static class PaymentRestaurantOrderExt
    {
        public static PaymentRestaurantOrderDetailsVM ToDetailsViewModel(this PaymentRestaurantOrder paymentRestaurantOrder)
        {
            return new PaymentRestaurantOrderDetailsVM
            {
                Id = paymentRestaurantOrder.Id,
                Amount = paymentRestaurantOrder.Amount,
                AmountPaid = paymentRestaurantOrder.AmountPaid,
                CommissionDeducted = paymentRestaurantOrder.CommissionDeducted,
                CodeApplied = paymentRestaurantOrder.CodeApplied,
                PaymentType = paymentRestaurantOrder.PaymentType,
                PaymentStatus = paymentRestaurantOrder.PaymentStatus,
                TransactionDateTime = paymentRestaurantOrder.TransactionDateTime,
                RestaurantOrderId = paymentRestaurantOrder.RestaurantOrderId
            };
        }


        public static PaymentRestaurantOrder ToModel(this PaymentRestaurantOrderDetailsVM paymentRestaurantOrder)
        {
            return new PaymentRestaurantOrder
            {
                Id = paymentRestaurantOrder.Id,
                Amount = paymentRestaurantOrder.Amount,
                AmountPaid = paymentRestaurantOrder.AmountPaid,
                CommissionDeducted = paymentRestaurantOrder.CommissionDeducted,
                CodeApplied = paymentRestaurantOrder.CodeApplied,
                PaymentType = paymentRestaurantOrder.PaymentType,
                PaymentStatus = paymentRestaurantOrder.PaymentStatus,
                TransactionDateTime = paymentRestaurantOrder.TransactionDateTime,
                RestaurantOrderId = paymentRestaurantOrder.RestaurantOrderId
            };
        }



     public static PaymentRestaurantOrder ToEditModel(this AddPaymentRestaurantOrderVM EditModel, PaymentRestaurantOrder oldModel)
{
    oldModel.Amount = EditModel.Amount > 0
        ? EditModel.Amount
        : oldModel.Amount;

    oldModel.AmountPaid = EditModel.AmountPaid > 0
        ? EditModel.AmountPaid
        : oldModel.AmountPaid;

    oldModel.CommissionDeducted = EditModel.CommissionDeducted.HasValue && EditModel.CommissionDeducted > 0
        ? EditModel.CommissionDeducted
        : oldModel.CommissionDeducted;

    oldModel.CodeApplied = !string.IsNullOrEmpty(EditModel.CodeApplied)
        ? EditModel.CodeApplied
        : oldModel.CodeApplied;

    oldModel.PaymentType = Enum.IsDefined(typeof(PaymentMethod), EditModel.PaymentType)
        ? EditModel.PaymentType
        : oldModel.PaymentType;

    oldModel.PaymentStatus = Enum.IsDefined(typeof(PaymentStatus), EditModel.PaymentStatus)
        ? EditModel.PaymentStatus
        : oldModel.PaymentStatus;

    return oldModel;
}



    }

}
