using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels.Hotel_DTO
{
    public class RoomTypeDTO
    {
        public int Id { get; set; }
        public string Type { get; set; } // Enum mapped to string
        public string Description { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfBeds { get; set; }
        public float Price { get; set; }
        public ICollection<RoomDTO> Rooms { get; set; }
    }

}
