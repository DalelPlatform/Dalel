using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels.Agency.PackageStep
{
    public class PackageStepDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float? Duration { get; set; }
        public string? Image { get; set; }
    }
}
