namespace Infra.Tests;

public class AuthorRepositoryTests
{
    #region Properties
    private string _bornAt = new Date().PastDateOnly(80, new DateOnly(2021, 01, 01)).Year.ToString();
    private string _diedAt = DateTime.Now.Year.ToString();
    private string _country = new Address().Country();
    private string _briefDescription = new Lorem().Sentence(5);
    
    #endregion
    
    // Repository Setup
    private readonly IAuthorRepository _sut;
    private readonly Mock<CatalogContext> _dbContextMock;
    private readonly Mock<DbSet<Author>> _dbSetMock;
    private List<Author> Authors { get; set; }
    
    public AuthorRepositoryTests()
    {
        Authors = DbFixtures.AuthorPopulate();
        _dbContextMock = new Mock<CatalogContext>();
        _sut = new AuthorRepository(_dbContextMock.Object);
        
        _dbSetMock = Authors.AsQueryable().BuildMockDbSet();
        _dbContextMock.Setup(x => x.Authors)
            .Returns(_dbSetMock.Object);
    }

    [Theory]
    [InlineData("samplefirstname ", "samplelastname")]
    [InlineData("sampLEFirstname ", " SAMPLElastName")]
    [InlineData("samplefirsTnamE", "SAMPLElastName")]
    [InlineData("SampleFirstName", "SamplELastname")]
    [InlineData("SamplefirstName", "SamplelastName")]
    [Trait("Category","Author Repository")]
    public async Task AuthorRepo_GetAuthorByName_ShouldExecuteSuccessfulQuery(string firstname, string lastname)
    {
        // Arrange
        var newAuthor = new Author
            ("SampleFirstName", "SampleLastName", _bornAt, _diedAt, _country, _briefDescription);
    
        Authors.Add(newAuthor);
    
        // Act
        var res = await _sut.GetAuthorByName(firstname, lastname);
        
        // Assert
        res.Should()
            .Be(newAuthor);
    }
}