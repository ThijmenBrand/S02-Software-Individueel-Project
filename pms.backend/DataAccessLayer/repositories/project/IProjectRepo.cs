using DataLayer.repositories;

namespace DataLayer.repos.project
{
    public interface IExecuteServiceProject<T> : IGenericRepo<T>
    {
        public IEnumerable<T> GetAll(int UserId);
    }
}
