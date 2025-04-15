using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels.Agency.PackageSchadule
{
    public class addPackageSchaduleVM
    {
        [Required(ErrorMessage = "Please Provide Valid date")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "this field is Required ")]
        public int SlotsAvailable { get; set; }
    }
}
