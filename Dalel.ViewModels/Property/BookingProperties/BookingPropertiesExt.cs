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
        public static BookingProperties ToModel(this AddBookingPropertiesVM viewModel)
        {
            return new BookingProperties
            {
                CheckIn = DateTime.Now, //viewModel.CheckIn,
                CheckOut = DateTime.Now,   //viewModel.CheckOut,
                Price = viewModel.Price,
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
                ClientName = property.Client.User.UserName ?? "Not Provided",
                PropertyName = property.Properties.Description
            };
        }
    }
}
