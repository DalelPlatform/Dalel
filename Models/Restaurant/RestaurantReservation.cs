using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Restaurant.Enums;
using Models.User;

namespace Models.Restaurant
{
    public class RestaurantReservation
    {
        public int Id { get; set; }
        public string Comments { get; set; }

        public float Rating { get; set; }
        public DateTime ModificationDateTime { get; set; }

        public string? TableNumber { get; set; }

        public StatusOfReservations ReervationStatus { get; set; }

        public int RestaurantId { get; set; } //fk

        public string ClientId { get; set; }//fk


        //Relations : 
        public virtual Restaurant Restaurant { get; set; }
        public virtual Client Client {  get; set; }           
    }

    public class RestaurantReervationConfiguration : IEntityTypeConfiguration<RestaurantReservation>
    {
        public void Configure(EntityTypeBuilder<RestaurantReservation> builder)
        {
            builder.HasKey(restreervations => restreervations.Id);
            builder.Property(restreervations => restreervations.ModificationDateTime).HasDefaultValueSql("GetDate()");
            builder.Property(restreervations => restreervations.TableNumber).HasColumnType("NVARCHAR(100)").IsRequired(false);
            builder.Property(restreervations => restreervations.ReervationStatus).HasDefaultValue(StatusOfReservations.Panding);
            builder.Property(restreervations => restreervations.Comments).HasColumnType("NVARCHAR(max)");

            builder.HasOne(p => p.Client)
            .WithMany(p => p.RestaurantReservations)
            .HasForeignKey(p => p.ClientId)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Restaurant)
            .WithMany(p => p.RestaurantReservations)
            .HasForeignKey(p => p.RestaurantId)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
