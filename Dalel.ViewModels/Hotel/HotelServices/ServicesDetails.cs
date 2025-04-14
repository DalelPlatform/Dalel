using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public class ServicesDetails
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public int HotelId { get; set; }
        public int ServicesId { get; set; }

        // Embedded service info
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
    }
}

