using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.repositories
{
    public interface IGenericRepo<T>
    {
        public Task<bool> Create(T entity, int? userId);
        public Task Update(T entity);
        public Task Delete(int id);
        public Task<T> GetById(int id);
    }
}
