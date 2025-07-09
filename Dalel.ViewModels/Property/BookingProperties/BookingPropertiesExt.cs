using Models.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public static class BookingPropertiesExt
    {
        public static BookingProperties ToModel(this AddBookingPropertiesVM viewModel,float TotalPrice)
        {
            return new BookingProperties
            {
                CheckIn = viewModel.CheckIn,
                CheckOut = viewModel.CheckOut,
                Price = TotalPrice,
                Status = viewModel.Status,
                PropertyId = viewModel.PropertyId,
                ClientId = viewModel.ClientId
            };
        }
        public static BookingPropertiesDetailsVM ToDetailsViewModel(this BookingProperties property)
        {
            return new BookingPropertiesDetailsVM
            {
                Id = property.Id,
                CheckIn = property.CheckIn,
                CheckOut = property.CheckOut,
                PricePerNight = property.Properties.PricePerNight,
                PropertyName = property.Properties.Description,
                ClientName = property.Client.User.UserName ?? "Not Provided",
                TotalPrice = property.Price,
                Status = property.Status,
                PropertyId = property.PropertyId,
                ClientId = property.ClientId
            };
        }
    }
}
