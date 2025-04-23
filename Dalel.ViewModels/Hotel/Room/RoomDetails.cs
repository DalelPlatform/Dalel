using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public class RoomDetails
    {
        public int Id { get; set; }
        public int RoomTypeId { get; set; }
        public string ViewType { get; set; }
        public string Status { get; set; }
        public string Availability { get; set; }

        // Optional: expose the friendly name of the room type
        public string RoomTypeName { get; set; }
    }
}

