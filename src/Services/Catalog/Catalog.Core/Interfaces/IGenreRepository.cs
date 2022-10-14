using Catalog.Core.Entities;

namespace Catalog.Core.Interfaces;

public interface IGenreRepository : IBaseRepository<Genre>
{
    Task<Genre?> GetGenre(string genreName, string subgenre);
}