using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels.Agency.Packagebooking;
using Dalel.ViewModels.Agency.PackageStep;
using Models.Agency;

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
    }
}
