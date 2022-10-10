using Catalog.Application.Exceptions;
using Catalog.Core.Interfaces;
using MediatR;

namespace Catalog.Application.Commands.Delete;

public class RemoveBookCommandHandler : IRequestHandler<RemoveBookCommand, int>
{
    private readonly IBookRepository _repository;

    public RemoveBookCommandHandler(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(RemoveBookCommand request, CancellationToken cancellationToken)
    {
        var res = await _repository.Remove(request.BookId);
        if (res == 0)
            throw new QueryException("Book wasn't found, nothing was removed");

        return res;
    }
}