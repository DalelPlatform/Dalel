using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels.Hotel_DTO
{
    public class BookingGuestInRoomDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string NationalID { get; set; }
        public string NationalIDImage { get; set; }
        public int BookingHotelRoomId { get; set; }
        public int BookingId { get; set; }
    }
}
