namespace Catalog.Core.Entities;

public class Author
{
    public int AuthorId { get; set; }
    public string Name { get; set; }
    public string Born { get; set; }
    public string Died { get; set; }
    public int Age { get; set; }
    public string? Country { get; set; }
    public string? BriefDescription { get; set; }

    public List<Book>? Books { get; set; }
}