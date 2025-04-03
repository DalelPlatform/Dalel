using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Enums;
using Models.User;

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
        public string ClientId { get; set; } // fk Clients.userid 

        //relations
        public virtual Properties Properties { get; set; }
        public virtual Client Client { get; set; }
        public virtual PaymentProperties PaymentProperties { get; set; }
        public virtual ReviewProperties ReviewProperties { get; set; }
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
                .HasForeignKey(bp => bp.PropertyId).OnDelete(DeleteBehavior.NoAction); ;

            builder.HasOne(bp => bp.Client)
                .WithMany(c => c.BookingProperties)
                .HasForeignKey(bp => bp.ClientId).OnDelete(DeleteBehavior.NoAction); ;


        }
    }
}
