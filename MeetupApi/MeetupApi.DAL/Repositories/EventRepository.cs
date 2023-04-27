using MeetupApi.DAL.Interfaces;
using MeetupApi.DAL.Modells;
using Microsoft.EntityFrameworkCore;

namespace MeetupApi.DAL.Repositories
{
    public class EventRepository : IRepository
    {
        private readonly IAppContext _context;
        public EventRepository(IAppContext context)
        {
            _context = context
                ?? throw new ArgumentNullException();

        }

        public async Task<IEnumerable<Event>> GetEventsAsync() =>
             await _context.Events
             .AsNoTracking()
             .ToListAsync();

        public async Task<Event> GetEventByIdAsync(int id) =>
             await _context.Events
             .AsNoTracking()
             .FirstOrDefaultAsync(e => e.EventId == id);


        public async Task CreateEventAsync(Event @event)
        {
            await _context.Events.AddAsync(@event);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateEventAsync(Event @event)
        {
            _context.Events.Update(@event);
            await _context.SaveChangesAsync();
           
        }

        public async Task DeleteEventAsync(int id)
        {
            var eventToDelete = await _context.Events.FindAsync(id);
            _context.Events.Remove(eventToDelete);
            await _context.SaveChangesAsync();

        }
    }
}
