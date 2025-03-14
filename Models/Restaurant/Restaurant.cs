using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models.Restaurant.Enums;
using Models.User;

namespace Models.Restaurant
{
    public class Restaurant
    {
        public int Id { get; set; }
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

        public StatusOfRestaurantAcceptance RestaurantStatus { get; set; } //int 

        public DateTime ModificationDate { get; set; }

        public bool IsDeleted {  get; set; }

        public string OwnerId { get; set; } //fk


        //Relations :

        public virtual RestaurantOwner RestaurantOwner { get; set; }
        public virtual ICollection<RestaurantImage> RestaurantImage { get; set; }

        public virtual ICollection<RestaurantMenuItem> RestaurantMenuItem { get; set; }

        public virtual ICollection<RestaurantOrder> RestaurantOrder { get; set; }

        public virtual ICollection<PaymentRestaurantOrder> PaymentRestaurantOrder { get; set; }

        public virtual ICollection<RestaurantReervation> RestaurantReervation { get; set; }

    }

    public class RestaurantsConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Restaurant> builder)
        {
            builder.HasKey(rest => rest.Id);
            builder.Property(rest => rest.IsDeleted).HasDefaultValue(false);
            builder.Property(rest =>rest.Description).HasColumnType("NVARCHAR(250)").HasDefaultValue("empty");
            builder.Property(rest => rest.NumberOfRooms).IsRequired();
            builder.Property(rest => rest.BuildingNo).IsRequired();
            builder.Property(rest => rest.Address).HasDefaultValue("empty").HasColumnType("NVARCHAR(50)");
            builder.Property(rest => rest.City).HasDefaultValue("empty").HasColumnType("NVARCHAR(50)");
            builder.Property(rest => rest.Region).HasDefaultValue("empty").HasColumnType("NVARCHAR(50)");
            builder.Property(rest => rest.Street).HasDefaultValue("empty").HasColumnType("NVARCHAR(50)");
            builder.Property(rest => rest.PhoneNumber).HasDefaultValue("empty").HasColumnType("NVARCHAR(50)");
            builder.Property(rest => rest.CancelationOptions).HasDefaultValue("false");
            builder.Property(rest => rest.RestaurantStatus).HasColumnType("NVARCHAR(50)").HasDefaultValue("pending");
            builder.Property(rest => rest.OwnerId).HasColumnType("NVARCHAR(150)");


            //Relation between Restaurants & RestaurantOwners (one to one) 
            builder.HasOne(restowner => restowner.RestaurantOwner)
                .WithOne(rest => rest.Restaurant)
                .HasForeignKey<Restaurant> (rest => rest.OwnerId);

            //Relation between Restaurants & RestaurantImages (one to many)
            builder.HasMany(restimg => restimg.RestaurantImage)
                .WithOne(rest => rest.Restaurant)
                .HasForeignKey(restimg => restimg.RestaurantId)
                .OnDelete(DeleteBehavior.NoAction);

            //Relation between Restaurants & RestaurantMenuItems (one to many)
            builder.HasMany(restmenuitem => restmenuitem.RestaurantMenuItem)
                .WithOne(rest => rest.Restaurant)
                .HasForeignKey(restmenuitem => restmenuitem.RestaurantId)
                .OnDelete(DeleteBehavior.NoAction);


            //Relation between Restaurants & RestaurantOrders (one to many)
            builder.HasMany(restorder => restorder.RestaurantOrder)
                .WithOne(rest => rest.Restaurant)
                .HasForeignKey(restorder => restorder.RestaurantId);



            //Relation between Restaurants & PaymentRestaurantOrders  (one to many)
            builder.HasMany(payrestorder => payrestorder.PaymentRestaurantOrder)
                .WithOne(rest => rest.Restaurant)
                .HasForeignKey(payrestorder => payrestorder.ClientId)
                .OnDelete(DeleteBehavior.NoAction);


            //Relation between Restaurants & RestaurantReervations  (one to many)
            builder.HasMany(restreervation => restreervation.RestaurantReervation)
                .WithOne(rest => rest.Restaurant)
                .HasForeignKey(restreervation => restreervation.RestaurantId)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
