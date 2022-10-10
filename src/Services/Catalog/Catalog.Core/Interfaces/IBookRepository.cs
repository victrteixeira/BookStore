using Catalog.Core.Entities;

namespace Catalog.Core.Interfaces;

public interface IBookRepository : IBaseRepository<Book>
{
    Task<Book?> GetBookById(int id);
    Task<Book?> GetBookByName(string bookName);
    Task<IReadOnlyCollection<Book>> GetBooksByPrice(decimal price);
    Task<IReadOnlyCollection<Book>> GetBooksByPriceAndLanguage(string language, decimal price);
    Task<IReadOnlyCollection<Book>> GetBooksByPublisher(string publisher);
    Task<IReadOnlyCollection<Book>> GetBooksByAuthor(int authorId);
    Task<IReadOnlyCollection<Book>?> GetBooksByGenre(string genreName);
}