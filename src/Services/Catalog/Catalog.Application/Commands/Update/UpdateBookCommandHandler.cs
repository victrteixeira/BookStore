using AutoMapper;
using Catalog.Application.Exceptions;
using Catalog.Application.Responses;
using Catalog.Application.Responses.ForBook;
using Catalog.Core.Entities;
using Catalog.Core.Interfaces;
using MediatR;

namespace Catalog.Application.Commands.Update;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, BookResponse>
{
    private readonly IBookRepository _repository;
    private readonly IMapper _mapper;

    public UpdateBookCommandHandler(IBookRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<BookResponse> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var oldBook = _mapper.Map<Book>(request);
        var newBook = await _repository.Update(oldBook, request.BookId);
        if (newBook is null)
            throw new QueryException("No book was found with this Id to update");

        return _mapper.Map<BookResponse>(newBook);
    }
}