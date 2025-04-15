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
        public string Availability { get; set; }
        public int RoomTypeId { get; set; }

        // Optional details from RoomType
        public string RoomTypeName { get; set; }
        public float RoomTypePrice { get; set; }
    }
}

