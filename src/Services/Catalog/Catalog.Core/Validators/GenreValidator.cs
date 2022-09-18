using Catalog.Core.Entities;
using FluentValidation;
using Type = Catalog.Core.Entities.Type;

namespace DefaultNamespace;

public class GenreValidator : AbstractValidator<Genre>
{
    public GenreValidator()
    {
        RuleFor(name => name.Name)
            .Length(3, 60).WithMessage("{PropertyName} must be between 3 and 60 chars.");
        
        RuleFor(subgenre => subgenre.SubGenre)
            .Length(3, 60).WithMessage("{PropertyName} must be between 3 and 60 chars.");

        RuleFor(type => type.Type)
            .IsInEnum().WithMessage("{PropertyName} must be: Fiction or NonFiction");
        
        RuleFor(desc => desc.BriefDescription)
            .Length(3, 100).WithMessage("{PropertyName} must be between 3 and 100 chars.");
    }
}