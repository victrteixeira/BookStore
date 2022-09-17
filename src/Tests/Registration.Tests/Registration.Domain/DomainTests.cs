using System.Runtime.Intrinsics.Arm;
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

    #region Valid Entities
    [Fact]
    [Trait("Category", "Valid")]
    public void FullValid_CreateNewValidUser_ResultAnObjectWithValidState()
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
    
    [Fact]
    [Trait("Category", "Valid")]
    public void NullUsername_CreateNewValidUserWhenUsernameIsNull_ResultAnObjectWithValidState()
    {
        // Arrange
        var user = new User(_firstname, _lastname, null!, _email, _age, Gender.Other);
        // Act
        // Assert
        user.Username.Should().Be(user.FirstName + user.LastName);
    }
    
    [Fact]
    [Trait("Category", "Valid")]
    public void FirstName_CreateNewValidUserWhenFirstNameHasApostrophe_ResultAnObjectWithValidState()
    {
        // Arrange
        // Act
        Action res = () =>
        {
            var _ = new User("O'Neil", _lastname, _username!, _email, _age, Gender.Other);
        };
        
        // Assert
        res.Should()
            .NotThrow<DomainException>();
    }
    
    [Fact]
    [Trait("Category", "Valid")]
    public void LastName_CreateNewValidUserWhenLastNameHasApostrophe_ResultAnObjectWithValidState()
    {
        // Arrange
        // Act
        Action res = () =>
        {
            var _ = new User(_firstname, "O'Neil", _username!, _email, _age, Gender.Other);
        };
        
        // Assert
        res.Should()
            .NotThrow<DomainException>();
    }
    
    [Fact]
    [Trait("Category", "Valid")]
    public void NullEmail_CreateNewValidUserWhenEmailIsNull_ResultAnObjectWithValidState()
    {
        // Arrange
        var user = new User(_firstname, _lastname, _username, null, _age, Gender.Other);
        // Act
        // Assert
        user.Email.Should().BeNull();
    }
    
    [Fact]
    [Trait("Category", "Valid")]
    public void NullAge_CreateNewValidUserWhenAgeIsNull_ResultAnObjectWithValidState()
    {
        // Arrange
        var user = new User(_firstname, _lastname, _username, _email, null, Gender.Other);
        // Act
        // Assert
        user.Age.Should().BeNull();
    }
    
    [Fact]
    [Trait("Category", "Valid")]
    public void NullProperties_CreateNewValidUserWhenUsernameEmailAndAgeIsNull_ResultAnObjectWithValidState()
    {
        // Arrange
        var user = new User(_firstname, _lastname, null!, null, null, Gender.Other);
        // Act
        // Assert
        user.Username.Should().Be(user.FirstName + user.LastName).Should().NotBeNull();
        user.Email.Should().BeNull();
        user.Age.Should().BeNull();
    }
    
    [Fact]
    [Trait("Category", "Valid")]
    public void IdGuid_CreateNewValidUserWithAutomaticGeneratedGuid_ResultAnObjectWithValidState()
    {
        // Arrange
        var user = new User(_firstname, _lastname, _username, _email, _age, Gender.Other);
        // Act
        Guid expect = user.Id;
        // Assert
        user.Id.Should().Be(expect);
    }
    
    [Theory]
    [InlineData(18)]
    [InlineData(100)]
    [InlineData(99)]
    [InlineData(19)]
    [Trait("Category", "Valid")]
    public void ValidAges_CreateNewUserWithValidAges_ResultAnObjectWithValidState(int age)
    {
        // Arrange
        // Act
        Action res = () =>
        {
            var _ = new User(_firstname, _lastname, _username, _email, age, Gender.Other);
        };
        
        // Assert
        res.Should()
            .NotThrow<DomainException>();
    }
    #endregion

    #region FirstName Tests
    [Fact]
    [Trait("Category", "Name")]
    public void Firstname_TryToCreateNewUserWithFirstNameNull_ShouldThrowException()
    {
        // Arrange
        // Act
        Action res = () =>
        {
            var _ = new User(null!, _lastname, _username, _email, _age, Gender.Other);
        };
        
        // Assert
        res.Should()
            .Throw<DomainException>()
            .WithMessage("First Name can not to be empty.");
    }
    
    [Fact]
    [Trait("Category", "Name")]
    public void Firstname_TryToCreateNewUserWithFirstNameTooLong_ShouldThrowException()
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
    [Trait("Category", "Name")]
    public void Firstname_TryToCreateNewUserWithFirstNameTooShort_ShouldThrowException(string firstname)
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
    [Trait("Category", "Name")]
    public void Firstname_TryToCreateNewUserWithFirstNameInvalid_ShouldThrowException(string firstname)
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

    #region LastName Tests

    [Fact]
    [Trait("Category", "Name")]
    public void LastName_TryToCreateNewUserWithLastNameNull_ShouldThrowException()
    {
        // Arrange
        // Act
        Action res = () =>
        {
            var _ = new User(_firstname, null!, _username, _email, _age, Gender.Other);
        };
        
        // Assert
        res.Should()
            .Throw<DomainException>()
            .WithMessage("Last Name can not to be empty.");
    }
    
    [Fact]
    [Trait("Category", "Name")]
    public void LastName_TryToCreateNewUserWithLastNameTooLong_ShouldThrowException()
    {
        // Arrange
        // Act
        Action res = () =>
        {
            var _ = new User(_firstname, "yxcKUzZaJBnJFRLPhjLvetXBmyUyNKdzRbzeBhGAJCkgUMHpUjw", _username, _email, _age, Gender.Other);
        };
        
        // Assert
        res.Should()
            .Throw<DomainException>()
            .WithMessage("Last Name is too long.");
    }
    
    [Theory]
    [InlineData("as")]
    [InlineData("a")]
    [Trait("Category", "Name")]
    public void LastName_TryToCreateNewUserWithLastNameTooShort_ShouldThrowException(string lastname)
    {
        // Arrange
        // Act
        Action res = () =>
        {
            var _ = new User(_firstname, lastname, _username, _email, _age, Gender.Other);
        };
        
        // Assert
        res.Should()
            .Throw<DomainException>()
            .WithMessage("Last Name is too short.");
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
    [Trait("Category", "Name")]
    public void LastName_TryToCreateNewUserWithLastNameInvalid_ShouldThrowException(string lastname)
    {
        // Arrange
        // Act
        Action res = () =>
        {
            var _ = new User(_firstname, lastname, _username, _email, _age, Gender.Other);
        };
        
        // Assert
        res.Should()
            .Throw<DomainException>()
            .WithMessage("Last Name is invalid.");
    }
    #endregion

    #region Username Tests

    [Fact]
    [Trait("Category", "Username")]
    public void Username_TryToCreateUserWithUsernameTooLong_ShouldThrowException()
    {
        // Arrange
        // Act
        Action res = () =>
        {
            var _ = new User(_firstname, _lastname, "yxcKUzZaJBnJFRLPhjLvetXBmyUyNKdzRbzeBhGAJCkgUMHpUjw", _email, _age,
                Gender.Other);
        };
        
        // Assert
        res.Should()
            .Throw<DomainException>()
            .WithMessage("Username is too long.");
    }
    
    [Theory]
    [InlineData("asd")]
    [InlineData("as")]
    [InlineData("a")]
    [Trait("Category", "Username")]
    public void Username_TryToCreateUserWithUsernameTooShort_ShouldThrowException(string username)
    {
        // Arrange
        // Act
        Action res = () =>
        {
            var _ = new User(_firstname, _lastname, username, _email, _age, Gender.Other);
        };
        
        // Assert
        res.Should()
            .Throw<DomainException>()
            .WithMessage("Username is too short.");
    }
    
    [Theory]
    [InlineData("s@mpleusername")]
    [InlineData("s*mpleusername")]
    [InlineData("s\"mpleusername")]
    [InlineData("s(mpleusername")]
    [InlineData("s)mpleusername")]
    [InlineData("s[mpleusername")]
    [InlineData("s]mpleusername")]
    [InlineData("s;mpleusername")]
    [InlineData("s!mpleusername")]
    [InlineData("s`mpleusername")]
    [InlineData("s\\mpleusername")]
    [InlineData("s/mpleusername")]
    [InlineData("s#mpleusername")]
    [InlineData("s$mpleusername")]
    [InlineData("s%mpleusername")]
    [InlineData("s^mpleusername")]
    [InlineData("s&mpleusername")]
    [InlineData("s+mpleusername")]
    [InlineData("s|mpleusername")]
    [InlineData("s<mpleusername")]
    [InlineData("s:mpleusername")]
    [InlineData("s{mpleusername")]
    [InlineData("s>mpleusername")]
    [InlineData("s}mpleusername")]
    [InlineData("s=mpleusername")]
    [Trait("Category", "Username")]
    public void Username_TryToCreateUserWhenUsernameContainBannedChar_ShouldThrowException(string username)
    {
        // Arrange
        // Act
        Action res = () =>
        {
            var _ = new User(_firstname, _lastname, username, _email, _age, Gender.Other);
        };
        
        // Assert
        res.Should()
            .Throw<DomainException>()
            .WithMessage("Username has not allowed char.", nameof(username));
    }
    #endregion

    #region Age Tests

    [Theory]
    [InlineData(17)]
    [InlineData(101)]
    [Trait("Category", "Age")]
    public void Age_TryToCreateNewUserWithInvalidAge_ShouldThrowException(int age)
    {
        // Arrange
        // Act
        Action res = () =>
        {
            var _ = new User(_firstname, _lastname, _username, _email, age, Gender.Other);
        };
        
        // Assert
        res.Should()
            .Throw<DomainException>()
            .WithMessage("Age must be more than eighteen and less than one hundred.");
    }
    #endregion
}