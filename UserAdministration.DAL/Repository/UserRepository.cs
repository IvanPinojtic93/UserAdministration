﻿using Microsoft.EntityFrameworkCore;
using UserAdministration.DAL.Models;

namespace UserAdministration.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserAdministrationContext _context;
        public UserRepository(UserAdministrationContext context)
        {
            this._context = context;
        }

        public async Task AddUser(User user)
        {
            await CheckValidEmail(user);

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task EditUser(User user)
        {
            await CheckValidEmail(user);

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            _context.Update(user);
            _context.Entry(user).Property(u => u.LoginCount).IsModified = false;
            await _context.SaveChangesAsync();
        }

        private async Task CheckValidEmail(User user)
        {
            var existingUser = await GetByEmail(user.Email);

            if (existingUser != null)
            {
                if (user.Id != existingUser.Id)
                {
                    throw new Exception("User with this email address already exists.");
                }
                _context.Entry(existingUser).State = EntityState.Detached;
            }
        }

        public async Task<User> GetByCredentials(string email, string password)
        {
            var user = await GetByEmail(email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                throw new Exception("Invalid credentials.");
            }

            return user;
        }

        public IQueryable<User> GetUsers()
        {
            return _context.Users;
        }

        public async Task<User?> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task IncrementLoginCount(User user)
        {
            user.LoginCount++;

            _context.Entry(user).Property(u => u.LoginCount).IsModified = true;
            await _context.SaveChangesAsync();
        }

        private async Task<User?> GetByEmail(string email)
        {
            return await _context.Users.Where(user => user.Email == email).FirstOrDefaultAsync();
        }
    }
}
