using AutoMapper;
using DataAccessLayer.Models;
using DataLayer.models.users;
using DataLayer.repos.users;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.services.Users
{
    public class UserService : IUsersService
    {
        private readonly IMapper _mapper;
        private readonly IUsersRepo<User> _repository;

        public UserService(IUsersRepo<User> _repository, IMapper mapper)
        {
            this._repository = _repository;
            this._mapper = mapper;
        }

        public User? FindUser(string UserEmail)
        {
            return _repository.FindUser(UserEmail);
        }

        public bool ValidatePassword(string requestPassword, string userPassword)
        {
            return BCrypt.Net.BCrypt.Verify(requestPassword, userPassword);
        }

        public void Register(RegisterRequest request)
        {
            var user = _mapper.Map<User>(request);
            user.UserPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            _repository.Register(user);
        }

        public User GetById(int UserId)
        {
            return _repository.GetUserById(UserId);
        }

        public User GetMe(int UserId)
        {
            return _repository.GetUserById(UserId);
        }

        public void UpdateUser(int UserId, updateRequest request)
        {
            var user = _repository.GetUserById(UserId);

            if (!string.IsNullOrEmpty(request.Password))
                user.UserPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            _mapper.Map(request, user);

            _repository.Update(user);
        }

        public void DeleteUser(int UserId)
        {
            var user = _repository.GetUserById(UserId);

            _repository.Delete(user);
        }
    }
}
