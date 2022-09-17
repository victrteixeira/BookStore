using Bogus.DataSets;
using Registration.Core.Entities;

namespace Registration.Domain.Fixtures;

public static class UserFixture
{
    private static string _firstname = new Name().FirstName();
    private static string _lastname = new Name().LastName();
    private static string _username = new Internet().UserName();
    private static string _email = new Internet().Email();
    private static int _age = new Random().Next(18, 60);
    
    public static User ValidUser()
    {
        User user = new(_firstname, _lastname, _username, _email, _age, Gender.Other);
        return user;
    }
}