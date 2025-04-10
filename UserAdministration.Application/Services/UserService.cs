using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UserAdministration.Application.Models.History;
using UserAdministration.Application.Models.User;
using UserAdministration.DAL.Models;
using UserAdministration.DAL.Repository;

namespace UserAdministration.Application.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHistoryService _historyService;

        public UserService(IUserRepository userRepository, IHistoryService historyService)
        {
            _userRepository = userRepository;
            _historyService = historyService;
        }

        public async Task AddUser(UserEditDTO user)
        {
            await _userRepository.AddUser(new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                LoginCount = 0
            });
        }

        public async Task DeleteUser(int id)
        {
            await _userRepository.DeleteUser(id);
        }

        public async Task EditUser(int id, UserEditDTO user)
        {
            await _userRepository.EditUser(new User()
            {
                Id = id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password
            });
        }

        public async Task<UserEditDTO?> GetUser(int id)
        {
            var user = await _userRepository.GetUser(id);

            if (user == null)
            {
                return null;
            }

            return new UserEditDTO()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = string.Empty
            };
        }

        public async Task<IEnumerable<UserViewDTO>> GetUsers()
        {
            return await _userRepository.GetUsers()
                .Select(user => new UserViewDTO()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    LoginCount = user.LoginCount
                }).ToListAsync();
        }

        public async Task LoginUser(UserLoginDTO userLogin)
        {
            var user = await _userRepository.GetByCredentials(userLogin.Email, userLogin.Password);

            if (user != null)
            {
                await _userRepository.IncrementLoginCount(user);
                await _historyService.AddHistory(new HistoryAddDTO()
                {
                    Browser = userLogin.Browser,
                    UserId = user.Id
                });
            }
        }
    }
}