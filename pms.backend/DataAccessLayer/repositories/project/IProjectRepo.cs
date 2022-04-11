namespace DataLayer.repos.project
{
    public interface IProjectRepo<T>
    {
        public Task<bool> Create(T entity, int UserId);
        public void Delete(int projectId);
        public void Update(T entity);
        public IEnumerable<T> GetAll(int UserId);
        public T GetById(int id);
    }
}
