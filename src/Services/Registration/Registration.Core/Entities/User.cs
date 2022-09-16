using System.Text.RegularExpressions;
using Registration.Core.Validators;

namespace Registration.Core.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public int? Age { get; set; }
    public Gender Gender { get; set; }

    public User(string firstname, string lastname, string? username, string? email, int? age, Gender gender)
    {
        ValidateDomain(firstname, lastname, username, email, age);
        Gender = gender;
    }

    private void ValidateDomain(string firstname, string lastname, string? username, string? email, int? age)
    {
        // First Name Validation
        NameValidator.FirstNameIsValid(firstname);
        FirstName = firstname;
        
        // Last Name Validation
        NameValidator.LastNameIsValid(lastname);
        LastName = lastname;

        // Username Validation
        if (username != null)
        {
            UsernameValidator.UsernameIsValid(username);
            Username = username;
        }
        else
            Username = firstname + lastname;
        
        // Email Validation
        if (email != null)
        {
           EmailValidator.EmailIsValid(email);
           Email = email;
        }
        
        // Age Validation
        if (age != null)
        {
            DomainException.When(age > 100 || age < 18, "Age must be more than eighteen and less than one hundred.");
            Age = age;
        }
    }
}

public enum Gender
{
    Male = 1,
    Female = 2,
    Other = 3
}