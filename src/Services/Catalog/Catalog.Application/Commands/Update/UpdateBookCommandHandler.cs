using AutoMapper;
using Catalog.Application.Exceptions;
using Catalog.Core.Entities;
using Catalog.Core.Interfaces;
using MediatR;

namespace Catalog.Application.Commands.Update;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, UpdateBookCommand>
{
    private readonly IBookRepository _repository;
    private readonly IMapper _mapper;

    public UpdateBookCommandHandler(IBookRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UpdateBookCommand> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var newBook = _mapper.Map<Book>(request);
        var updated = await _repository.Update(newBook, request.BookId);
        if (updated is null)
            throw new QueryException("No book was found with this Id to update");

        return request;
    }
}