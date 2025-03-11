using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.HomeChef
{
    public class HomeChefs
    {
        public int Id { get; set; }
        public string FoodSafetyCertification { get; set; }

        public string BankDetails { get; set; }

        public string WorkingHours { get; set; }

        public string UserId { get; set; }
    }
}
