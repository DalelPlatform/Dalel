using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.HomeChef;
using Models.HomeService;
using Models.Driver;
using Models.Property;
using Models.Restaurant;
using System.Collections;
using Models.Agency;

namespace Models.User
{
    public class Client
    {
        public string UserId { get; set; } //fk & pk
        public virtual AppUser User { get; set; }

        //Relations 

        #region Restaurant

        public virtual ICollection<RestaurantOrder> RestaurantOrder { get; set; }
        public virtual ICollection<PaymentRestaurantOrder> PaymentRestaurantOrder { get; set; }
        public virtual ICollection<RestaurantReervation> RestaurantReervations { get; set; }
        public virtual ReviewRestaurantOrder ReviewRestaurantOrder { get; set; }
        #endregion

        #region Property

        public ICollection<BookingProperties> BookingProperties { get; set; }
        public ICollection<PaymentProperties> PaymentProperties { get; set; }
        public ICollection<ReviewProperties> ReviewProperties { get; set; }

        #endregion

        #region HomeChef
        public virtual ICollection<HomeChefOrder> HomeChefOrder { get; set; }

        public virtual ICollection<PaymentHomeChefOrder> PaymentHomeChefOrder { get; set; }

        public virtual ReviewHomeChefOrder ReviewHomeChefOrder { get;set; }
        #endregion



        #region Driver
        public ICollection<BookingVehicle> bookingVehicles { get; set; }

        public ICollection<PaymentVehicle> paymentVehicles { get; set; }
        public ReviewVehicle reviewVehicle { get; set; }

        #endregion
        #region Agency
        public ICollection <PackageBooking> PackageBookings { get; set; }
        public ICollection <Agency_CustomerInquiry> Agency_CustomerInquiries { get; set; }
        #endregion


        public ICollection<ServiceQuaries> ServiceQuaries { get; set; }
        public ICollection<ServiceProviderPayment> ServiceProviderPayments { get; set; }

        public ICollection<ServiceProviderReview> ServiceProviderReviews { get; set; }


    }


    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(Client => Client.UserId);



            #region Restaurant
            //Relation between Clients & RestaurantOrders  one to many
            builder.HasMany(restorder => restorder.RestaurantOrder)
                .WithOne(client => client.Client)
                .HasForeignKey(restorder => restorder.ClientId);


            //Relation between Clients & PaymentRestaurantOrders  one to many
            builder.HasMany(payrestorder => payrestorder.PaymentRestaurantOrder)
                .WithOne(client => client.Client)
                .HasForeignKey(payrestorder => payrestorder.ClientId)
                .OnDelete(DeleteBehavior.NoAction);


            //Relation between Clients & RestaurantReervations  one to many
            builder.HasMany(restreervation => restreervation.RestaurantReervations)
                .WithOne(client => client.Client)
                .HasForeignKey(restreervation => restreervation.ClientId);




            //Relation between Clients & ReviewRestaurantOrders  (one to many)
            builder.HasOne(reviewrestorder => reviewrestorder.ReviewRestaurantOrder)
                .WithOne(client => client.Client)
                .HasForeignKey<ReviewRestaurantOrder>(reviewrestorder => reviewrestorder.ClientId);

            #endregion

            #region HomeChef
            //Relation between Clients & HomeChefOrders (one to many)
            builder.HasMany(homecheforder => homecheforder.HomeChefOrder)
                .WithOne(client => client.Client)
                .HasForeignKey(homecheforder => homecheforder.ClientId);


            //Relation between Clients & PaymentHomeChefOrders (one to many)
            builder.HasMany(payhomecheforder => payhomecheforder.PaymentRestaurantOrder)
                .WithOne(client => client.Client)
                .HasForeignKey(payhomecheforder => payhomecheforder.ClientId)
                .OnDelete(DeleteBehavior.NoAction);

            //Relation between Clients & ReviewHomeChefOrders (one to one)
            builder.HasOne(reviewhomecheforder => reviewhomecheforder.ReviewHomeChefOrder)
                .WithOne(client => client.Client)
                .HasForeignKey<ReviewHomeChefOrder>(reviewhomecheforder => reviewhomecheforder.ClientId);


            #endregion

            // relation between Clients & BookingVehicle (one to many)  
            builder.HasMany(bookingvehicle => bookingvehicle.bookingVehicles)
                .WithOne(client => client.Client).HasForeignKey(bookingvehicle => bookingvehicle.ClientId);


        }
    }
}