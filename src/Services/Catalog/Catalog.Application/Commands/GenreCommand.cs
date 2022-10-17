using System.ComponentModel.DataAnnotations;

namespace Catalog.Application.Commands;

public class GenreCommand
{
    [Required] public string Name { get; set; } = string.Empty;

    [Required] public string SubGenre { get; set; } = string.Empty;

    public string? BriefDescription { get; set; }
}