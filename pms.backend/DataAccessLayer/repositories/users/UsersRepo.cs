using DataAccessLayer.data;
using DataAccessLayer.Models;
using DataLayer.models.users;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.repos.users
{
    public class UsersRepo : IUsersRepo<User>
    {
        private readonly DataContext _DataContext;

        public UsersRepo(DataContext dataContext)
        {
            _DataContext = dataContext;
        }

        public User? FindUser(string UserEmail)
        {
            return _DataContext.user.SingleOrDefault(x => x.UserEmail == UserEmail);
        }

        public async Task<bool> Create(User User, int? userId)
        {
            if (_DataContext.user.Any(x => x.UserEmail == User.UserEmail))
                throw new ApplicationException($"UserEmail {User.UserEmail} is already taken");

            _DataContext.user.Add(User);
            await _DataContext.SaveChangesAsync();

            return true;
        }

        public async Task Update(User User)
        {
            _DataContext.user.FromSqlInterpolated($"UPDATE dbo.user SET UserName = {User.UserName}, UserEmail = {User.UserEmail}, UserPassword = {User.UserPassword} WHERE UserId = {User.UserId}");
            await _DataContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _DataContext.user.FromSqlInterpolated($"DELETE FROM dbo.user WHERE UserId = {id}");
            await _DataContext.SaveChangesAsync();
        }

        public async Task<User> GetById(int Userid)
        {
            var user = await _DataContext.user.FromSqlInterpolated($"SELECT * FROM dbo.user WHERE UserId = {Userid}").FirstOrDefaultAsync();
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }
    }
}
