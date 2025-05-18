using Dalel.Repository;
using Dalel.ViewModels;
using Models.Enums;
using Utilities;
using System.Linq;
using System.Collections.Generic;

namespace Dalel.Services
{
    public class HotelServices
    {
        private readonly HotelRepository _hotelRepo;
        private readonly RoomTypeRepository _roomTypeRepo;
        private readonly RoomRepository _roomRepo;
        private readonly ServiceRepository _serviceRepo;
        private readonly BookingHotelRoomRepository _bookingRepo;
        private readonly PaymentHotelRoomRepository _paymentRepo;
        private readonly ReviewHotelRoomRepository _reviewRepo;

        public HotelServices(
            HotelRepository hotelRepo,
            RoomTypeRepository roomTypeRepo,
            RoomRepository roomRepo,
            ServiceRepository serviceRepo,
            BookingHotelRoomRepository bookingRepo,
            PaymentHotelRoomRepository paymentRepo,
            ReviewHotelRoomRepository reviewRepo)
        {
            _hotelRepo = hotelRepo;
            _roomTypeRepo = roomTypeRepo;
            _roomRepo = roomRepo;
            _serviceRepo = serviceRepo;
            _bookingRepo = bookingRepo;
            _paymentRepo = paymentRepo;
            _reviewRepo = reviewRepo;
        }

        #region Hotel
        public ServiceResult CreateHotel(HotelCreation vm)
        {
            _hotelRepo.Add(vm.ToModel());
            return ServiceResult.SuccessResult("Hotel created successfully.", 201);
        }

        public ServiceResult UpdateHotel(int id, HotelCreation vm)
        {
            var entity = _hotelRepo.GetList(h => h.Id == id).FirstOrDefault();
            if (entity == null)
                return ServiceResult.FailureResult("Hotel not found.", 404);

            _hotelRepo.Update(vm.UpdateModel(entity));
            return ServiceResult.SuccessResult("Hotel updated successfully.", 200);
        }

        public ServiceResult DeleteHotel(int id)
        {
            var entity = _hotelRepo.GetList(h => h.Id == id).FirstOrDefault();
            if (entity == null)
                return ServiceResult.FailureResult("Hotel not found.", 404);

            _hotelRepo.Delete(entity);
            return ServiceResult.SuccessResult("Hotel deleted successfully.", 200);
        }

        public ServiceResult<HotelDetails> GetHotelById(int id)
        {
            var details = _hotelRepo.GetDetailsById(id);
            if (details == null)
                return ServiceResult<HotelDetails>.FailureResult("Hotel not found.");

            return ServiceResult<HotelDetails>.SuccessResult(details, "Hotel fetched successfully.");
        }

        public ServiceResult<List<HotelDetails>> GetAllHotels()
        {
            var list = _hotelRepo.GetAllDetails().ToList();
            return ServiceResult<List<HotelDetails>>.SuccessResult(list, "All hotels retrieved.");
        }

        public ServiceResult<PaginationViewModel<HotelDetails>> SearchHotels(
            string name = null,
            string city = null,
            string ownerId = null,
            VerificationStatus? status = null,
            bool includeDeleted = false,
            bool descending = false,
            int pageSize = 5,
            int pageIndex = 1)
        {
            var page = _hotelRepo.Search(name, city, ownerId, status, includeDeleted, descending, pageSize, pageIndex);
            return ServiceResult<PaginationViewModel<HotelDetails>>.SuccessResult(page, "Hotels search completed.");
        }
        #endregion

        #region RoomType
        public ServiceResult CreateRoomType(RoomTypeCreation vm)
        {
            _roomTypeRepo.Add(vm.ToModel());
            return ServiceResult.SuccessResult("Room type created successfully.", 201);
        }

        public ServiceResult UpdateRoomType(int id, RoomTypeCreation vm)
        {
            var entity = _roomTypeRepo.GetList(rt => rt.Id == id).FirstOrDefault();
            if (entity == null)
                return ServiceResult.FailureResult("Room type not found.", 404);

            entity.UpdateModel(vm);
            _roomTypeRepo.Update(entity);
            return ServiceResult.SuccessResult("Room type updated successfully.", 200);
        }

        public ServiceResult DeleteRoomType(int id)
        {
            var entity = _roomTypeRepo.GetList(rt => rt.Id == id).FirstOrDefault();
            if (entity == null)
                return ServiceResult.FailureResult("Room type not found.", 404);

            _roomTypeRepo.Delete(entity);
            return ServiceResult.SuccessResult("Room type deleted successfully.", 200);
        }

        public ServiceResult<RoomTypeDetails> GetRoomTypeById(int id)
        {
            var details = _roomTypeRepo.GetDetailsById(id);
            if (details == null)
                return ServiceResult<RoomTypeDetails>.FailureResult("Room type not found.");

            return ServiceResult<RoomTypeDetails>.SuccessResult(details, "Room type fetched successfully.");
        }

        public ServiceResult<List<RoomTypeDetails>> GetAllRoomTypes()
        {
            var list = _roomTypeRepo.GetAllDetails().ToList();
            return ServiceResult<List<RoomTypeDetails>>.SuccessResult(list, "All room types retrieved.");
        }

        public ServiceResult<PaginationViewModel<RoomTypeDetails>> SearchRoomTypes(
            HotelRoomType? type = null,
            int? maxOccupancy = null,
            bool? hasBreakfast = null,
            float? minPrice = null,
            float? maxPrice = null,
            int? hotelId = null,
            bool descending = false,
            int pageSize = 5,
            int pageIndex = 1)
        {
            var page = _roomTypeRepo.Search(type, maxOccupancy, hasBreakfast, minPrice, maxPrice, hotelId, descending, pageSize, pageIndex);
            return ServiceResult<PaginationViewModel<RoomTypeDetails>>.SuccessResult(page, "Room types search completed.");
        }
        #endregion

        #region Room
        public ServiceResult CreateRoom(RoomCreation vm)
        {
            _roomRepo.Add(vm.ToModel());
            return ServiceResult.SuccessResult("Room created successfully.", 201);
        }

        public ServiceResult UpdateRoom(int id, RoomCreation vm)
        {
            var entity = _roomRepo.GetList(r => r.Id == id).FirstOrDefault();
            if (entity == null)
                return ServiceResult.FailureResult("Room not found.", 404);

            entity.UpdateModel(vm);
            _roomRepo.Update(entity);
            return ServiceResult.SuccessResult("Room updated successfully.", 200);
        }

        public ServiceResult DeleteRoom(int id)
        {
            var entity = _roomRepo.GetList(r => r.Id == id).FirstOrDefault();
            if (entity == null)
                return ServiceResult.FailureResult("Room not found.", 404);

            _roomRepo.Delete(entity);
            return ServiceResult.SuccessResult("Room deleted successfully.", 200);
        }

        public ServiceResult<RoomDetails> GetRoomById(int id)
        {
            var details = _roomRepo.GetDetailsById(id);
            if (details == null)
                return ServiceResult<RoomDetails>.FailureResult("Room not found.");

            return ServiceResult<RoomDetails>.SuccessResult(details, "Room fetched successfully.");
        }

        public ServiceResult<List<RoomDetails>> GetAllRooms()
        {
            var list = _roomRepo.GetAllDetails().ToList();
            return ServiceResult<List<RoomDetails>>.SuccessResult(list, "All rooms retrieved.");
        }

        public ServiceResult<PaginationViewModel<RoomDetails>> SearchRooms(
            int? roomTypeId = null,
            AvaliabilityStatus? availability = null,
            bool descending = false,
            int pageSize = 5,
            int pageIndex = 1)
        {
            var page = _roomRepo.Search(roomTypeId, availability, descending, pageSize, pageIndex);
            return ServiceResult<PaginationViewModel<RoomDetails>>.SuccessResult(page, "Rooms search completed.");
        }
        #endregion

        #region Service
        public ServiceResult CreateService(ServiceCreation vm)
        {
            _serviceRepo.Add(vm.ToModel());
            return ServiceResult.SuccessResult("Service created successfully.", 201);
        }

        public ServiceResult UpdateService(int id, ServiceCreation vm)
        {
            var entity = _serviceRepo.GetList(s => s.Id == id).FirstOrDefault();
            if (entity == null)
                return ServiceResult.FailureResult("Service not found.", 404);

            entity.UpdateModel(vm);
            _serviceRepo.Update(entity);
            return ServiceResult.SuccessResult("Service updated successfully.", 200);
        }

        public ServiceResult DeleteService(int id)
        {
            var entity = _serviceRepo.GetList(s => s.Id == id).FirstOrDefault();
            if (entity == null)
                return ServiceResult.FailureResult("Service not found.", 404);

            _serviceRepo.Delete(entity);
            return ServiceResult.SuccessResult("Service deleted successfully.", 200);
        }

        public ServiceResult<ServiceDetails> GetServiceById(int id)
        {
            var details = _serviceRepo.GetDetailsById(id);
            if (details == null)
                return ServiceResult<ServiceDetails>.FailureResult("Service not found.");

            return ServiceResult<ServiceDetails>.SuccessResult(details, "Service fetched successfully.");
        }

        public ServiceResult<List<ServiceDetails>> GetAllServices()
        {
            var list = _serviceRepo.GetAllDetails().ToList();
            return ServiceResult<List<ServiceDetails>>.SuccessResult(list, "All services retrieved.");
        }

        public ServiceResult<PaginationViewModel<ServiceDetails>> SearchServices(
            string name = null,
            bool? isActive = null,
            bool descending = false,
            int pageSize = 5,
            int pageIndex = 1)
        {
            var page = _serviceRepo.Search(name, isActive, descending, pageSize, pageIndex);
            return ServiceResult<PaginationViewModel<ServiceDetails>>.SuccessResult(page, "Services search completed.");
        }
        #endregion

        #region Booking
        public ServiceResult CreateBooking(BookingHotelRoomCreation vm)
        {
            _bookingRepo.Add(vm.ToModel());
            return ServiceResult.SuccessResult("Booking created successfully.", 201);
        }

        public ServiceResult UpdateBooking(int id, BookingHotelRoomCreation vm)
        {
            var entity = _bookingRepo.GetList(b => b.Id == id).FirstOrDefault();
            if (entity == null)
                return ServiceResult.FailureResult("Booking not found.", 404);

            entity.UpdateModel(vm);
            _bookingRepo.Update(entity);
            return ServiceResult.SuccessResult("Booking updated successfully.", 200);
        }

        public ServiceResult DeleteBooking(int id)
        {
            var entity = _bookingRepo.GetList(b => b.Id == id).FirstOrDefault();
            if (entity == null)
                return ServiceResult.FailureResult("Booking not found.", 404);

            _bookingRepo.Delete(entity);
            return ServiceResult.SuccessResult("Booking deleted successfully.", 200);
        }

        public ServiceResult<BookingHotelRoomDetails> GetBookingById(int id)
        {
            var details = _bookingRepo.GetDetailsById(id);
            if (details == null)
                return ServiceResult<BookingHotelRoomDetails>.FailureResult("Booking not found.");

            return ServiceResult<BookingHotelRoomDetails>.SuccessResult(details, "Booking fetched successfully.");
        }

        public ServiceResult<List<BookingHotelRoomDetails>> GetAllBookings()
        {
            var list = _bookingRepo.GetAllDetails().ToList();
            return ServiceResult<List<BookingHotelRoomDetails>>.SuccessResult(list, "All bookings retrieved.");
        }

        public ServiceResult<PaginationViewModel<BookingHotelRoomDetails>> SearchBookings(
            DateTime? checkin = null,
            DateTime? checkout = null,
            string clientId = null,
            BookingStatus? status = null,
            int? roomId = null,
            bool descending = false,
            int pageSize = 5,
            int pageIndex = 1)
        {
            var page = _bookingRepo.Search(checkin, checkout, clientId, status, roomId, descending, pageSize, pageIndex);
            return ServiceResult<PaginationViewModel<BookingHotelRoomDetails>>.SuccessResult(page, "Bookings search completed.");
        }
        #endregion

        #region Payment
        public ServiceResult CreatePayment(PaymentHotelRoomCreation vm)
        {
            _paymentRepo.Add(vm.ToModel());
            return ServiceResult.SuccessResult("Payment created successfully.", 201);
        }

        public ServiceResult UpdatePayment(int id, PaymentHotelRoomCreation vm)
        {
            var entity = _paymentRepo.GetList(p => p.Id == id).FirstOrDefault();
            if (entity == null)
                return ServiceResult.FailureResult("Payment not found.", 404);

            entity.UpdateModel(vm);
            _paymentRepo.Update(entity);
            return ServiceResult.SuccessResult("Payment updated successfully.", 200);
        }

        public ServiceResult DeletePayment(int id)
        {
            var entity = _paymentRepo.GetList(p => p.Id == id).FirstOrDefault();
            if (entity == null)
                return ServiceResult.FailureResult("Payment not found.", 404);

            _paymentRepo.Delete(entity);
            return ServiceResult.SuccessResult("Payment deleted successfully.", 200);
        }

        public ServiceResult<HotelPaymentDetails> GetPaymentById(int id)
        {
            var details = _paymentRepo.GetDetailsById(id);
            if (details == null)
                return ServiceResult<HotelPaymentDetails>.FailureResult("Payment not found.");

            return ServiceResult<HotelPaymentDetails>.SuccessResult(details, "Payment fetched successfully.");
        }

        public ServiceResult<List<HotelPaymentDetails>> GetAllPayments()
        {
            var list = _paymentRepo.GetAllDetails().ToList();
            return ServiceResult<List<HotelPaymentDetails>>.SuccessResult(list, "All payments retrieved.");
        }

        public ServiceResult<PaginationViewModel<HotelPaymentDetails>> SearchPayments(
            decimal? minAmount = null,
            decimal? maxAmount = null,
            PaymentMethod? method = null,
            PaymentStatus? status = null,
            string clientId = null,
            int? hotelId = null,
            bool descending = false,
            int pageSize = 5,
            int pageIndex = 1)
        {
            var page = _paymentRepo.Search(minAmount, maxAmount, method, status, clientId, hotelId, descending, pageSize, pageIndex);
            return ServiceResult<PaginationViewModel<HotelPaymentDetails>>.SuccessResult(page, "Payments search completed.");
        }
        #endregion

        #region Review
        public ServiceResult CreateReview(ReviewCreation vm)
        {
            _reviewRepo.Add(vm.ToModel());
            return ServiceResult.SuccessResult("Review created successfully.", 201);
        }

        public ServiceResult UpdateReview(int id, ReviewCreation vm)
        {
            var entity = _reviewRepo.GetList(r => r.Id == id).FirstOrDefault();
            if (entity == null)
                return ServiceResult.FailureResult("Review not found.", 404);

            entity.UpdateModel(vm);
            _reviewRepo.Update(entity);
            return ServiceResult.SuccessResult("Review updated successfully.", 200);
        }

        public ServiceResult DeleteReview(int id)
        {
            var entity = _reviewRepo.GetList(r => r.Id == id).FirstOrDefault();
            if (entity == null)
                return ServiceResult.FailureResult("Review not found.", 404);

            _reviewRepo.Delete(entity);
            return ServiceResult.SuccessResult("Review deleted successfully.", 200);
        }

        public ServiceResult<ReviewDetails> GetReviewById(int id)
        {
            var details = _reviewRepo.GetDetailsById(id);
            if (details == null)
                return ServiceResult<ReviewDetails>.FailureResult("Review not found.");

            return ServiceResult<ReviewDetails>.SuccessResult(details, "Review fetched successfully.");
        }

        public ServiceResult<List<ReviewDetails>> GetAllReviews()
        {
            var list = _reviewRepo.GetAllDetails().ToList();
            return ServiceResult<List<ReviewDetails>>.SuccessResult(list, "All reviews retrieved.");
        }

        public ServiceResult<PaginationViewModel<ReviewDetails>> SearchReviews(
            string comments = null,
            float? minRating = null,
            float? maxRating = null,
            DateTime? from = null,
            DateTime? to = null,
            int? clientId = null,
            int? bookingId = null,
            bool descending = false,
            int pageSize = 5,
            int pageIndex = 1)
        {
            var page = _reviewRepo.Search(comments, minRating, maxRating, from, to, clientId, bookingId, descending, pageSize, pageIndex);
            return ServiceResult<PaginationViewModel<ReviewDetails>>.SuccessResult(page, "Reviews search completed.");
        }
        #endregion
    }
}