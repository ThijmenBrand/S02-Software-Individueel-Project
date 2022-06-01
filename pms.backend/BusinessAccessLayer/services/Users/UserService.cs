using AutoMapper;
using DataAccessLayer.Models;
using DataLayer.models.users;
using DataLayer.repos.users;

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

        public void Register(AccountRequest request)
        {
            var user = _mapper.Map<User>(request);
            user.UserPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            _repository.Create(user, null);
        }

        public async Task<User> GetById(int UserId)
        {
            return await _repository.GetById(UserId);
        }

        public async Task<User> GetMe(int UserId)
        {
            return await _repository.GetById(UserId);
        }

        public async Task UpdateUser(int UserId, AccountRequest request)
        {
            var user = await _repository.GetById(UserId);

            if (!string.IsNullOrEmpty(request.Password))
                user.UserPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            _mapper.Map(request, user);

            await _repository.Update(user);
        }

        public void DeleteUser(int UserId)
        {
            _repository.Delete(UserId);
        }
    }
}
