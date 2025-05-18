using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels.Agency.PackageStep;
using Dalel.ViewModels.Agency.PackageSchadule;

namespace Dalel.ViewModels.Agency.AgencyPackage
{
    public class AddAgencyPackageVM
    {
        [Required(ErrorMessage = "Please Provide valid Agency Name")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Agency name must contain at least 3 letter and max 100 letter")]
        public string Name { get; set; }

        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Agency Description must contain at least 10 letter and max 1000 letter")]
      
        public string Description { get; set; }

        [Required(ErrorMessage = "Please Provide valid Agency Price Start from 5")]
        public string Price { get; set; }

        public float? Duration { get; set; }
        public string TermsPolicies { get; set; }

        public int AgencyId { get; set; }


        public List<addPackageStepVM> Steps { get; set; }
        public List<addPackageSchaduleVM> Schadules { get; set; }


    }


}
