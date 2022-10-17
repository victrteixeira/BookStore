namespace Catalog.Infra.Utils;

public static class Constants
{
    public static string[] BookRepoKeys { get; } =
    {
        "BookById",
        "BookByName",
        "BookByPrice",
        "BookByPriceAndLang",
        "BookByPublisher",
        "BookByAuthor",
        "BookByGenre"
    };

    public static string[] AuthorRepoKey { get; } =
    {
        "AuthorByName"
    };
}