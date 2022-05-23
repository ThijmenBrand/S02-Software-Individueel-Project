using DataAccessLayer.Models;
using DataLayer.models.users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.services.Users
{
    public interface IUsersService
    {
        public User? FindUser(string UserEmail);
        public void Register(AccountRequest request);
        public Task UpdateUser(int UserId, AccountRequest request);
        public void DeleteUser(int UserId);
        public Task<User> GetMe(int UserId);
        public bool ValidatePassword(string requestPassword, string userPassword);
    }
}
