using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels.Agency.PackageSchadule;
using Dalel.ViewModels.Agency.PackageStep;
using Models.Agency;

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

    }
}
