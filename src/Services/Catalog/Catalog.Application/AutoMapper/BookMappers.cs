using AutoMapper;
using Catalog.Application.Commands.Create;
using Catalog.Application.Commands.Update;
using Catalog.Application.Responses.ForAuthor;
using Catalog.Application.Responses.ForBook;
using Catalog.Core.Entities;

namespace Catalog.Application.AutoMapper;

public class BookMappers : Profile
{
    public BookMappers()
    {
        #region Create/Update Book

        CreateMap<CreateBookCommand, Book>()
            .ConstructUsing(x => new Book
                (x.Name, x.Pages, x.Price, x.Language, x.Publisher, x.AuthorId))
            .ForMember(dest => dest.Genre,
                opt => opt.Ignore());

        CreateMap<UpdateBookCommand, Book>()
            .ConstructUsing(x => new Book
                (x.Name, x.Pages, x.Price, x.Language, x.Publisher, x.AuthorId, x.GenreId));

        #endregion

        #region Book Query
        
        CreateMap<Author, AuthorResponseForBook>();
        
        CreateMap<Genre, GenreQueryResponse>();

        CreateMap<Book, BookQueryResponse>()
            .ForMember(dest => dest.Author,
                opt => opt.MapFrom(src => src.Author))
            .ForMember(dest => dest.Genre,
                opt => opt.MapFrom(src => src.Genre));
            
        CreateMap<Book, BookResponse>()
            .ForMember(dest => dest.Genre,
                opt => opt.MapFrom(src => src.Genre));

        #endregion
    }
}