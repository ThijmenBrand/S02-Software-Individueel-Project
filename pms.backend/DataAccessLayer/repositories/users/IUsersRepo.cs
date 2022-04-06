using DataAccessLayer.Models;
using DataLayer.models.users;

namespace DataLayer.repos.users
{
    public interface IUsersRepo<T>
    {
        public User? FindUser(string UserEmail);
        public void Register(User User);
        public void Update(User User);
        public void Delete(User user);
        public User GetUserById(int UserId);
    }
}
