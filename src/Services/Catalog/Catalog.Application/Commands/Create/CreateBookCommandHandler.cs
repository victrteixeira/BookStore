using AutoMapper;
using Catalog.Application.Responses;
using Catalog.Application.Responses.ForBook;
using Catalog.Core.Entities;
using Catalog.Core.Interfaces;
using MediatR;

namespace Catalog.Application.Commands.Create;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, BookResponse>
{
    private readonly IBookRepository _bookRepository;
    private readonly IGenreRepository _genreRepository;
    private readonly IMapper _mapper;

    public CreateBookCommandHandler(IBookRepository repository, IGenreRepository genreRepository, IMapper mapper)
    {
        _bookRepository = repository;
        _genreRepository = genreRepository;
        _mapper = mapper;
    }

    public async Task<BookResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var newGenre = new Genre(request.Genre.Genre, request.Genre.SubGenre, request.Genre.BriefDescription);
        var book = _mapper.Map<Book>(request);

        var genreForBook = new GenreBook();

        genreForBook.Book = book;
        genreForBook.Genre = newGenre;

        book.Genres.Add(genreForBook);

        await _genreRepository.Add(newGenre);
        
        
        var newBook = await _bookRepository.Add(book);
        return _mapper.Map<BookResponse>(newBook);
    }
}
// TODO > Implement to create book with already created genre, passing as parameter GenreId to map between them.
