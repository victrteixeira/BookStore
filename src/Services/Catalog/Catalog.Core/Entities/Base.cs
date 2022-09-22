using System.Text;
using Catalog.Core.Exceptions;
using FluentValidation;
using FluentValidation.Results;

namespace Catalog.Core.Entities;

public abstract class Base
{
    private List<string> _errors = new();
    public IReadOnlyCollection<string> Errors => _errors;
    private bool IsValid() => _errors.Count == 0;

    private void AddErrorList(IList<ValidationFailure> errors)
    {
        foreach (var error in errors)
        {
            _errors.Add(error.ErrorMessage);
        }
    }
    
    private string ErrorsToString()
    {
        var builder = new StringBuilder();
        foreach (var error in Errors)
        {
            builder.AppendLine(error);
        }

        return builder.ToString();
    }

    protected virtual bool Validate<T, TJ>(T validator, TJ obj) where T : AbstractValidator<TJ>
    {
        var validation = validator.Validate(obj);
        if (validation.Errors.Any())
        {
            AddErrorList(validation.Errors);
            throw new CatalogDomainException(ErrorsToString());
        }

        return IsValid();
    }

    
}