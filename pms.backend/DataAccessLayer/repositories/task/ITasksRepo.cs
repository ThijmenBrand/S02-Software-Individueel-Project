﻿namespace DataLayer.repos.task
{
    public interface ITasksRepo<T>
    {
        public Task<bool> Create(T entity);
        public IEnumerable<T> GetTasksByProject(int id);
        public Task<bool> UpdateTaskTag(int id, string newTag);
/*        public Task<bool> Update(T entity);
        public bool Delete(T entity);
        public T GetById(int id);*/
    }
}