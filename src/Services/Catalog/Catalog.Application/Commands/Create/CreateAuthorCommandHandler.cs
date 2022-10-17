using AutoMapper;
using Catalog.Application.Responses.ForAuthor;
using Catalog.Core.Entities;
using Catalog.Core.Interfaces;
using MediatR;

namespace Catalog.Application.Commands.Create;

public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, AuthorResponse>
{
    private readonly IAuthorRepository _repository;
    private readonly IMapper _mapper;

    public CreateAuthorCommandHandler(IAuthorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AuthorResponse> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        var newAuthor = _mapper.Map<Author>(request);
        
        var data = await _repository.Add(newAuthor);

        return _mapper.Map<AuthorResponse>(data);
    }
}