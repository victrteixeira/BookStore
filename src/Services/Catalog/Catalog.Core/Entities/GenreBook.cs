using System.Text.Json.Serialization;

namespace Catalog.Core.Entities;

public class GenreBook
{
    public int GenreId { get; set; }
    [JsonIgnore]
    public Genre? Genre { get; set; }
    public int BookId { get; set; }
    [JsonIgnore]
    public Book? Book { get; set; }
}