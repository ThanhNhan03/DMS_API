using AutoMapper;
using DMS_API.Models.Domain;
using DMS_API.Models.DTO;
using DMS_API.Models.DTO.Request;

namespace DMS_API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            //Domain to DTO and reverse
            CreateMap<Dorm, DormDTO>().ReverseMap();
            CreateMap<Floor, FloorDTO>();
            CreateMap<House, HouseDTO>()
                .ForMember(dest => dest.FloorName, opt => opt.MapFrom(src => src.Floor.Name));
            //.ForMember(dest => dest.Rooms, opt => opt.MapFrom(src => src.Rooms)); 

            CreateMap<Room, RoomDTO>()
                  .ForMember(dest => dest.HouseName, opt => opt.MapFrom(src => src.House.Name))
                .ForMember(dest => dest.FloorName, opt => opt.MapFrom(src => src.House.Floor.Name))
                .ForMember(dest => dest.DormName, opt => opt.MapFrom(src => src.House.Floor.Dorm.Name));
            
            CreateMap<AppUser, AppUserDTO>();
            CreateMap<Balance, BalanceDTO>();
            CreateMap<Booking, BookingDTO>()
                .ForMember(dest => dest.RoomName, opt => opt.MapFrom(src => src.Room.Name))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.House, opt => opt.MapFrom(src => src.Room.House)); // Map house information

            CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));


            //Request DTOs
            CreateMap<AddFloorRequestDTO, Floor>();
            CreateMap<UpdateFloorRequestDTO, Floor>();
            CreateMap<AddHouseRequestDTO, House>();
            CreateMap<UpdateHouseRequestDTO, House>();
            CreateMap<UpdateUserRequestDTO, AppUser>();
            CreateMap<AddProfileInfoRequestDTO, AppUser>();
            CreateMap<Booking, CreateBookingRequestDTO>().ReverseMap();
            CreateMap<Booking, UpdateBookingRequestDTO>().ReverseMap().ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
            CreateMap<UpdateRoomRequestDTO, Room>();
        }
    }
}