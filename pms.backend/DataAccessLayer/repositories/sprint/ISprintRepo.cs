namespace DataLayer.repos.sprint
{
    public interface ISprintRepo<T>
    {
        public Task<bool> Create(T entity);
        public IEnumerable<T> GetAllByProject(int projectId);
    }
}
