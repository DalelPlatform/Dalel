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

    public class Vehicle
    {
        public int Id { get; set; }

        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int ModelYear { get; set; }
        public int Seats { get; set; }
        public string LicenseNumber { get; set; }
        public string PlateNumber { get; set; }

        // علاقة Many-to-One مع Driver
        public string DriverId { get; set; }
        public virtual Driver Driver { get; set; }

        // علاقة One-to-Many مع VehicleImage
        public virtual ICollection<VehicleImage> VehicleImages { get; set; } = new List<VehicleImage>();
    }
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            // تحديد المفتاح الأساسي
            builder.HasKey(v => v.Id);

            // ضبط خصائص الحقول
            builder.Property(v => v.Type).HasMaxLength(50).IsRequired();
            builder.Property(v => v.Model).HasMaxLength(50).IsRequired();
            builder.Property(v => v.Color).HasMaxLength(30).IsRequired();
            builder.Property(v => v.LicenseNumber).HasMaxLength(20).IsRequired();
            builder.Property(v => v.PlateNumber).HasMaxLength(20).IsRequired();
            builder.Property(v => v.ModelYear).IsRequired();
            builder.Property(v => v.Seats).IsRequired();

            // ضبط العلاقة Many-to-One مع Driver
            builder.HasOne(v => v.Driver)
                   .WithOne(d => d.Vehicle) // Driver لديه سيارة واحدة فقط
                   .HasForeignKey<Vehicle>(v => v.DriverId)
                   .OnDelete(DeleteBehavior.Cascade);

            // ضبط العلاقة One-to-Many مع VehicleImage
            builder.HasMany(v => v.VehicleImages)
                   .WithOne(vi => vi.Vehicle)
                   .HasForeignKey(vi => vi.VehicleId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
