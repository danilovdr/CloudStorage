using System;
using System.Linq;

namespace CloudStorage.DAL.Interfaces.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T Get(long id);
        IQueryable<T> Find(Func<T, bool> predicate);
        long Create(T item);
        void Update(T item);
        void Delete(long id);
    }
}
