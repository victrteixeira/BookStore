using Catalog.Core.Entities;

namespace Catalog.Core.Interfaces;

public interface IBookRepository : IBaseRepository<Book>
{
    Task<Book?> GetBookByName(string bookName);
    Task<IEnumerable<Book>> GetBooksByPrice(decimal price);
    Task<IEnumerable<Book>> GetBooksByPriceAndLanguage(string language, decimal price);
    Task<IEnumerable<Book>> GetBooksByPublisher(string publisher);
    Task<IEnumerable<Book>> GetBooksByAuthor(int authorId);
    Task<IEnumerable<Book>> GetBooksByGenre(string genreName);
}