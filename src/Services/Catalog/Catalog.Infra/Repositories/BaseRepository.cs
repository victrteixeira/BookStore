using Catalog.Core.Entities;
using Catalog.Core.Interfaces;
using Catalog.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infra.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : Base
{
    private readonly CatalogContext _context;
    public BaseRepository(CatalogContext context) => _context = context;

    public virtual async Task<T> Add(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public virtual async Task<T?> Update(T entity, object key)
    {
        T? exist = await _context.Set<T>().FindAsync(key);
        if (exist is null)
            return null;
        
        _context.Entry(exist).CurrentValues.SetValues(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<int> Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
        return await _context.SaveChangesAsync();
    }

    public virtual async Task<T?> GetById(int id) => await _context.Set<T>().FindAsync(id) ?? null;

    public virtual async Task<IEnumerable<T>> GetAll() => await _context.Set<T>().AsNoTracking().ToListAsync();
}