using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.HomeChef;
using Models.Restaurant;

namespace Models.User
{
    public class Clients
    {
        public string UserId { get; set; } //fk & pk

        //Relations 

        #region Restaurant
        public AspDotNetUsers AspDotNetUsers { get; set; }
        public ICollection<RestaurantOrders> restaurantOrders { get; set; }
        public ICollection<PaymentRestaurantOrders> paymentRestaurantOrders { get; set; }

        public ICollection<RestaurantReervations> restaurantReervations { get; set; }

        public ReviewRestaurantOrders reviewRestaurantOrders { get; set; }
        #endregion


        #region HomeChef
        public ICollection<HomeChefOrders> homeChefOrders { get; set; }

        public ICollection<PaymentHomeChefOrders> paymentHomeChefOrders { get; set; }

        public ReviewHomeChefOrders reviewHomeChefOrders { get;set; }
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
        }
    }
}
