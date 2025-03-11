using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.HomeChef;
using Models.HomeService;
using Models.Driver;
using Models.Property;
using Models.Restaurant;

namespace Models.User
{
    public class Clients
    {
        public string UserId { get; set; } //fk & pk

        //Relations 

        #region Restaurant
        public AspDotNetUsers AspDotNetUsers { get; set; }

        public ICollection<BookingProperties> BookingProperties { get; set; }
        public ICollection<PaymentProperties> PaymentProperties { get; set; }
        public ICollection<ReviewProperties> ReviewProperties { get; set; }
        public ICollection<RestaurantOrders> restaurantOrders { get; set; }
        public ICollection<PaymentRestaurantOrders> paymentRestaurantOrders { get; set; }


        public ICollection<RestaurantReervations> restaurantReervations { get; set; }
        public ICollection<ServiceQuaries> serviceQuaries { get; set; }
        public ICollection<ServiceProviderPayment> serviceProviderPayments { get; set; }
        public ICollection<ServiceProviderBooking> serviceProviderBookings { get; set; }
        public ICollection<ServiceProviderReview> serviceProviderReviews { get; set; }


        public ReviewRestaurantOrders reviewRestaurantOrders { get; set; }
        #endregion


        #region HomeChef
        public ICollection<HomeChefOrders> homeChefOrders { get; set; }

        public ICollection<PaymentHomeChefOrders> paymentHomeChefOrders { get; set; }

        public ReviewHomeChefOrders reviewHomeChefOrders { get;set; }
        #endregion
        #region Driver
        public ICollection<BookingVehicle> bookingVehicles { get; set; }

        public ICollection<PaymentVehicle> paymentVehicles { get; set; }
        public ReviewVehicle reviewVehicle { get; set; }
        
        #endregion

    }

    public class ClientsConfiguration : IEntityTypeConfiguration<Clients>
    {
        public void Configure(EntityTypeBuilder<Clients> builder)
        {
            builder.HasKey(client => client.UserId);

            


            //Relation between Clients & RestaurantOrders  one to many
            builder.HasMany(restorder => restorder.restaurantOrders)
                .WithOne(client => client.clients)
                .HasForeignKey(restorder => restorder.ClientId);


            //Relation between Clients & PaymentRestaurantOrders  one to many
            builder.HasMany(payrestorder => payrestorder.paymentRestaurantOrders)
                .WithOne(client => client.clients)
                .HasForeignKey(payrestorder => payrestorder.ClientId);


            //Relation between Clients & RestaurantReervations  one to many
            builder.HasMany(restreervation => restreervation.restaurantReervations)
                .WithOne(client => client.clients)
                .HasForeignKey(restreervation => restreervation.ClientId);


            //Relation between Clients & RestaurantReervations  (one to many)
            builder.HasMany(restreervation => restreervation.restaurantReervations)
                .WithOne(client => client.clients)
                .HasForeignKey(restreervation => restreervation.ClientId);


            //Relation between Clients & ReviewRestaurantOrders  (one to many)
            builder.HasOne(reviewrestorder => reviewrestorder.reviewRestaurantOrders)
                .WithOne(client => client.clients)
                .HasForeignKey<ReviewRestaurantOrders>(reviewrestorder => reviewrestorder.ClientId);


            //Relation between Clients & HomeChefOrders (one to many)
            builder.HasMany(homecheforder => homecheforder.homeChefOrders)
                .WithOne(client => client.clients)
                .HasForeignKey(homecheforder => homecheforder.ClientId);


            //Relation between Clients & PaymentHomeChefOrders (one to many)
            builder.HasMany(payhomecheforder => payhomecheforder.paymentRestaurantOrders)
                .WithOne(client => client.clients)
                .HasForeignKey(payhomecheforder => payhomecheforder.ClientId);

            //Relation between Clients & ReviewHomeChefOrders (one to one)
            builder.HasOne(reviewhomecheforder => reviewhomecheforder.reviewHomeChefOrders)
                .WithOne(client => client.clients)
                .HasForeignKey<ReviewHomeChefOrders>(reviewhomecheforder => reviewhomecheforder.ClientId);

            // relation between Clients & BookingVehicle (one to many)  

            builder.HasMany(bookingvehicle => bookingvehicle.bookingVehicles)
                .WithOne(client => client.Client).HasForeignKey(bookingvehicle => bookingvehicle.ClientId);
        }
    }
}