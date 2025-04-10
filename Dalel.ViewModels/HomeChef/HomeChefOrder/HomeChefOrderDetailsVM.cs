using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Enums;

namespace Dalel.ViewModels
{
    public class HomeChefOrderDetailsVM
    {
        public DateTime OrderDate { get; set; }
        public float TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}

