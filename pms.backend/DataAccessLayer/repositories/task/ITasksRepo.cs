
namespace DataLayer.repos.task
{
    public interface ITasksRepo<T>
    {
        public Task<bool> Create(T entity);
        public IEnumerable<T> GetTasksBySprint(int SprintId);
        public Task<bool> UpdateTaskTag(int id, string newTag);
        public Task<bool> UpdateTask(T entity);
        public Task<bool> DeleteTask(int id);
        IEnumerable<T> GetAllTasks(int projectId);
        public T GetTaskById(int id);
    }
}
