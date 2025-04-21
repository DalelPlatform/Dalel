using Dalel.ViewModels.Restaurant;
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

        public static RestaurantReservation ToModel(this AddRestaurantReservationVM reservation)
        {
            return new RestaurantReservation
            {
                
                Comments = reservation.Comments,
                Rating = reservation.Rating,
                ModificationDateTime = DateTime.Now,
                TableNumber = reservation.TableNumber,
                ReervationStatus = reservation.ReervationStatus,
                RestaurantId = reservation.RestaurantId ,
                ClientId = reservation.ClientId 
            };
        }

        public static RestaurantReservation ToEditModel(this AddRestaurantReservationVM ModelVm , RestaurantReservation oldModel)
        {
            oldModel.Comments = ModelVm.Comments ?? oldModel.Comments;
            oldModel.Rating = ModelVm.Rating > 0
                ? ModelVm.Rating
                : oldModel.Rating;
            oldModel.TableNumber = ModelVm.TableNumber ?? oldModel.TableNumber;
            oldModel.ReervationStatus = ModelVm.ReervationStatus > 0
                ? ModelVm.ReervationStatus
                : oldModel.ReervationStatus;


            return oldModel;
        }
    }
}
