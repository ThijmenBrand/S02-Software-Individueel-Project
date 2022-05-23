using DataLayer.repositories;

namespace DataLayer.repos.sprint
{
    public interface ISprintRepo<T> : IGenericRepo<T>
    {
        public IEnumerable<T> GetAllByProject(int projectId);
    }
}
