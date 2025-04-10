using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UserAdministration.DAL.Models;

namespace UserAdministration.DAL.Repository
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        Task DeleteUser(int id);
        Task IncrementLoginCount(User user);
        Task<User?> GetByCredentials(string email, string password);
        Task EditUser(User user);
        IQueryable<User> GetUsers();
        Task<User?> GetUser(int id);
    }
}
