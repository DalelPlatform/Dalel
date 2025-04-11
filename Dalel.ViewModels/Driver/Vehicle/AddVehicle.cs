using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public class AddVehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int ModelYear { get; set; }
        public int Seats { get; set; }
        public string LicenseNumber { get; set; }
        public string PlateNumber { get; set; }
        public string DriverId { get; set; }
        public List<string> ImagePaths { get; set; } // Assuming images are uploaded and saved as paths
    }

}
