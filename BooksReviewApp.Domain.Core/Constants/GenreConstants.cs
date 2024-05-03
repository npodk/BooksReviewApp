using BooksReviewApp.Domain.Core.Enums;

namespace BooksReviewApp.Domain.Core.Constants
{
    public static class GenreConstants
    {
        public static readonly int ExamplesNumber = 3;
        public static readonly GenreNameEnum[] DefaultNames = { GenreNameEnum.Classic, GenreNameEnum.Novel, GenreNameEnum.Dystopian };
        public static readonly string[] DefaultDescriptions =
        {
            "Timeless literature",
            "Complex storytelling",
            "Bleak future"
        };
    }
}
