using Catalog.Core.Entities;
using FluentValidation;

namespace Catalog.Core.Validators;

public class BookValidator : AbstractValidator<Book>
{
    public BookValidator()
    {
        RuleFor(name => name.Name)
            .NotNull().WithMessage("{PropertyName} is required and can not be null.")
            .NotEmpty().WithMessage("{PropertyName} is required and can not be empty.")
            .Length(3, 150).WithMessage("{PropertyName} must be between 3 and 150 chars.");

        RuleFor(pages => pages.Pages)
            .NotNull().WithMessage("{PropertyName} is required and can not be null.")
            .NotEmpty().WithMessage("{PropertyName} is required and can not be empty.")
            .GreaterThanOrEqualTo(1)
            .WithMessage("{PropertyName} is required and must be greater than or equal to eighteen");

        RuleFor(price => price.Price)
            .NotNull().WithMessage("{PropertyName} is required and can not be null.")
            .NotEmpty().WithMessage("{PropertyName} is required and can not be empty.")
            .ScalePrecision(2, 6)
            .WithMessage("{PropertyName} are outside of scale precision")
            .GreaterThanOrEqualTo(0.5m).WithMessage("{PropertyName} must be greater than or equal to 0.5")
            .LessThanOrEqualTo(999999.99m)
            .WithMessage("{PropertyName} is required and must be less than or equal to nine hundred ninety nine thousand nine hundred ninety nine (999999");

        RuleFor(language => language.Language)
            .NotNull().WithMessage("{PropertyName} is required and can not be null.")
            .NotEmpty().WithMessage("{PropertyName} is required and can not be empty.")
            .Length(1, 30).WithMessage("{PropertyName} must be between 1 and 30 chars.");
        
        RuleFor(publisher => publisher.Publisher)
            .Length(1, 50).WithMessage("{PropertyName} must be between 1 and 50 chars.");
    }
}