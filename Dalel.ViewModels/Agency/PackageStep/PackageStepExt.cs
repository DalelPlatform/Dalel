using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels.Agency.Packagebooking;
using Dalel.ViewModels.Agency.PackageStep;
using Dalel.ViewModels.Agency.TravelAgencies;
using Models.Agency;
using static System.Net.Mime.MediaTypeNames;

namespace Dalel.ViewModels
{
    public static class PackageStepExt
    {
        public static PackageStep ToModel(this addPackageStepVM step)
        {
            return new PackageStep
            {
                Name = step.Name,
                Image = step.Image,
                Description = step.Description,
                Duration = step.Duration,
                //PackageId = step.PackageId,

            };


        }
        public static PackageStepDetails ToDetailsModels(this PackageStep step)
        {
            return new PackageStepDetails
            {
                Id = step.Id,
                Name = step.Name,
                Image = step.Image,
                Description = step.Description,
                Duration = step.Duration,


            };
        }

        public static PackageStep ToEditModel(this addPackageStepVM step,
          PackageStep old)
        {

            old.Name = step.Name;
            old.Image = step.Image;
            old.Description = step.Description;
            old.Duration = step.Duration;
            //old.PackageId = (int)step.PackageId;


            return old;
        }
    }
}