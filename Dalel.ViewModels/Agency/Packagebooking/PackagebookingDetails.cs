using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Enums;

namespace Dalel.ViewModels.Agency.Packagebooking
{
    public class PackagebookingDetails
    {
        public int Id { get; set; }
        public BookingStatus BookingStatus { get; set; }
        public DateTime Date { get; set; }
        public int ReservedPeople { get; set; }
        //public float TotalPrice { get; set; }
    }
}
