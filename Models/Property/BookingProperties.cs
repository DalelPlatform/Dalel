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
    public class BookingProperties
    {
        public int Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public float Price { get; set; }
        public BookingStatus Status { get; set; } // int
        public int PropertyId { get; set; } // fk Properties
        public int ClientId { get; set; } // fk Clients.userid 

        //relations
        public Properties Properties { get; set; }
        public Clients Clients { get; set; }
        public ICollection<PaymentProperties> PaymentProperties { get; set; }
        public ICollection<ReviewProperties> ReviewProperties { get; set; }
    }

    public class BookingPropertiesConfiguration : IEntityTypeConfiguration<BookingProperties>
    {
        public void Configure(EntityTypeBuilder<BookingProperties> builder)
        {
            builder.HasKey(bp => bp.Id);
            builder.Property(bp => bp.Price).HasColumnType("decimal(18,2)");

            //relations
            builder.HasOne(bp => bp.Properties)
                .WithMany(p => p.BookingProperties)
                .HasForeignKey(bp => bp.PropertyId);

            builder.HasOne(bp => bp.Clients)
                .WithMany(c => c.BookingProperties)
                .HasForeignKey(bp => bp.ClientId);


        }
    }
}
