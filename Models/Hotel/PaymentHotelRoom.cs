using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    public class PaymentHotelRoom
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal CommissionDeducted { get; set; }
        public string CodeApplied { get; set; }
        public int Type { get; set; } // e.g. cash, PayPal, Stripe
        public int Status { get; set; } // e.g. pending, completed
        public DateTime TransactionDateTime { get; set; }
        public string ClientId { get; set; }
        public int BookingHotelRoomId { get; set; }

        // Navigation properties
        public AspNetUser Client { get; set; }
        public BookingHotelRoom BookingHotelRoom { get; set; }
    }

    public class PaymentHotelRoomConfiguration : IEntityTypeConfiguration<PaymentHotelRoom>
    {
        public void Configure(EntityTypeBuilder<PaymentHotelRoom> builder)
        {
            builder.ToTable("PaymentHotelRooms");
            builder.HasKey(phr => phr.Id);

            builder.HasOne(phr => phr.Client)
                   .WithMany(u => u.PaymentHotelRoom)
                   .HasForeignKey(phr => phr.ClientId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(phr => phr.BookingHotelRoom)
                   .WithMany(bhr => bhr.PaymentHotelRooms)
                   .HasForeignKey(phr => phr.BookingHotelRoomId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
