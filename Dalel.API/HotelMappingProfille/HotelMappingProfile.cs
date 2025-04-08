using AutoMapper;
using Dalel.ViewModels.Hotel_DTO;
using Models.Hotel;

namespace Dalel.Mappings
{
    public class HotelMappingProfile : Profile
    {
        public HotelMappingProfile()
        {
            // Hotel ↔ HotelDTO
            CreateMap<Hotel, HotelDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Longitude))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.CancelationOptions, opt => opt.MapFrom(src => src.CancelationOptions))
                .ForMember(dest => dest.CancelationCharges, opt => opt.MapFrom(src => src.CancelationCharges))
                .ForMember(dest => dest.VerificationStatus, opt => opt.MapFrom(src => src.VerificationStatus))
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted))
                .ForMember(dest => dest.HotelImages, opt => opt.MapFrom(src => src.HotelImages))
                .ForMember(dest => dest.RoomTypes, opt => opt.MapFrom(src => src.RoomTypes));

            // HotelImage ↔ HotelImageDTO
            CreateMap<HotelImage, HotelImageDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image))
                .ForMember(dest => dest.HotelId, opt => opt.MapFrom(src => src.HotelId));

            // HotelPolicy ↔ HotelPolicyDTO
            CreateMap<HotelPolicy, HotelPolicyDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.HotelId, opt => opt.MapFrom(src => src.HotelId))
                .ForMember(dest => dest.PolicyName, opt => opt.MapFrom(src => src.Policy));

            // HotelService ↔ HotelServiceDTO
            CreateMap<HotelService, HotelServiceDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.HotelId, opt => opt.MapFrom(src => src.HotelId))
                .ForMember(dest => dest.ServiceId, opt => opt.MapFrom(src => src.ServicesId));

            // RoomType ↔ RoomTypeDTO
            CreateMap<RoomType, RoomTypeDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.NumberOfRooms, opt => opt.MapFrom(src => src.NumberOfRooms))
                .ForMember(dest => dest.NumberOfBeds, opt => opt.MapFrom(src => src.NumberOfBeds))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Rooms, opt => opt.MapFrom(src => src.Rooms));

            // Room ↔ RoomDTO
            CreateMap<Room, RoomDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Availability, opt => opt.MapFrom(src => src.Availability))
                .ForMember(dest => dest.RoomTypeId, opt => opt.MapFrom(src => src.RoomTypeId));

            // RoomTypeImage ↔ RoomTypeImageDTO
            CreateMap<RoomTypeImage, RoomTypeImageDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image))
                .ForMember(dest => dest.RoomTypeId, opt => opt.MapFrom(src => src.RoomTypeId));

            // Service ↔ ServiceDTO
            CreateMap<Service, ServiceDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            // BookingHotelRoom ↔ BookingHotelRoomDTO
            CreateMap<BookingHotelRoom, BookingHotelRoomDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Checkin, opt => opt.MapFrom(src => src.Checkin))
                .ForMember(dest => dest.Checkout, opt => opt.MapFrom(src => src.Checkout))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.NumberOfGuests, opt => opt.MapFrom(src => src.NumberOfGuests))
                .ForMember(dest => dest.BookingStatus, opt => opt.MapFrom(src => src.BookingStatus))
                .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.ClientId))
                .ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.RoomId))
                .ForMember(dest => dest.IsAvailable, opt => opt.MapFrom(src => src.IsAvailable))
                .ForMember(dest => dest.PaymentHotelRoom, opt => opt.MapFrom(src => src.PaymentHotelRoom))
                .ForMember(dest => dest.ReviewHotelRoom, opt => opt.MapFrom(src => src.ReviewHotelRoom));

            // BookingGuestInRoom ↔ BookingGuestInRoomDTO
            CreateMap<BookingGuestInRoom, BookingGuestInRoomDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.NationalID, opt => opt.MapFrom(src => src.NationalId))
                .ForMember(dest => dest.NationalIDImage, opt => opt.MapFrom(src => src.NationalIDImage))
                .ForMember(dest => dest.BookingHotelRoomId, opt => opt.MapFrom(src => src.BookingHotelRoomId))
                .ForMember(dest => dest.BookingId, opt => opt.MapFrom(src => src.BookingId));

            // PaymentHotelRoom ↔ PaymentHotelRoomDTO
            CreateMap<PaymentHotelRoom, PaymentHotelRoomDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.AmountPaid, opt => opt.MapFrom(src => src.AmountPaid))
                .ForMember(dest => dest.CommissionDeducted, opt => opt.MapFrom(src => src.CommissionDeducted))
                .ForMember(dest => dest.CodeApplied, opt => opt.MapFrom(src => src.CodeApplied))
                .ForMember(dest => dest.PaymentMethod, opt => opt.MapFrom(src => src.PaymentMethod))
                .ForMember(dest => dest.PaymentStatus, opt => opt.MapFrom(src => src.PaymentStatus))
                .ForMember(dest => dest.TransactionDateTime, opt => opt.MapFrom(src => src.TransactionDateTime));

            // ReviewHotelRoom ↔ ReviewHotelRoomDTO
            CreateMap<ReviewHotelRoom, ReviewHotelRoomDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating))
                .ForMember(dest => dest.ReviewDate, opt => opt.MapFrom(src => src.ReviewDate));
        }
    }
}
