
using DataLayer.repositories;

namespace DataLayer.repos.task
{
    public interface ITasksRepo<T> : IGenericRepo<T>
    {
        public Task<List<T>> GetTasksBySprint(int SprintId);
        public Task<bool> UpdateTaskTag(int id, string newTag);
        IEnumerable<T> GetAllTasks(int projectId);
    }
}
