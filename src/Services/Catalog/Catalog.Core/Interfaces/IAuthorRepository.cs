using Catalog.Core.Entities;

namespace Catalog.Core.Interfaces;

public interface IAuthorRepository : IBaseRepository<Author>
{
    Task<Author?> GetAuthorByName(string firstName, string lastName);
}