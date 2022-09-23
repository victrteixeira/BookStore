namespace Catalog.Domain;

public class DomainTests
{
    private string _firstname = new Name().FirstName();
    private string _lastname = new Name().LastName();
    private string _born = new Date().PastDateOnly(60, new DateOnly(1990, 01, 01)).ToString("yyyy");
    private string _died = new Date().PastDateOnly(10, new DateOnly(2022, 01, 01)).ToString("yyyy");
    private string _country = new Address().Country();
    private string _desc = new Lorem().Sentence(5);

    private AuthorValidator _authorValidator;
    public DomainTests()
    {
        _authorValidator = new AuthorValidator();
    }

    #region Valid Entities

    [Theory]
    [InlineData("1899", "1920")]
    [InlineData("1899AD", "1920AD")]
    [InlineData("1899ad", "1920ad")]
    [InlineData("135bc", "194bc")]
    [InlineData("135", "194")]
    [Trait("Category", "Dates")]
    public void Dates_CreateValidAuthor_ShouldBeAnEntityWithValidState(string born, string died)
    {
        // Arrange
        // Act
        Action res = () =>
        {
            var _ = new Author(_firstname, _lastname, born, died, null, null);
        };
        
        // Assert
        res.Should()
            .NotThrow<CatalogDomainException>();
    }

    [Theory]
    [InlineData("samplename", "samplesecondname", "1890AD", "1990AD", "Brazil", "Lorem Ipsum")]
    public void FullEntity_CreateValidAuthorWithFullPropertiesValid_ShouldBeAnEntityWithValidState(string firstname, string lastname, string born, string died, string country,string briefdesc)
    {
        // Arrange
        // Act
        Action res = () =>
        {
            var _ = new Author(firstname, lastname, born, died, country, briefdesc);
        };
        // Assert
        res.Should().NotThrow();
    }

    #endregion
    
    #region Author Name
    
    [Fact]
    [Trait("Category", "FirstName")]
    public void Name_TryToCreateNewAuthorWithNullFirstName_ShouldThrowException()
    {
        // Arrange
        // Act
        Action res = () =>
        {
            var _ = new Author(null!,_lastname, _born, _died, _country, _desc);
        };
        // Assert
        res.Should().Throw<CatalogDomainException>()
            .WithMessage("First Name is required and can not be null.");
    }
    
    [Theory]
    [InlineData("as")]
    [InlineData("VApexGdTeRBePuqRypnNwhRcNvHiSCWUyRnecmMBccHSfCAjarC")]
    [Trait("Category", "FirstName")]
    public void Name_TryToCreateNewAuthorWithOutOfRangeFirstName_ShouldThrowException(string name)
    {
        // Arrange
        // Act
        Action res = () =>
        {
            var _ = new Author(name, _lastname, _born, _died, _country, _desc);
        };
        // Assert
        res.Should().Throw<CatalogDomainException>()
            .WithMessage("First Name must be between 3 and 50 chars.");
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
    [Trait("Category", "FirstName")]
    public void Name_TryToCreateNewAuthorWithInvalidFirstName_ShouldThrowException(string name)
    {
        // Arrange
        // Act
        Action res = () =>
        {
            var _ = new Author(name,_lastname, _born, _died, _country, _desc);
        };
        // Assert
        res.Should().Throw<CatalogDomainException>()
            .WithMessage("First Name contain invalid char or are outside of range allowed.");
    }
    
    #endregion

    #region Author Born

    [Theory]
    [InlineData("17002")]
    [InlineData("19080")]
    [InlineData("1908AC")]
    [InlineData("1908BD")]
    [InlineData("1900AQ")]
    [InlineData("1900CB")]
    [InlineData("1900DA")]
    [Trait("Category", "Born")]
    public void Born_TryToCreateNewAuthorWithOutOfRangeBorn_ShouldThrowException(string born)
    {
        // Arrange
        // Act
        Action res = () =>
        {
            var _ = new Author(_firstname,_lastname, born, _died, _country, _desc);
        };
        // Assert
        res.Should().Throw<CatalogDomainException>()
            .WithMessage("Born are outside of range or contain invalid char.");
    }
    
    #endregion

}