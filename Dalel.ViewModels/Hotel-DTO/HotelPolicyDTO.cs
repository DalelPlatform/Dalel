using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels.Hotel_DTO
{
    public class HotelPolicyDTO
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string PolicyName { get; set; } // Assuming a PolicyName string, modify based on your model
    }

}
