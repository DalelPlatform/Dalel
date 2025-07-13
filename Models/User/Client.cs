using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.HomeChef;
using Models.HomeService;
using Models.Driver;
using Models.Property;
using Models.Restaurant;
using Models.Agency;
using Models.Hotel;

namespace Models.User
{
    public class Client
    {
        public string UserId { get; set; } //fk & pk
        public virtual AppUser User { get; set; }

        //Relations 

        #region Restaurant
        public virtual ICollection<RestaurantCartItem> RestaurautCartItems { get; set; }

        public virtual ICollection<RestaurantOrder> RestaurantOrders { get; set; }
        public virtual ICollection<RestaurantReservation> RestaurantReservations { get; set; }
        #endregion

        #region Property
        public virtual ICollection<BookingProperties> BookingProperties { get; set; }
        #endregion

        #region Hotel
        public virtual ICollection<BookingHotelRoom> BookingHotelRooms { get; set; }
        #endregion

        #region HomeChef
        public virtual ICollection<HomeChefOrder> HomeChefOrders { get; set; }
        #endregion

        #region Driver
        public virtual ICollection<BookingVehicle> BookingVehicles { get; set; }
        #endregion

        #region HomeService
        public virtual ICollection<ServiceQuaries>? ServiceQuaries { get; set; }
        public virtual ICollection<ServiceChat>? Chats { get; set; }
        public virtual ICollection<ServiceRequest> ServiceRequests { get; set; }
        public virtual ICollection<ServiceProviderReview> ServiceProviderReviews { get; set; }
        #endregion

        #region Agency
        public virtual ICollection <PackageBooking> PackageBookings { get; set; }
        public virtual ICollection <AgencyCustomerInquiry> Inquiries { get; set; }
        #endregion

    }


    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(Client => Client.UserId);
            builder
                .HasOne(a => a.User)
                .WithOne(a => a.Client)
                .HasForeignKey<Client>(a => a.UserId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}