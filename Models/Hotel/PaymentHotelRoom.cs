using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.Enums;
using Models.User;

namespace Models.Hotel
{
    public class PaymentHotelRoom
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal? CommissionDeducted { get; set; }
        public string? CodeApplied { get; set; }
        public PaymentMethod PaymentMethod { get; set; } // e.g. cash, PayPal, Stripe
        public PaymentStatus PaymentStatus { get; set; } // e.g. pending, completed
        public DateTime TransactionDateTime { get; set; }
        public int BookingHotelRoomId { get; set; }
        public int ClientId { get; set; }
        public string Status { get; set; }
        public int HotelId { get; set; }
        public virtual BookingHotelRoom BookingHotelRoom { get; set; }
        public virtual Client Client { get; set; }

        public virtual Hotel Hotel { get; set; }




    }

    public class PaymentHotelRoomConfiguration : IEntityTypeConfiguration<PaymentHotelRoom>
    {
        public void Configure(EntityTypeBuilder<PaymentHotelRoom> builder)
        {
            builder.ToTable("PaymentHotelRooms");
            builder.HasKey(phr => phr.Id);

            builder.HasOne(phr => phr.BookingHotelRoom)
                   .WithOne(bhr => bhr.PaymentHotelRoom)
                   .HasForeignKey<PaymentHotelRoom>(phr => phr.BookingHotelRoomId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
