using AutoMapper;
using Catalog.Application.Commands.Create;
using Catalog.Application.Commands.Update;
using Catalog.Application.Responses;
using Catalog.Application.Responses.ForBook;
using Catalog.Core.Entities;

namespace Catalog.Application.AutoMapper;

public class BookMappers : Profile
{
    public BookMappers()
    {
        CreateMap<CreateBookCommand, Book>()
            .ConstructUsing(x => new Book(
                x.Name, x.Pages, x.Price, x.Language, x.Publisher, x.AuthorId))
            .ForSourceMember(x => x.Genre,
                opt => opt.DoNotValidate());

        CreateMap<UpdateBookCommand, Book>()
            .ConstructUsing(x => new Book(
                x.Name, x.Pages, x.Price, x.Language, x.Publisher, x.AuthorId));

        CreateMap<Book, BookResponse>();
    }
}