namespace DataLayer.repos.task
{
    public interface ITasksRepo<T>
    {
        public Task<bool> Create(T entity);
        public IEnumerable<T> GetTasksByProject(int id);
        public Task<bool> UpdateTaskTag(int id, string newTag);
        public Task<bool> UpdateTask(T entity);
        public Task<bool> DeleteTask(int id);
    }
}
