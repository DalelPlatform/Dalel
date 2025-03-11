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
    public class Restaurants
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

        public string OwnerId { get; set; } //fk


        //Relations :

        public RestaurantOwners restaurantOwners { get; set; }
        public ICollection<RestaurantImages> restaurantImages { get; set; }

        public ICollection<RestaurantMenuItems> restaurantMenuItems { get; set; }

        public ICollection<RestaurantOrders> restaurantOrders { get; set; }

        public ICollection<PaymentRestaurantOrders> paymentRestaurantOrders { get; set; }

        public ICollection<RestaurantReervations> restaurantReervations { get; set; }

    }

    public class RestaurantsConfiguration : IEntityTypeConfiguration<Restaurants>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Restaurants> builder)
        {
            builder.HasKey(rest => rest.Id);
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
            builder.HasOne(restowner => restowner.restaurantOwners)
                .WithOne(rest => rest.restaurants)
                .HasForeignKey<Restaurants> (rest => rest.OwnerId);

            //Relation between Restaurants & RestaurantImages (one to many)
            builder.HasMany(restimg => restimg.restaurantImages)
                .WithOne(rest => rest.restaurants)
                .HasForeignKey(restimg => restimg.RestaurantId);

            //Relation between Restaurants & RestaurantMenuItems (one to many)
            builder.HasMany(restmenuitem => restmenuitem.restaurantMenuItems)
                .WithOne(rest => rest.restaurants)
                .HasForeignKey(restmenuitem => restmenuitem.RestaurantId);


            //Relation between Restaurants & RestaurantOrders (one to many)
            builder.HasMany(restorder => restorder.restaurantOrders)
                .WithOne(rest => rest.restaurants)
                .HasForeignKey(restorder => restorder.RestaurantId);



            //Relation between Restaurants & PaymentRestaurantOrders  (one to many)
            builder.HasMany(payrestorder => payrestorder.paymentRestaurantOrders)
                .WithOne(rest => rest.restaurants)
                .HasForeignKey(payrestorder => payrestorder.ClientId);


            //Relation between Restaurants & RestaurantReervations  (one to many)
            builder.HasMany(restreervation => restreervation.restaurantReervations)
                .WithOne(rest => rest.restaurants)
                .HasForeignKey(restreervation => restreervation.RestaurantId);



        }
    }
}
