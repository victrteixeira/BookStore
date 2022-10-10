namespace Catalog.Application.Responses.ForAuthor;

public class AuthorResponse
{
    public int AuthorId { get; set; }
    
    public string FirstName { get; set; } = string.Empty;
    
    public string LastName { get; set; } = string.Empty;
    
    public string BornAt { get; set; } = string.Empty;
    
    public string DiedAt { get; set; } = string.Empty;
    
    public string? Country { get; set; }
    
    public string? BriefDescription { get; set; }
}