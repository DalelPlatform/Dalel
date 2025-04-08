using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels.Hotel_DTO
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public string Availability { get; set; } // Enum mapped to string
        public int RoomTypeId { get; set; }
    }

}
