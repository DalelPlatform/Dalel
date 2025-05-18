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
    public class VehicleImage
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
    public class VehicleImageConfiguration : IEntityTypeConfiguration<VehicleImage>
    {
        public void Configure(EntityTypeBuilder<VehicleImage> builder)
        {
            // تحديد المفتاح الأساسي
            builder.HasKey(vi => vi.Id);

            // إضافة قيود على الحقول
            builder.Property(vi => vi.Image)
                   .IsRequired()
                   .HasMaxLength(255); // يمكنك تغيير الطول حسب الحاجة

            // تحديد العلاقة مع `Vehicle`
            builder.HasOne(vi => vi.Vehicle)
                   .WithMany(v => v.VehicleImages) // يجب التأكد من أن `Vehicle` يحتوي على قائمة `VehicleImages`
                   .HasForeignKey(vi => vi.VehicleId)
                   .OnDelete(DeleteBehavior.NoAction); // عند حذف الـ Vehicle، يتم حذف الصور المرتبطة به
        }
    }
}
