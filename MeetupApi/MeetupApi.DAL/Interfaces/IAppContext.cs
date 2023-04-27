using MeetupApi.DAL.Entities;
using MeetupApi.DAL.Modells;
using Microsoft.EntityFrameworkCore;

namespace MeetupApi.DAL.Interfaces
{
    public interface IAppContext : IDisposable
    {
        DbSet<Event> Events { get; }
        DbSet<User> Users { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
