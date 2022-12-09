namespace Auth.Core.DTO.AuthDto;

public class ReadUser
{
    public ReadUser(string userName, string firstName, string lastName, int age, string email)
    {
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Email = email;
    }

    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }

}