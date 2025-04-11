using UserAdministration.Application.Models.User;

namespace UserAdministration.Application.Services
{
    public interface IUserService
    {
        Task AddUser(UserEditDTO user);
        Task LoginUser(UserLoginDTO userLogin);
        Task DeleteUser(int id);
        Task<IEnumerable<UserViewDTO>> GetUsers();
        Task<UserEditDTO?> GetUser(int id);
        Task EditUser(int id, UserEditDTO user);
    }
}