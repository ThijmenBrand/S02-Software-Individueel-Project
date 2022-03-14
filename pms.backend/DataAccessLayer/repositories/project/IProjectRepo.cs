namespace DataLayer.repos.project
{
    public interface IProjectRepo<T>
    {
        public Task<bool> Create(T entity);
        public void Delete(T entity);
        public void Update(T entity);
        public IEnumerable<T> GetAll();
        public T GetById(int id);
    }
}
