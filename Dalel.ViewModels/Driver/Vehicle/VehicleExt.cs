using Dalel.ViewModels;
using Models.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public  static class VehicleExt
    {

          public static Vehicle ToModel(this AddVehicle vm)
        {
            return new Vehicle
            {
                Type = vm.Type,
                Model = vm.Model,
                Color = vm.Color,
                ModelYear = vm.ModelYear,
                Seats = vm.Seats,
                LicenseNumber = vm.LicenseNumber,
                PlateNumber = vm.PlateNumber,
                DriverId = vm.DriverId,
                VehicleImages = vm.ImagePaths?.Select(path => new VehicleImage { Image = path }).ToList()
            };
        }
        public static VehicleDetailsViewModel ToDetailsViewModel(this Vehicle vehicle)
        {
            return new VehicleDetailsViewModel
            {
                Id = vehicle.Id,
                Type = vehicle.Type,
                Model = vehicle.Model,
                Color = vehicle.Color,
                ModelYear = vehicle.ModelYear,
                Seats = vehicle.Seats,
                LicenseNumber = vehicle.LicenseNumber,
                PlateNumber = vehicle.PlateNumber
            };
        }
    }
}
