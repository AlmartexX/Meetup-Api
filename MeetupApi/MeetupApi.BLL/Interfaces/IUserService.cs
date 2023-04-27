using MeetupApi.BLL.DTO;

namespace MeetupApi.BLL.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> Register(UserDTO userDTO);
        Task<bool> Authenticate(string name, string password);
    }
}
