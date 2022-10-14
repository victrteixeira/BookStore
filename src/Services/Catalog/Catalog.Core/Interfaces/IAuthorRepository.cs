using Catalog.Core.Entities;

namespace Catalog.Core.Interfaces;

public interface IAuthorRepository : IBaseRepository<Author>
{
    Task<Author?> GetAuthorById(int authorId);
    Task<Author?> GetAuthorByName(string firstname, string lastname);
}