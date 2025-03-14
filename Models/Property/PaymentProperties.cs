using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Property.Enums;
using Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Models.Property
{
    public class PaymentProperties
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public PaymentType PaymentType { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public string ClientId { get; set; } // fk client.userid
        public int BookingPropertyId { get; set; } // fk BookingProperties.Id
        public bool IsDeleted { get; set; }


        //relations
        public virtual Client? Client { get; set; }
        public virtual BookingProperties BookingProperties { get; set; }
    }

    public class PaymentPropertiesConfiguration : IEntityTypeConfiguration<PaymentProperties>
    {
        public void Configure(EntityTypeBuilder<PaymentProperties> builder)
        {
            builder.HasKey(pp => pp.Id);
            builder.Property(pp => pp.Amount).HasColumnType("decimal(18,2)");
            //relations
            builder.HasOne(pp => pp.Client)
                .WithMany(c => c.PaymentProperties)
                .HasForeignKey(pp => pp.ClientId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(pp => pp.BookingProperties)
                .WithMany(bp => bp.PaymentProperties)
                .HasForeignKey(pp => pp.BookingPropertyId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
