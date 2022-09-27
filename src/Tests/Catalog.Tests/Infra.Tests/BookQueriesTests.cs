namespace Infra.Tests;

public class BookQueriesTests
{
    // Repository Setup
    private readonly IBookRepository _sut;
    private readonly Mock<CatalogContext> _contextMock;
    private readonly Mock<DbSet<Book>> _dbSetMock;
    private List<Book> Books { get; set; }

    public BookQueriesTests()
    {
        Books = DbFixtures.BookPopulate();
        _contextMock = new Mock<CatalogContext>();
        _sut = new BookRepository(_contextMock.Object);

        _dbSetMock = Books.AsQueryable().BuildMockDbSet();
        _contextMock.Setup(x => x.Books)
            .Returns(_dbSetMock.Object);
    }

    [Theory]
    [InlineData("Metaphysics of Costume")]
    [InlineData("metaphysics of costume")]
    [InlineData("METAPHYSICS OF COSTUME")]
    [InlineData("MetapHysiCS of CosTumE")]
    [Trait("Category", "Book Repository")]
    public async Task BookRepo_QueryByName_ShouldReturnAnEntityOfBookType(string bookName)
    {
        // Arrange
        var newBook = new Book(bookName,
            220, 56m, "Portuguese", "Penguin");
        
        Books.Add(newBook);
        
        // Act
        var res = await _sut.GetBookByName("Metaphysics of Costume");
        
        // Assert
        res.Should().Be(newBook);
    }
    
    [Fact]
    [Trait("Category", "Book Repository")]
    public async Task BookRepo_QueryByName_ShouldReturnNull()
    {
        // Arrange
        // Act
        var res = await _sut.GetBookByName("Metaphysics of Costume's Introduction");
        
        // Assert
        res.Should().BeNull();
    }
    
    [Fact]
    [Trait("Category", "Book Repository")]
    public async Task BookRepo_QueryByPrice_ShouldReturnAnEntityOfBookType()
    {
        // Arrange
        var bookA = DbFixtures.BookEntity(price: 60m);
        var bookB = DbFixtures.BookEntity(price: 60m);
        var bookC = DbFixtures.BookEntity(price: 60m);
        List<Book> bookList = new () { bookA, bookB, bookC };
        
        Books.AddRange(bookList);
        
        // Act
        var res = await _sut.GetBooksByPrice(60m);
        
        // Assert
        res.Should().HaveCount(3);
    }

    [Fact]
    [Trait("Category", "Book Repository")]
    public async Task BookRepo_QueryByLanguageAndPrice_ShouldReturnAnEntityOfBookType()
    {
        // Arrange
        var bookA = DbFixtures.BookEntity(price: 60m, language: "Portuguese");
        var bookB = DbFixtures.BookEntity(price: 60m, language: "portuguese");
        var bookC = DbFixtures.BookEntity(price: 60m, language: "PortuGuese");
        List<Book> bookList = new () { bookA, bookB, bookC };
        
        Books.AddRange(bookList);
        
        // Act
        var res = await _sut.GetBooksByPriceAndLanguage(" portuguese ", 60m);

        // Assert
        res.Should().HaveCount(3);
    }
    
    [Fact]
    [Trait("Category", "Book Repository")]
    public async Task BookRepo_QueryByPublisher_ShouldReturnAnEntityOfBookType()
    {
        // Arrange
        var bookA = DbFixtures.BookEntity(publisher: "Martins Font");
        var bookB = DbFixtures.BookEntity(publisher: "Martins Font");
        var bookC = DbFixtures.BookEntity(publisher: "Martins Font");
        var bookD = DbFixtures.BookEntity(publisher: "Martins Font");
        List<Book> bookList = new () { bookA, bookB, bookC, bookD };
        
        Books.AddRange(bookList);
        
        // Act
        var res = await _sut.GetBooksByPublisher("Martins Font");

        // Assert
        res.Should().HaveCount(4);
    }
    
    [Fact]
    [Trait("Category", "Book Repository")]
    public async Task BookRepo_QueryByAuthor_ShouldReturnAnEntityOfBookType()
    {
        // Arrange
        var bookA = DbFixtures.BookEntity();
        bookA.AuthorId = 5;
        var bookB = DbFixtures.BookEntity();
        bookB.AuthorId = 5;
        var bookC = DbFixtures.BookEntity();
        bookC.AuthorId = 5;
        var bookD = DbFixtures.BookEntity();
        bookD.AuthorId = 5;
        
        List<Book> bookList = new () { bookA, bookB, bookC, bookD };
        Books.AddRange(bookList);

        // Act
        var res = await _sut.GetBooksByAuthor(5);

        // Assert
        res.Should().HaveCount(4);
    }

    [Fact(Skip = "Not possible to test")]
    public Task BookRepo_QueryByGenre_ShouldReturnAllBooksThatMatchWithParameter() => Task.CompletedTask;
}