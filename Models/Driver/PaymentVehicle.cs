using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Models.Driver
{
    public class PaymentVehicle
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public int Type { get; set; }

        public int Status { get; set; }

        public DateTime TransactionDateTime { get; set; }

        // علاقة Many-to-One مع Client
        public string ClientId { get; set; }
        public virtual Client Client { get; set; }

        // علاقة One-to-One مع BookingVehicle
        public int BookingVehicleId { get; set; }
        public virtual BookingVehicle BookingVehicle { get; set; }
    }
    public class PaymentVehicleConfiguration : IEntityTypeConfiguration<PaymentVehicle>
    {
        public void Configure(EntityTypeBuilder<PaymentVehicle> builder)
        {
            // تحديد المفتاح الأساسي
            builder.HasKey(pv => pv.Id);

            // ضبط خصائص الحقول
            builder.Property(pv => pv.Amount).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(pv => pv.TransactionDateTime).IsRequired();

            // ضبط العلاقة Many-to-One مع Client
            builder.HasOne(pv => pv.Client)
                   .WithMany(c=>c.Payments)
                   .HasForeignKey(pv => pv.ClientId)
                   .OnDelete(DeleteBehavior.Cascade);

            // ضبط العلاقة One-to-One مع BookingVehicle
            builder.HasOne(pv => pv.BookingVehicle)
                   .WithOne(bv => bv.Payment) // BookingVehicle لديه فقط Payment واحد
                   .HasForeignKey<PaymentVehicle>(pv => pv.BookingVehicleId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
