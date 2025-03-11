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
    public class ReviewVehicle
    {
        public int Id { get; set; }

        public string Comments { get; set; }

        public decimal Rating { get; set; } // تغيير النوع إلى decimal(2,1) لضمان دقة التقييم

        public DateTime ModificationDateTime { get; set; }

        // علاقة Many-to-One مع Client
        public string ClientId { get; set; }
        public virtual Client Client { get; set; }

        // علاقة One-to-One مع BookingVehicle
        public int BookingVehicleId { get; set; }
        public virtual BookingVehicle BookingVehicle { get; set; }
    }
    public class ReviewVehicleConfiguration : IEntityTypeConfiguration<ReviewVehicle>
    {
        public void Configure(EntityTypeBuilder<ReviewVehicle> builder)
        {
            // تحديد المفتاح الأساسي
            builder.HasKey(rv => rv.Id);

            // ضبط خصائص الحقول
            builder.Property(rv => rv.Rating).HasColumnType("decimal(2,1)").IsRequired();
            builder.Property(rv => rv.ModificationDateTime).IsRequired();

            // ضبط العلاقة Many-to-One مع Client
            builder.HasOne(rv => rv.Client)
                   .WithMany(re => re.Reviews).HasForeignKey(rv => rv.ClientId)
                   .OnDelete(DeleteBehavior.Cascade);

            // ضبط العلاقة One-to-One مع BookingVehicle
            builder.HasOne(rv => rv.BookingVehicle)
                   .WithOne(bv => bv.Review) // BookingVehicle لديه فقط Review واحد
                   .HasForeignKey<ReviewVehicle>(rv => rv.BookingVehicleId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
