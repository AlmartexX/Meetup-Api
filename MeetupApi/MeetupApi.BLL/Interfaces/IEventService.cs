using MeetupApi.BLL.DTO;

namespace MeetupApi.BLL.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<EventDTO>> GetEventsAsync();
        Task<EventDTO> GetEventByIdAsync(int? id);
        Task<CreateEventDTO> CreateEventAsync(CreateEventDTO newEvent);
        Task<UpdateEventDTO> UpdateEventAsync(UpdateEventDTO eventDTO, int? id);
        Task<(bool, string)> DeleteEventAsync(int? id);
    }
}
