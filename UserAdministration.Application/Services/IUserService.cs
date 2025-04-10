using System.Net;
using System.Security.Cryptography;
using UserAdministration.Application.Models.User;
using UserAdministration.DAL.Models;

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