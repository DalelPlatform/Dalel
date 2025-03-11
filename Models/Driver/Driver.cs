using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Driver
{
    public class Driver
    {
        public int  Id { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public bool IsActive { get; set; }

        // علاقة One-to-One مع Vehicle
        public virtual Vehicle Vehicle { get; set; }

        // علاقة One-to-Many مع CarProposal
        public virtual ICollection<CarProposal> CarProposals { get; set; } = new HashSet<CarProposal>();
        
    }
    public class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            // تحديد المفتاح الأساسي
            builder.HasKey(d => d.Id);

            // إضافة قيود على الحقول
            builder.Property(d => d.FullName).IsRequired().HasMaxLength(100);
            builder.Property(d => d.PhoneNumber).IsRequired().HasMaxLength(20);
            builder.Property(d => d.Email).IsRequired().HasMaxLength(150);

            // علاقة One-to-One مع Vehicle
            builder.HasOne(d => d.Vehicle)
                   .WithOne(v => v.Driver)
                   .HasForeignKey<Vehicle>(v => v.DriverId)  // تحديد المفتاح الأجنبي في Vehicle
                   .OnDelete(DeleteBehavior.Cascade);

            // علاقة One-to-Many مع CarProposal
            builder.HasMany(d => d.CarProposals)
                   .WithOne(cp => cp.Driver)
                   .HasForeignKey(cp => cp.DriverId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
