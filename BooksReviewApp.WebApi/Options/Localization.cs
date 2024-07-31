using System.ComponentModel.DataAnnotations;

namespace BooksReviewApp.WebApi.Options
{
    public class Localization
    {
        [Required]
        public string ValidationMessagesPath { get; init; }

        [Required]
        public string DefaultCulture { get; init; }
    }
}
