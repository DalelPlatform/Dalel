using Microsoft.EntityFrameworkCore;
using Models.Enums;
using Models.User;

namespace Models.Restaurant
{
    public class Restaurant
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public int NumberOfRooms { get; set; }

        public int BuildingNo { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string Street { get; set; }
        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public string PhoneNumber { get; set; }

        public bool CancelationOptions { get; set; }

        public float CancelationCharges     { get; set; }

        //public RestaurantType? RestaurantType { get; set; }

        public VerificationStatus VerificationStatus { get; set; } //int 

        public DateTime ModificationDate { get; set; }

        public bool IsDeleted {  get; set; }

        public string OwnerId { get; set; } //fk


        //Relations :

        public virtual RestaurantOwner RestaurantOwner { get; set; }
        public virtual ICollection<RestaurantImage> RestaurantImages { get; set; }

        public virtual ICollection<RestaurantMenuItem> RestaurantMenuItem { get; set; }

        public virtual ICollection<RestaurantReservation> RestaurantReservations { get; set; }

    }

    public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Restaurant> builder)
        {
            builder.HasKey(rest => rest.Id);
            builder.Property(rest => rest.IsDeleted).HasDefaultValue(false);
            builder.Property(rest =>rest.Description).HasColumnType("NVARCHAR(MAX)").HasDefaultValue("empty");
            builder.Property(rest => rest.NumberOfRooms).IsRequired();
            builder.Property(rest => rest.BuildingNo).IsRequired();
            builder.Property(rest => rest.Address).HasDefaultValue("empty").HasColumnType("NVARCHAR(50)");
            builder.Property(rest => rest.City).HasDefaultValue("empty").HasColumnType("NVARCHAR(50)");
            builder.Property(rest => rest.Region).HasDefaultValue("empty").HasColumnType("NVARCHAR(50)");
            builder.Property(rest => rest.Street).HasDefaultValue("empty").HasColumnType("NVARCHAR(50)");
            builder.Property(rest => rest.PhoneNumber).HasDefaultValue("empty").HasColumnType("NVARCHAR(50)");
            builder.Property(rest => rest.CancelationOptions).HasDefaultValue(false);
            builder.Property(rest => rest.VerificationStatus).HasDefaultValue(VerificationStatus.Pending);


            //Relation between Restaurants & RestaurantOwners (one to one) 
            builder.HasOne(restowner => restowner.RestaurantOwner)
                .WithOne(rest => rest.Restaurant)
                .HasForeignKey<Restaurant> (rest => rest.OwnerId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
