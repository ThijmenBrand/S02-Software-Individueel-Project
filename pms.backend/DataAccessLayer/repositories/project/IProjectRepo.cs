using DataLayer.repositories;

namespace DataLayer.repos.project
{
    public interface IProjectRepo<T> : IGenericRepo<T>
    {
        public IEnumerable<T> GetAll(int UserId);
    }
}
