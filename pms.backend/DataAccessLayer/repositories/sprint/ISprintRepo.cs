namespace DataLayer.repos.sprint
{
    public interface ISprintRepo<T>
    {
        public Task<bool> Create(T entity);
        public IEnumerable<T> GetAllByProject(int projectId);
        public IEnumerable<T> GetSprintDetails(int sprintId);
        public Task<bool> UpdateSprintDetails(T entity);
    }
}
