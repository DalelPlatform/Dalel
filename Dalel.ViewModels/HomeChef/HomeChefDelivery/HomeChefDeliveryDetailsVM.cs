using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models.Enums;

namespace Dalel.ViewModels
{
    public class HomeChefDeliveryDetailsVM
    {
        public string PlatformLogistics { get; set; }
        public bool SelfDelivery { get; set; }
        public StatusOfDelivery DeliveryStatus { get; set; }
        public DateTime DateTime {  get; set; }
    }
}

