using Dalel.ViewModels;
using Models;
using Models.Restaurant;
using Models.Restaurant.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Restaurant;
using Models.Enums;

namespace Dalel.Repository
{
    public class RestaurantReservationRepository : BaseRepository<RestaurantReservation>
    {
        public RestaurantReservationRepository(DelelContext delelContext) : base(delelContext) 
        {

        }

        public IQueryable<RestaurantReservationDetailsVM> GetReservationsByRestaurant(int restaurantId)
        {
            return GetList(reservation => reservation.RestaurantId == restaurantId).Select(reservation => reservation.ToDetailsViewModel());
        }

        public IQueryable<RestaurantReservationDetailsVM> GetReservationsByClient(string clientId)
        {
            return GetList(reservation => reservation.ClientId == clientId).Select(reservation => reservation.ToDetailsViewModel());
        }
        
        public RestaurantReservationDetailsVM GetReservationDetails(int reservationId)
        {

            return GetList(reservation => reservation.Id == reservationId).Select(reservation => reservation.ToDetailsViewModel())
                .FirstOrDefault();
        }
        public IQueryable<RestaurantReservationDetailsVM> GetPendingBooking()
        {
            return GetList(p => p.ReervationStatus == StatusOfReservations.Panding).
                Select(book => book.ToDetailsViewModel());
        }
        public void UpdateReservationStatus(int reservationId, StatusOfReservations newStatus)
        {
            var reservation = GetList(res => res.Id == reservationId).FirstOrDefault();
            if (reservation != null)
            {
                reservation.ReervationStatus = newStatus;
                Update(reservation);
            }
        } 
    }
}
