using Catalog.Core.Entities;
using Catalog.Core.Interfaces;
using Catalog.Infra.Database;

namespace Catalog.Infra.Repositories;

public class GenreRepository : BaseRepository<Genre>, IGenreRepository
{
    public GenreRepository(CatalogContext context) : base(context)
    {
    }
}