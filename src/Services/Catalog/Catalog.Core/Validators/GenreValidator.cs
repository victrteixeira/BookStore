using Catalog.Core.Entities;
using FluentValidation;

namespace Catalog.Core.Validators;

public class GenreValidator : AbstractValidator<Genre>
{
    public GenreValidator()
    {
        RuleFor(name => name.Name)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("{PropertyName} is required and can not be null.")
            .NotEmpty().WithMessage("{PropertyName} is required and can not be empty.")
            .Length(3, 60).WithMessage("{PropertyName} must be between 3 and 60 chars.");
        
        RuleFor(subgenre => subgenre.SubGenre)
            .Length(3, 60).WithMessage("{PropertyName} must be between 3 and 60 chars.");

        RuleFor(desc => desc.BriefDescription)
            .Length(3, 100).WithMessage("{PropertyName} must be between 3 and 100 chars.");
    }
}