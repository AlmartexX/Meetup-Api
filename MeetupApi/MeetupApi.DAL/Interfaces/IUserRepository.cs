using MeetupApi.DAL.Entities;

namespace MeetupApi.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task RegisterUser(User user);

        Task<User> GetUserByName(string userName);


    }
}
