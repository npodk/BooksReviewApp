namespace BooksReviewApp.Domain.Core.Constants
{
    public static class BookConstants
    {
        public static readonly int ExamplesNumber = 3;
        public static readonly string[] DefaultTitles = { "The Great Gatsby", "1984", "To Kill a Mockingbird" };
        public static readonly string[] DefaultPublishers = { "Candlewick Press", "Penguin Classics", "HarperCollins" };
        public static readonly int[] DefaultWritingYears = { 1925, 1949, 1960 };
        public static readonly int[] DefaultPublishingYears = { 2021, 2020, 2019 };
        public static readonly string[] DefaultISBNs = { "9781536216769", "9780451524935", "9780060935467" };
        public static readonly string[] DefaultDescriptions =
        {
            "It tells the story of Jay Gatsby, a self-made millionaire, and his pursuit of Daisy Buchanan, a wealthy young woman whom he loved in his youth.",
            "A dystopian social science fiction novel and cautionary tale.",
            "The story of the young and innocent Scout Finch, her brother Jem, and their widowed father, Atticus."
        };
    }
}
