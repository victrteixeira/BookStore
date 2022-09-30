namespace Catalog.Infra.Utils;

public static class Constants
{
    private static readonly string[] _bookRepoKeys = new string[]
    {
        "BookById",
        "BookByName",
        "BookByPrice",
        "BookByPriceAndLang",
        "BookByPublisher",
        "BookByAuthor",
        "BookByGenre",
    };
    
    private static readonly string[] _authorRepoKeys = new string[]
    {
        "AuthorByName"
    };
    
    public static string[] BookRepoKeys { get => _bookRepoKeys; }

    public static string[] AuthorRepoKey { get => _authorRepoKeys; }

}