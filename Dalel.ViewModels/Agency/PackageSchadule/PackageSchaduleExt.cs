using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels.Agency.PackageSchadule;
using Dalel.ViewModels.Agency.PackageStep;
using Dalel.ViewModels.Agency.TravelAgencies;
using Models.Agency;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dalel.ViewModels
{
    public static class PackageSchaduleExt
    {
        public static PackageSchadule ToModel(this addPackageSchaduleVM schadule)
        {
            return new PackageSchadule
            {
               Date = schadule.Date,
               SlotsAvailable = schadule.SlotsAvailable,
               PabckageBookings = schadule.PackageBookings.Select(i => i.ToModel()).ToList(),

            };


        }
        public static PackageSchaduleDetails ToDetailsModels(this PackageSchadule
            schadule)
        {
            return new PackageSchaduleDetails
            {
            Id = schadule.Id,
                Date = schadule.Date,
                SlotsAvailable = schadule.SlotsAvailable,


            };
        }


        public static PackageSchadule ToEditModel(this addPackageSchaduleVM schadule,
    PackageSchadule old)
        {

            old.Date = schadule.Date;
            old.SlotsAvailable = schadule.SlotsAvailable;



            return old;
        }
    }
}
