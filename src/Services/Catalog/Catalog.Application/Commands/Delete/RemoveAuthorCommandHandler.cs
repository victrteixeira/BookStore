using AutoMapper;
using Catalog.Application.Exceptions;
using Catalog.Core.Interfaces;
using MediatR;

namespace Catalog.Application.Commands.Delete;

public class RemoveAuthorCommandHandler : IRequestHandler<RemoveAuthorCommand, int>
{
    private readonly IAuthorRepository _repository;
    private readonly IMapper _mapper;

    public RemoveAuthorCommandHandler(IAuthorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<int> Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
    {
        var data = await _repository.Remove(request.AuthorId);
        if (data == 0)
            throw new QueryException("Author not found or doesn't exist.");

        return data;
    }
}