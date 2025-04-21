using System;
using System.Collections.Generic;
using System.Linq;
using Dalel.Repository;
using Dalel.ViewModels;
using Dalel.ViewModels.Hotel;
using Dalel.ViewModels.Hotel.HotelPayment;
using Models.Enums;
using Utilities;
using Models.Hotel;

namespace Dalel.Services
{
    public class HotelService
    {
        private readonly HotelRepository _hotelRepo;
        private readonly RoomTypeRepository _roomTypeRepo;
        private readonly RoomRepository _roomRepo;
        private readonly ServiceRepository _serviceRepo;
        private readonly BookingHotelRoomRepository _bookingRepo;
        private readonly PaymentHotelRoomRepository _paymentRepo;
        private readonly ReviewHotelRoomRepository _reviewRepo;

        public HotelService(
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
            return new ServiceResult { Success = true, Message = "Hotel created." };
        }

        public ServiceResult UpdateHotel(int id, HotelCreation vm)
        {
            var entity = _hotelRepo.GetList(h => h.Id == id).FirstOrDefault();
            if (entity == null) return ServiceResult.FailureResult("Hotel not found.");
            entity.UpdateModel(vm);
            _hotelRepo.Update(entity);
            return new ServiceResult { Success = true, Message = "Hotel updated." };
        }

        public ServiceResult DeleteHotel(int id)
        {
            var entity = _hotelRepo.GetList(h => h.Id == id).FirstOrDefault();
            if (entity == null) return ServiceResult.FailureResult("Hotel not found.");
            _hotelRepo.Delete(entity);
            return new ServiceResult { Success = true, Message = "Hotel deleted." };
        }

        public ServiceResult<HotelDetails> GetHotelById(int id)
        {
            var details = _hotelRepo.GetDetailsById(id);
            if (details == null) return ServiceResult<HotelDetails>.FailureResult("Hotel not found.");
            return ServiceResult<HotelDetails>.SuccessResult(details, "Fetched successfully.");
        }

        public ServiceResult<List<HotelDetails>> GetAllHotels()
        {
            var list = _hotelRepo.GetAllDetails().ToList();
            return ServiceResult<List<HotelDetails>>.SuccessResult(list, "Fetched all hotels.");
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
            return ServiceResult<PaginationViewModel<HotelDetails>>.SuccessResult(page, "Hotels retrieved.");
        }
        #endregion

        #region RoomType
        public ServiceResult CreateRoomType(RoomTypeCreation vm)
        {
            _roomTypeRepo.Add(vm.ToModel());
            return new ServiceResult { Success = true, Message = "Room type created." };
        }

        public ServiceResult UpdateRoomType(int id, RoomTypeCreation vm)
        {
            var entity = _roomTypeRepo.GetList(rt => rt.Id == id).FirstOrDefault();
            if (entity == null) return ServiceResult.FailureResult("Room type not found.");
            entity.UpdateModel(vm);
            _roomTypeRepo.Update(entity);
            return new ServiceResult { Success = true, Message = "Room type updated." };
        }

        public ServiceResult DeleteRoomType(int id)
        {
            var entity = _roomTypeRepo.GetList(rt => rt.Id == id).FirstOrDefault();
            if (entity == null) return ServiceResult.FailureResult("Room type not found.");
            _roomTypeRepo.Delete(entity);
            return new ServiceResult { Success = true, Message = "Room type deleted." };
        }

        public ServiceResult<RoomTypeDetails> GetRoomTypeById(int id)
        {
            var details = _roomTypeRepo.GetDetailsById(id);
            if (details == null) return ServiceResult<RoomTypeDetails>.FailureResult("Room type not found.");
            return ServiceResult<RoomTypeDetails>.SuccessResult(details, "Fetched successfully.");
        }

        public ServiceResult<List<RoomTypeDetails>> GetAllRoomTypes()
        {
            var list = _roomTypeRepo.GetAllDetails().ToList();
            return ServiceResult<List<RoomTypeDetails>>.SuccessResult(list, "Fetched all room types.");
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
            return ServiceResult<PaginationViewModel<RoomTypeDetails>>.SuccessResult(page, "Room types retrieved.");
        }
        #endregion

        #region Room
        public ServiceResult CreateRoom(RoomCreation vm)
        {
            _roomRepo.Add(vm.ToModel());
            return new ServiceResult { Success = true, Message = "Room created." };
        }

        public ServiceResult UpdateRoom(int id, RoomCreation vm)
        {
            var entity = _roomRepo.GetList(r => r.Id == id).FirstOrDefault();
            if (entity == null) return ServiceResult.FailureResult("Room not found.");
            entity.UpdateModel(vm);
            _roomRepo.Update(entity);
            return new ServiceResult { Success = true, Message = "Room updated." };
        }

        public ServiceResult DeleteRoom(int id)
        {
            var entity = _roomRepo.GetList(r => r.Id == id).FirstOrDefault();
            if (entity == null) return ServiceResult.FailureResult("Room not found.");
            _roomRepo.Delete(entity);
            return new ServiceResult { Success = true, Message = "Room deleted." };
        }

        public ServiceResult<RoomDetails> GetRoomById(int id)
        {
            var details = _roomRepo.GetDetailsById(id);
            if (details == null) return ServiceResult<RoomDetails>.FailureResult("Room not found.");
            return ServiceResult<RoomDetails>.SuccessResult(details, "Fetched successfully.");
        }

        public ServiceResult<List<RoomDetails>> GetAllRooms()
        {
            var list = _roomRepo.GetAllDetails().ToList();
            return ServiceResult<List<RoomDetails>>.SuccessResult(list, "Fetched all rooms.");
        }

        public ServiceResult<PaginationViewModel<RoomDetails>> SearchRooms(
            int? roomTypeId = null,
            string viewType = null,
            AvaliabilityStatus? availability = null,
            bool descending = false,
            int pageSize = 5,
            int pageIndex = 1)
        {
            var page = _roomRepo.Search(roomTypeId, viewType, availability, descending, pageSize, pageIndex);
            return ServiceResult<PaginationViewModel<RoomDetails>>.SuccessResult(page, "Rooms retrieved.");
        }
        #endregion

        #region Service
        public ServiceResult CreateService(ServiceCreation vm)
        {
            _serviceRepo.Add(vm.ToModel());
            return new ServiceResult { Success = true, Message = "Service created." };
        }

        public ServiceResult UpdateService(int id, ServiceCreation vm)
        {
            var entity = _serviceRepo.GetList(s => s.Id == id).FirstOrDefault();
            if (entity == null) return ServiceResult.FailureResult("Service not found.");
            entity.UpdateModel(vm);
            _serviceRepo.Update(entity);
            return new ServiceResult { Success = true, Message = "Service updated." };
        }

        public ServiceResult DeleteService(int id)
        {
            var entity = _serviceRepo.GetList(s => s.Id == id).FirstOrDefault();
            if (entity == null) return ServiceResult.FailureResult("Service not found.");
            _serviceRepo.Delete(entity);
            return new ServiceResult { Success = true, Message = "Service deleted." };
        }

        public ServiceResult<ServiceDetails> GetServiceById(int id)
        {
            var details = _serviceRepo.GetDetailsById(id);
            if (details == null) return ServiceResult<ServiceDetails>.FailureResult("Service not found.");
            return ServiceResult<ServiceDetails>.SuccessResult(details, "Fetched successfully.");
        }

        public ServiceResult<List<ServiceDetails>> GetAllServices()
        {
            var list = _serviceRepo.GetAllDetails().ToList();
            return ServiceResult<List<ServiceDetails>>.SuccessResult(list, "Fetched all services.");
        }

        public ServiceResult<PaginationViewModel<ServiceDetails>> SearchServices(
            string name = null,
            bool? isActive = null,
            bool descending = false,
            int pageSize = 5,
            int pageIndex = 1)
        {
            var page = _serviceRepo.Search(name, isActive, descending, pageSize, pageIndex);
            return ServiceResult<PaginationViewModel<ServiceDetails>>.SuccessResult(page, "Services retrieved.");
        }
        #endregion

        #region Booking
        public ServiceResult CreateBooking(BookingHotelRoomCreation vm)
        {
            _bookingRepo.Add(vm.ToModel());
            return new ServiceResult { Success = true, Message = "Booking created." };
        }

        public ServiceResult UpdateBooking(int id, BookingHotelRoomCreation vm)
        {
            var entity = _bookingRepo.GetList(b => b.Id == id).FirstOrDefault();
            if (entity == null) return ServiceResult.FailureResult("Booking not found.");
            entity.UpdateModel(vm);
            _bookingRepo.Update(entity);
            return new ServiceResult { Success = true, Message = "Booking updated." };
        }

        public ServiceResult DeleteBooking(int id)
        {
            var entity = _bookingRepo.GetList(b => b.Id == id).FirstOrDefault();
            if (entity == null) return ServiceResult.FailureResult("Booking not found.");
            _bookingRepo.Delete(entity);
            return new ServiceResult { Success = true, Message = "Booking deleted." };
        }

        public ServiceResult<BookingHotelRoomDetails> GetBookingById(int id)
        {
            var details = _bookingRepo.GetDetailsById(id);
            if (details == null) return ServiceResult<BookingHotelRoomDetails>.FailureResult("Booking not found.");
            return ServiceResult<BookingHotelRoomDetails>.SuccessResult(details, "Fetched successfully.");
        }

        public ServiceResult<List<BookingHotelRoomDetails>> GetAllBookings()
        {
            var list = _bookingRepo.GetAllDetails().ToList();
            return ServiceResult<List<BookingHotelRoomDetails>>.SuccessResult(list, "Fetched all bookings.");
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
            return ServiceResult<PaginationViewModel<BookingHotelRoomDetails>>.SuccessResult(page, "Bookings retrieved.");
        }
        #endregion

        #region Payment
        public ServiceResult CreatePayment(PaymentHotelRoomCreation vm)
        {
            _paymentRepo.Add(vm.ToModel());
            return new ServiceResult { Success = true, Message = "Payment created." };
        }

        public ServiceResult UpdatePayment(int id, PaymentHotelRoomCreation vm)
        {
            var entity = _paymentRepo.GetList(p => p.Id == id).FirstOrDefault();
            if (entity == null) return ServiceResult.FailureResult("Payment not found.");
            entity.UpdateModel(vm);
            _paymentRepo.Update(entity);
            return new ServiceResult { Success = true, Message = "Payment updated." };
        }

        public ServiceResult DeletePayment(int id)
        {
            var entity = _paymentRepo.GetList(p => p.Id == id).FirstOrDefault();
            if (entity == null) return ServiceResult.FailureResult("Payment not found.");
            _paymentRepo.Delete(entity);
            return new ServiceResult { Success = true, Message = "Payment deleted." };
        }

        public ServiceResult<HotelPaymentDetails> GetPaymentById(int id)
        {
            var details = _paymentRepo.GetDetailsById(id);
            if (details == null) return ServiceResult<HotelPaymentDetails>.FailureResult("Payment not found.");
            return ServiceResult<HotelPaymentDetails>.SuccessResult(details, "Fetched successfully.");
        }

        public ServiceResult<List<HotelPaymentDetails>> GetAllPayments()
        {
            var list = _paymentRepo.GetAllDetails().ToList();
            return ServiceResult<List<HotelPaymentDetails>>.SuccessResult(list, "Fetched all payments.");
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
            return ServiceResult<PaginationViewModel<HotelPaymentDetails>>.SuccessResult(page, "Payments retrieved.");
        }
        #endregion

        #region Review
        public ServiceResult CreateReview(ReviewCreation vm)
        {
            _reviewRepo.Add(vm.ToModel());
            return new ServiceResult { Success = true, Message = "Review created." };
        }

        public ServiceResult UpdateReview(int id, ReviewCreation vm)
        {
            var entity = _reviewRepo.GetList(r => r.Id == id).FirstOrDefault();
            if (entity == null) return ServiceResult.FailureResult("Review not found.");
            entity.UpdateModel(vm);
            _reviewRepo.Update(entity);
            return new ServiceResult { Success = true, Message = "Review updated." };
        }

        public ServiceResult DeleteReview(int id)
        {
            var entity = _reviewRepo.GetList(r => r.Id == id).FirstOrDefault();
            if (entity == null) return ServiceResult.FailureResult("Review not found.");
            _reviewRepo.Delete(entity);
            return new ServiceResult { Success = true, Message = "Review deleted." };
        }

        public ServiceResult<ReviewDetails> GetReviewById(int id)
        {
            var details = _reviewRepo.GetDetailsById(id);
            if (details == null) return ServiceResult<ReviewDetails>.FailureResult("Review not found.");
            return ServiceResult<ReviewDetails>.SuccessResult(details, "Fetched successfully.");
        }

        public ServiceResult<List<ReviewDetails>> GetAllReviews()
        {
            var list = _reviewRepo.GetAllDetails().ToList();
            return ServiceResult<List<ReviewDetails>>.SuccessResult(list, "Fetched all reviews.");
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
            return ServiceResult<PaginationViewModel<ReviewDetails>>.SuccessResult(page, "Reviews retrieved.");
        }
        #endregion
    }
}
