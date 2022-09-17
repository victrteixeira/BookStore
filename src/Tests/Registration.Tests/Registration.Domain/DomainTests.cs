using Bogus.DataSets;
using FluentAssertions;
using Registration.Core.Entities;
using Registration.Core.Validators;
using Registration.Domain.Fixtures;

namespace Registration.Domain;

public class DomainTests
{
    private static string _firstname = new Name().FirstName();
    private static string _lastname = new Name().LastName();
    private static string _username = new Internet().UserName();
    private static string _email = new Internet().Email();
    private static int _age = new Random().Next(18, 60);
    
    [Fact]
    public void User_CreateANewValidUser_ResultAnObjectWithValidState()
    {
        // Arrange
        // Act
        Action res = () =>
        {
            var _ = UserFixture.ValidUser();
        }; 
        
        // Assert
        res.Should().NotThrow<DomainException>();
    }

    #region FirstName Tests

    [Fact]
    public void User_TryToCreateNewUserWithFirstNameNull_ShouldThrowException()
    {
        // Arrange
        // Act
        Action res = () =>
        {
            var _ = new User(null, _lastname, _username, _email, _age, Gender.Other);
        };
        
        // Assert
        res.Should()
            .Throw<DomainException>()
            .WithMessage("First Name can not to be empty.");
    }
    
    [Fact]
    public void User_TryToCreateNewUserWithFirstNameTooLong_ShouldThrowException()
    {
        // Arrange
        // Act
        Action res = () =>
        {
            var _ = new User("yxcKUzZaJBnJFRLPhjLvetXBmyUyNKdzRbzeBhGAJCkgUMHpUjw", _lastname, _username, _email,
                _age, Gender.Other);
        };
        
        // Assert
        res.Should()
            .Throw<DomainException>()
            .WithMessage("First Name is too long.");
    }
    
    [Theory]
    [InlineData("as")]
    [InlineData("a")]
    public void User_TryToCreateNewUserWithFirstNameTooShort_ShouldThrowException(string firstname)
    {
        // Arrange
        // Act
        Action res = () =>
        {
            var _ = new User(firstname, _lastname, _username, _email, _age, Gender.Other);
        };
        
        // Assert
        res.Should()
            .Throw<DomainException>()
            .WithMessage("First Name is too short.");
    }
    
    [Theory]
    [InlineData("s@mpleusername")]
    [InlineData("s#mpleUsername")]
    [InlineData("s.mpleusername")]
    [InlineData("s>mpleusername")]
    [InlineData("s*mpleusername")]
    [InlineData("s$mpleusername")]
    [InlineData("s%mpleusername")]
    [InlineData("s^mpleusername")]
    [InlineData("s&mpleusername")]
    [InlineData("s(mpleusername")]
    [InlineData("s+mpleusername")]
    [InlineData("s=mpleusername")]
    [InlineData("s_mpleusername")]
    public void User_TryToCreateNewUserWithFirstNameInvalid_ShouldThrowException(string firstname)
    {
        // Arrange

        // Act
        Action res = () =>
        {
            var _ = new User(firstname, _lastname, _username, _email, _age, Gender.Other);
        };
        
        // Assert
        res.Should()
            .Throw<DomainException>()
            .WithMessage("First Name is invalid.");
    }
    

    #endregion
}