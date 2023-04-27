using MeetupApi.DAL.Modells;

namespace MeetupApi.DAL.Interfaces
{
    public interface IRepository
    {
        Task<IEnumerable<Event>> GetEventsAsync();

        Task<Event> GetEventByIdAsync(int id);

        Task CreateEventAsync(Event @event);

        Task UpdateEventAsync(Event @event);
     
        Task DeleteEventAsync(int id);

    }
}
