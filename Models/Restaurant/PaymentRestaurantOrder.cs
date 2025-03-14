using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Driver;
using Models.Restaurant.Enums;
using Models.User;

namespace Models.Restaurant
{
    public class PaymentRestaurantOrder
    {
        public int Id { get; set; }
        public float Amount { get; set; }  
        public decimal AmountPaid { get; set; }

        public decimal CommissionDeducted { get; set; }

        public string CodeApplied { get; set; }
        public TypeOfPayment PaymentType { get; set; }

        public StatusOfPaymentOrder PaymentOrderStatus { get; set; }

        public DateTime TransactionDateTime { get; set; }

        public string ClientId { get; set; } //fk

        public int RestaurantOrderId { get; set; } //fk

        //Relations : 

        public virtual Client Client { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }


    public class PaymentRestaurantOrdersConfiguration : IEntityTypeConfiguration<PaymentRestaurantOrder>
    {
        public void Configure(EntityTypeBuilder<PaymentRestaurantOrder> builder)
        {
            builder.HasKey(payrestorder => payrestorder.Id);
            builder.Property(payrestorder => payrestorder.CodeApplied).HasColumnType("NVARCHAR(50)");
            builder.Property(payrestorder => payrestorder.PaymentType).HasDefaultValue("paypal");
            builder.Property(payrestorder => payrestorder.PaymentOrderStatus).HasDefaultValue("panding");






        }
    }
}
