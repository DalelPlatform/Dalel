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

            // ضبط العلاقة One-to-One مع BookingVehicle
            builder.HasOne(rv => rv.BookingVehicle)
                   .WithOne(bv => bv.Review) // BookingVehicle لديه فقط Review واحد
                   .HasForeignKey<ReviewVehicle>(rv => rv.BookingVehicleId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
