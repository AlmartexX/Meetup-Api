using MeetupApi.DAL.Entities;
using MeetupApi.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MeetupApi.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IAppContext _context;

        public UserRepository(IAppContext context)
        {
            _context = context 
                ?? throw new ArgumentNullException();

        }

        public async Task RegisterUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            
        }

        public async Task<User> GetUserByName(string userName)=>
            await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == userName);

    }
}
