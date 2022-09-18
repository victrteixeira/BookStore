using System.Data;
using System.Text.RegularExpressions;
using Catalog.Core.Entities;
using FluentValidation;

namespace DefaultNamespace;

public class AuthorValidator : AbstractValidator<Author>
{
    public AuthorValidator()
    {
        RuleFor(name => name.Name)
            .NotNull().WithMessage("{PropertyName} is required and can not be null.")
            .NotEmpty().WithMessage("{PropertyName} is required and can not be empty.")
            .Length(3, 50).WithMessage("{PropertyName} must be between 3 and 50 chars.")
            .Matches(@"^[0-9a-zA-Z']{3,50}$");

        RuleFor(born => born.Born)
            .NotNull().WithMessage("{PropertyName} is required and can not be null.")
            .NotEmpty().WithMessage("{PropertyName} is required and can not be empty.")
            .Length(1, 5).WithMessage("{PropertyName} must be between 1 and 5 chars.")
            .Matches(@"^[0-9]{1,5}(?:BC|AD)?$", RegexOptions.IgnoreCase);
        
        RuleFor(born => born.Died)
            .NotNull().WithMessage("{PropertyName} is required and can not be null.")
            .NotEmpty().WithMessage("{PropertyName} is required and can not be empty.")
            .Length(1, 5).WithMessage("{PropertyName} must be between 1 and 5 chars.")
            .Matches(@"^[0-9]{1,5}(?:BC|AD)?$", RegexOptions.IgnoreCase);

        RuleFor(age => age.Age)
            .NotNull().WithMessage("{PropertyName} is required and can not be null.")
            .NotEmpty().WithMessage("{PropertyName} is required and can not be empty.")
            .GreaterThanOrEqualTo(18).WithMessage("{PropertyName} must be greater than or equal to eighteen")
            .LessThanOrEqualTo(120).WithMessage("{PropertyName} must be less than or equal to one hundred and twenty");

        RuleFor(country => country.Country)
            .Length(3, 50).WithMessage("{PropertyName} must be between 3 and 50 chars.");
        
        RuleFor(desc => desc.BriefDescription)
            .Length(3, 100).WithMessage("{PropertyName} must be between 3 and 100 chars.");
    }
}