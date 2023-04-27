using AutoMapper;
using MeetupApi.BLL.DTO;
using MeetupApi.DAL.Entities;
using MeetupApi.DAL.Modells;

namespace MeetupApi.BLL.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Event, EventDTO>();
            CreateMap<EventDTO, Event>();
            CreateMap<CreateEventDTO, Event>();
            CreateMap<UpdateEventDTO, Event>();
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

        }
    }
}
