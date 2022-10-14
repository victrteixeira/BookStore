using AutoMapper;
using Catalog.Application.Commands.Create;
using Catalog.Application.Commands.Update;
using Catalog.Application.Responses;
using Catalog.Application.Responses.ForAuthor;
using Catalog.Application.Responses.ForBook;
using Catalog.Core.Entities;

namespace Catalog.Application.AutoMapper;

public class AuthorMappers : Profile
{
    public AuthorMappers()
    {
        CreateMap<CreateAuthorCommand, Author>()
            .ConstructUsing(x => new Author(x.FirstName, x.LastName, x.BornAt,
                x.DiedAt, x.Country, x.BriefDescription));

        CreateMap<UpdateAuthorCommand, Author>()
            .ConstructUsing(x => new Author(x.FirstName, x.LastName, x.BornAt,
                x.DiedAt, x.Country, x.BriefDescription));

        CreateMap<Author, AuthorResponse>();

        CreateMap<Author, AuthorQueryResponse>()
            .ForMember(dest => dest.Books,
                opt => opt.MapFrom(src => src.Books));
    }
}