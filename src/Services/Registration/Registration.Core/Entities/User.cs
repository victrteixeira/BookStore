using System.Text.RegularExpressions;
using Registration.Core.Validators;

namespace Registration.Core.Entities;

public class User
{
    public Guid Id { get; set; }
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
        DomainException.When(string.IsNullOrEmpty(firstname), "First Name can not to be empty.");
        DomainException.When(firstname.Length > 50, "First Name is too long.");
        DomainException.When(firstname.Length < 2, "First Name is too short.");
        DomainException.When(RegexValidators.NameIsValid(firstname), "First Name is invalid.");
        FirstName = firstname;
        
        // Last Name Validation
        DomainException.When(string.IsNullOrEmpty(lastname), "Last Name can not to be empty.");
        DomainException.When(lastname.Length > 50, "Last Name is too long.");
        DomainException.When(lastname.Length < 2, "Last Name is too short.");
        DomainException.When(RegexValidators.NameIsValid(lastname), "Last Name is invalid.");
        LastName = lastname;

        // Username Validation
        if (username != null)
        {
            DomainException.When(RegexValidators.UsernameIsValid(username), "Username is invalid.");
            DomainException.When(username.Length > 50, "Username is too long.");
            DomainException.When(username.Length < 4, "Username is too short.");
            Username = username;
        }
        else
            Username = firstname + lastname;
        
        // Email Validation
        if (email != null)
        {
            DomainException.When(email.Length > 100, "Email is too long.");
            DomainException.When(email.Length < 10, "Email is too short.");
            DomainException.When(RegexValidators.EmailIsValid(email), "Email is invalid.");
            Email = email;
        }
        
        // Age Validation
        if (age != null)
        {
            DomainException.When(age.Value < 18, "It's necessary to have at least eighteen years to do register.");
            DomainException.When(age.Value > 110, "Age is too long.");
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