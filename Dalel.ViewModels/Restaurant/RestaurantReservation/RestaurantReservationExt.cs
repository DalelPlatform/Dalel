using Models.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public static class RestaurantReservationExt
    {
        public static RestaurantReservationDetailsVM ToDetailsViewModel(this RestaurantReservation reservation)
        {
            return new RestaurantReservationDetailsVM
            {
                Id = reservation.Id,
                Comments = reservation.Comments,
                Rating = reservation.Rating,
                TableNumber = reservation.TableNumber,
                RestaurantName = reservation.Restaurant.RestaurantOwner.AppUser.UserName ?? "Not Provided",
                ClientName = reservation.Client.User.UserName
            };
        }
    }
}
