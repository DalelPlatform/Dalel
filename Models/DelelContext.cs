using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Agency;
using Models.Driver;
using Models.HomeChef;
using Models.HomeService;
using Models.Hotel;
using Models.Notification;
using Models.Property;
using Models.Restaurant;
using Models.User;

namespace Models
{

    public class DelelContext : IdentityDbContext<AppUser>
    {
        public DelelContext(DbContextOptions options):base(options:options) {
            

        }
        public  DbSet<Client> Client { get; set; }
        public  DbSet<Drivers> Drivers { get; set; }
        public  DbSet<User.HomeChef> HomeChefs { get; set; }
        public  DbSet<HotelOwners> HotelOwners { get; set; }
        public  DbSet<PropertyOwner> PropertyOwners { get; set; }
        public DbSet<RestaurantOwner> RestaurantOwners { get; set; }
        public DbSet<ServiceProvider> ServiceProviders { get; set; }
        public DbSet<TravelAgencyOwners> TravelAgencyOwners { get; set; }

        //Agency
        public DbSet<AgencyCustomerInquiry> AgencyCustomerInquiries { get; set; }
        public DbSet<AgencyPackage> AgencyPackages { get; set; }
        public DbSet<AgencyPromotion> AgencyPromotions { get; set; }
        public DbSet<AgencyVerificationDocument> AgencyVerificationDocuments { get; set; }
        public DbSet<PackageBooking> PackageBookings { get; set; }
        public DbSet<PackageBookingPayment> PackageBookingPayments { get; set; }
        public DbSet<PackageBookingReview> PackageBookingReviews { get; set; }
        public DbSet<PackageSchadule> PackageSchadules { get; set; }
        public DbSet<PackageStep> PackageSteps { get; set; }
        public DbSet<TravelAgencies> TravelAgencies { get; set; }

        //Driver
        public DbSet<BookingVehicle> BookingVehicles { get; set; }
        public DbSet<CarProposal> CarProposals { get; set; }
        public DbSet<PaymentVehicle> PaymentVehicles { get; set; }
        public DbSet<ReviewVehicle> ReviewVehicles { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleImage> VehicleImages { get; set; }

        //Home Chef
        public DbSet<HomeChefDelivery> HomeChefDeliveries { get; set; }
        public DbSet<HomeChefMeal> HomeChefMeals { get; set; }
        public DbSet<HomeChefMealImage> HomeChefMealImages { get; set; }
        public DbSet<HomeChefOrder> HomeChefOrders { get; set; }
        public DbSet<HomeChefOrderMeal> HomeChefOrderMeals { get; set; }
        public DbSet<PaymentHomeChefOrder> PaymentHomeChefOrders { get; set; }
        public DbSet<ReviewHomeChefOrder> ReviewHomeChefOrders { get; set; }

        //Home Services
        public DbSet<CategoryServices> CategoryServices { get; set; }
        public DbSet<ServiceProviderPayment> ServiceProviderPayments { get; set; }
        public DbSet<ServiceProviderProject> ServiceProviderProjects { get; set; }
        public DbSet<ServiceProviderPropsal> ServiceProviderPropsals { get; set; }
        public DbSet<ServiceProviderReview> ServiceProviderReviews { get; set; }
        public DbSet<ServiceProviderSchedule> ServiceProviderSchedules { get; set; }
        public DbSet<ServiceQuaries> ServiceQuaries { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<ServiceProviderProjectImages> ServiceProviderProjectImages { get; set; }
        public DbSet<ServicesNotifications> ServicesNotifications { get; set; }


        //Hotel
        public DbSet<BookingGuestInRoom> BookingGuestInRooms { get; set; }
        public DbSet<BookingHotelRoom> BookingHotelRooms { get; set; }
        public DbSet<Hotel.Hotel> Hotels { get; set; }
        public DbSet<HotelImage> HotelImages { get; set; }
        public DbSet<HotelPolicy> HotelPolicies { get; set; }
        public DbSet<HotelService> HotelServices { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<ReviewHotelRoom> ReviewHotelRooms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<RoomTypeImage> RoomTypeImages { get; set; }
        public DbSet<PaymentHotelRoom> PaymentHotelRoom { get; set; }
        public DbSet<BookingGuestInRoom> BookingGuestInRoom { get; set; }

        public DbSet<Service> Services { get; set; }

        //Property

        public DbSet<BookingProperties> BookingProperties { get; set; }
        public DbSet<PaymentProperties> PaymentProperties { get; set; }
        public DbSet<Properties> Properties { get; set; }
        public DbSet<PropertyImages> PropertyImages { get; set; }
        public DbSet<ReviewProperties> ReviewProperties { get; set; }

        //Restaurant

        public DbSet<PaymentRestaurantOrder> PaymentRestaurantOrders { get; set; }
        public DbSet<Restaurant.Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantImage> RestaurantImages { get; set; }
        public DbSet<RestaurantMenuItem> RestaurantMenuItems { get; set; }
        public DbSet<RestaurantMenuItemImage> RestaurantMenuItemImages { get; set; }
        public DbSet<RestaurantOrder> RestaurantOrders { get; set; }
        public DbSet<RestaurantOrderItem> RestaurantOrderItems { get; set; }
        public DbSet<RestaurantReservation> RestaurantReservations { get; set; }
        public DbSet<ReviewRestaurantOrder> ReviewRestaurantOrders { get; set; }
        public DbSet<Notification.Notification> notifications { get; set; }
        //

      
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // User & Client Configuration
            builder.ApplyConfiguration(new AppUserConfiguration());
            builder.ApplyConfiguration(new ClientConfiguration());
            builder.ApplyConfiguration(new DriversConfiguration());
            builder.ApplyConfiguration(new HomeChefConfiguration());
            builder.ApplyConfiguration(new HotelOwnersConfiguration());
            builder.ApplyConfiguration(new PropertyOwnerConfiguration());
            builder.ApplyConfiguration(new RestaurantOwnerConfiguration());
            builder.ApplyConfiguration(new ServiceProviderConfiguration());
            builder.ApplyConfiguration(new TravelAgencyOwnersConfigration());

            #region Agency
            builder.ApplyConfiguration(new AgencyCustomerInquiryConfigration());
            builder.ApplyConfiguration(new AgencyPackageConfigration());
            builder.ApplyConfiguration(new AgencyPromotionConfigration());
            builder.ApplyConfiguration(new AgencyVerificationDocumentConfigration());
            builder.ApplyConfiguration(new PackageBookingConfigration());
            builder.ApplyConfiguration(new PackageBookingPaymentConfigration());
            builder.ApplyConfiguration(new PackageBookingReviewConfigration());
            builder.ApplyConfiguration(new PackageSchaduleConfigration());
            builder.ApplyConfiguration(new PackageStepConfigration());
            builder.ApplyConfiguration(new TravelAgencyConfugeration());
            builder.ApplyConfiguration(new NotificationConfigration());
            #endregion

            #region Driver
            builder.ApplyConfiguration(new BookingVehicleConfiguration());
            builder.ApplyConfiguration(new CarProposalConfiguration());
            builder.ApplyConfiguration(new PaymentVehicleConfiguration());
            builder.ApplyConfiguration(new ReviewVehicleConfiguration());
            builder.ApplyConfiguration(new VehicleConfiguration());
            builder.ApplyConfiguration(new VehicleImageConfiguration());
            #endregion

            #region HomeChef
            builder.ApplyConfiguration(new HomeChefDeliveriesConfiguration());
            builder.ApplyConfiguration(new HomeChefMealConfiguration());
            builder.ApplyConfiguration(new HomeChefMealImageConfiguration());
            builder.ApplyConfiguration(new HomeChefOrderConfiguration());
            builder.ApplyConfiguration(new HomeChefOrderMealConfiguration());
            builder.ApplyConfiguration(new PaymentHomeChefOrderConfiguration());
            builder.ApplyConfiguration(new ReviewHomeChefOrderConfiguration());
            #endregion

            #region HomeService
            builder.ApplyConfiguration(new CategoryServicesConfiguration());
            builder.ApplyConfiguration(new ServiceProviderPaymentConfiguration());
            builder.ApplyConfiguration(new ServiceProviderProjectConfiguration());
            builder.ApplyConfiguration(new ServiceProviderPropsalConfiguration());
            builder.ApplyConfiguration(new ServiceProviderReviewConfiguration());
            builder.ApplyConfiguration(new ServiceProviderScheduleConfigration());
            builder.ApplyConfiguration(new ServiceQuariesConfiguration());
            builder.ApplyConfiguration(new ServiceRequestConfiguration());
            builder.ApplyConfiguration(new ServiceProviderProjectImagesConfiguration());
            builder.ApplyConfiguration(new ServicesNotificationsConfiguration());
            #endregion

            #region Hotel
            builder.ApplyConfiguration(new BookingGuestInRoomConfiguration());
            builder.ApplyConfiguration(new BookingHotelRoomConfiguration());
            builder.ApplyConfiguration(new HotelConfiguration());
            builder.ApplyConfiguration(new HotelImageConfiguration());
            builder.ApplyConfiguration(new HotelPolicyConfiguration());
            builder.ApplyConfiguration(new HotelServiceConfiguration());
            builder.ApplyConfiguration(new PaymentHotelRoomConfiguration());
            builder.ApplyConfiguration(new PolicyConfiguration());
            builder.ApplyConfiguration(new ReviewHotelRoomConfiguration());
            builder.ApplyConfiguration(new RoomConfiguration());
            builder.ApplyConfiguration(new RoomTypeConfiguration());
            builder.ApplyConfiguration(new RoomTypeImageConfiguration());
            builder.ApplyConfiguration(new ServiceConfiguration());
            #endregion

            #region Property
            builder.ApplyConfiguration(new BookingPropertiesConfiguration());
            builder.ApplyConfiguration(new PaymentPropertiesConfiguration());
            builder.ApplyConfiguration(new PropertiesConfigiruation());
            builder.ApplyConfiguration(new PropertyImagesConfiguration());
            builder.ApplyConfiguration(new ReviewPropertiesConfiguration());
            #endregion
            
            #region Restaurant 
            builder.ApplyConfiguration(new PaymentRestaurantOrderConfiguration());
            builder.ApplyConfiguration(new RestaurantConfiguration());
            builder.ApplyConfiguration(new RestaurantImageConfiguration());
            builder.ApplyConfiguration(new RestaurantMenuItemConfiguration());
            builder.ApplyConfiguration(new RestaurantMenuItemImageConfiguration());
            builder.ApplyConfiguration(new RestaurantOrderConfiguration());
            builder.ApplyConfiguration(new RestaurantOrderItemConfiguration());
            builder.ApplyConfiguration(new RestaurantReervationConfiguration());
            builder.ApplyConfiguration(new ReviewRestaurantOrderConfiguration());
            #endregion


            base.OnModelCreating(builder);
        }
    }
}
