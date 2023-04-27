
using MeetupApi.DAL.Entities;
using MeetupApi.DAL.Interfaces;
using MeetupApi.DAL.Modells;
using Microsoft.EntityFrameworkCore;

namespace MeetupApi.DAL.Context
{
    public class ApplicationContext : DbContext, IAppContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
     
    }
}
