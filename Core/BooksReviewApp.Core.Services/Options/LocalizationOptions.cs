using System.ComponentModel.DataAnnotations;

namespace BooksReviewApp.Core.Services.Options
{
    public class LocalizationOptions
    {
        [Required]
        public string ValidationMessagesPath { get; init; }

        [Required]
        public string DefaultCulture { get; init; }
    }
}
