using System.Text.RegularExpressions;
using Catalog.Core.Entities;
using Catalog.Core.Exceptions;
using FluentValidation;

namespace Catalog.Core.Validators;

public class AuthorValidator : AbstractValidator<Author>
{
    public AuthorValidator()
    {
        RuleFor(firstName => firstName.FirstName)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("{PropertyName} is required and can not be null.")
            .NotEmpty().WithMessage("{PropertyName} is required and can not be empty.")
            .Length(3, 50).WithMessage("{PropertyName} must be between 3 and 50 chars.")
            .Matches(@"^[0-9a-zA-Z']{3,50}$", RegexOptions.IgnoreCase)
            .WithMessage("{PropertyName} contain invalid char or are outside of range allowed.");

        RuleFor(lastname => lastname.LastName)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("{PropertyName} is required and can not be null.")
            .NotEmpty().WithMessage("{PropertyName} is required and can not be empty.")
            .Length(3, 50).WithMessage("{PropertyName} must be between 3 and 50 chars.")
            .Matches(@"^[0-9a-zA-Z']{3,50}$", RegexOptions.IgnoreCase)
            .WithMessage("{PropertyName} contain invalid char or are outside of range allowed.");

        RuleFor(born => born.BornAt)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("{PropertyName} is required and can not be null.")
            .NotEmpty().WithMessage("{PropertyName} is required and can not be empty.")
            .Length(1, 6).WithMessage("{PropertyName} must be between 1 and 6 chars.")
            .Matches(@"^[0-9]{1,4}(?:BC|AD)?$", RegexOptions.IgnoreCase)
            .WithMessage("{PropertyName} are outside of range or contain invalid char.");

        RuleFor(died => died.DiedAt)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("{PropertyName} is required and can not be null.")
            .NotEmpty().WithMessage("{PropertyName} is required and can not be empty.")
            .Length(1, 6).WithMessage("{PropertyName} must be between 1 and 4 chars.")
            .Matches(@"^[0-9]{1,4}(?:BC|AD)?$", RegexOptions.IgnoreCase)
            .WithMessage("{PropertyName} are outside of range or contain invalid char.")
            .Custom((c, x) =>
            {
                var resDied = c.Length > 4 ? Convert.ToInt32(c.Substring(0, 4)) : Convert.ToInt32(c);
                var born = x.InstanceToValidate.BornAt;
                var resBorn = born.Length > 4 ? Convert.ToInt32(born.Substring(0, 4)) : Convert.ToInt32(born);
                DomainException.When(resDied <= resBorn,
                    "A person can not die before to born. Please insert valid dates.");
            });

        RuleFor(country => country.Country)
            .Length(3, 60).WithMessage("{PropertyName} must be between 3 and 60 chars.");

        RuleFor(desc => desc.BriefDescription)
            .Length(3, 100).WithMessage("{PropertyName} must be between 3 and 100 chars.");
    }
}