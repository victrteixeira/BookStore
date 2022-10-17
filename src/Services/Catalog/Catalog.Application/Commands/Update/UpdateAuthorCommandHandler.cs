using AutoMapper;
using Catalog.Application.Exceptions;
using Catalog.Application.Responses.ForAuthor;
using Catalog.Core.Entities;
using Catalog.Core.Interfaces;
using MediatR;

namespace Catalog.Application.Commands.Update;

public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, AuthorResponse>
{
    private readonly IAuthorRepository _repository;
    private readonly IMapper _mapper;

    public UpdateAuthorCommandHandler(IAuthorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AuthorResponse> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var newAuthor = _mapper.Map<Author>(request);
            
        var data = await _repository.Update(newAuthor, request.AuthorId);

        if (data is null)
            throw new QueryException("Couldn't find referenced author.");

        return _mapper.Map<AuthorResponse>(data);
    }
}