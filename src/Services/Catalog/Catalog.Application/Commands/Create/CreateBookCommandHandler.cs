using AutoMapper;
using Catalog.Core.Entities;
using Catalog.Core.Interfaces;
using MediatR;

namespace Catalog.Application.Commands.Create;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, CreateBookCommand>
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

    public async Task<CreateBookCommand> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var checkGenre = await _genreRepository.GetGenre(request.Genre.Name, request.Genre.SubGenre);

        if (checkGenre == null)
        {
            var newGenre = new Genre(request.Genre.Name, request.Genre.SubGenre, request.Genre.BriefDescription);
            var genre = await _genreRepository.Add(newGenre);

            var bookOutIf = _mapper.Map<Book>(request);
            bookOutIf.UpdateGenreId(genre.GenreId);

            await _bookRepository.Add(bookOutIf);

            return request;
        }

        var iBook = _mapper.Map<Book>(request);
        iBook.UpdateGenreId(checkGenre.GenreId);

        await _bookRepository.Add(iBook);
        return request;
    }
}