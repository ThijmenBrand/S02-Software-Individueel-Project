using DataAccessLayer.data;
using DataAccessLayer.Models;
using DataLayer.models.users;

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

        public void Register(User User)
        {
            if (_DataContext.user.Any(x => x.UserEmail == User.UserEmail))
                throw new ApplicationException($"UserEmail {User.UserEmail} is already taken");

            _DataContext.user.Add(User);
            _DataContext.SaveChanges();
        }

        public void Update(User User)
        {
            _DataContext.user.Update(User);
            _DataContext.SaveChanges();
        }

        public void Delete(User user)
        {
            _DataContext.user.Remove(user);
            _DataContext.SaveChanges();
        }

        public User GetUserById(int Userid)
        {
            var user = _DataContext.user.Find(Userid);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }
    }
}
