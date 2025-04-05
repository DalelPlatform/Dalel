using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public class BookingPropertiesDetailsVM
    {
        public int Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public float Price { get; set; }
        public string PropertyName { get; set; }
        public string ClientName { get; set; }
    }
}
