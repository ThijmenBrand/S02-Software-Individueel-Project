using DataAccessLayer.Models;
using DataLayer.models.users;
using DataLayer.repositories;

namespace DataLayer.repos.users
{
    public interface IUsersRepo<T> : IGenericRepo<T>
    {
        public User? FindUser(string UserEmail);
    }
}
