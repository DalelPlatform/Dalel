using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.HomeChef.Enums;
using Models.Restaurant;
using Models.User;

namespace Models.HomeChef
{
    public class PaymentHomeChefOrder
    {
        
         public int Id { get; set; }
         public float Amount { get; set; }
         public decimal AmountPaid { get; set; }

         public decimal CommissionDeducted { get; set; }

         public string CodeApplied { get; set; }
         public HomeChefPaymentType PaymentType { get; set; }

         public HomeChefStatusOfPaymentOrder PaymentOrderStatus { get; set; }

         public DateTime TransactionDateTime { get; set; }

         public string ClientId { get; set; } //fk

         public int HomeChefOrderId { get; set; } //fk

        //Relations :

        public virtual Client Client { get; set; }

        public virtual HomeChefOrder HomeChefOrder { get; set; }
     }

    public class PaymentHomeChefOrderConfiguration : IEntityTypeConfiguration<PaymentHomeChefOrder>
    {
        public void Configure(EntityTypeBuilder<PaymentHomeChefOrder> builder)
        {
            builder.HasKey(payhomecheforder => payhomecheforder.Id);
            builder.Property(payhomecheforder => payhomecheforder.CodeApplied).HasColumnType("NVARCHAR(50)");
            builder.Property(payhomecheforder => payhomecheforder.PaymentType).HasDefaultValue("paypal");
            builder.Property(payhomecheforder => payhomecheforder.PaymentOrderStatus).HasDefaultValue("panding");






        }
    }
}
