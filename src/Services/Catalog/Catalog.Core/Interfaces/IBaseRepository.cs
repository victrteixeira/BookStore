using Catalog.Core.Entities;

namespace Catalog.Core.Interfaces;

public interface IBaseRepository<T> where T : Base
{
    Task<T> Add(T entity);
    Task<T?> Update(T entity, object key);
    Task<int> Remove(T entity);
    Task<T?> GetById(int id);
    Task<IEnumerable<T>> GetAll();
}