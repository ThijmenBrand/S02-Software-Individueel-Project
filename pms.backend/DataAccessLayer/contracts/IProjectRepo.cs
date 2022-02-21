using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.contracts
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
