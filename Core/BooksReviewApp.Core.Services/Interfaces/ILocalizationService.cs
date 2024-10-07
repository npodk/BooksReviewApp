namespace BooksReviewApp.Core.Services.Interfaces
{
    public interface ILocalizationService
    {
        string GetValidationMessage(string key, params object[] args);
    }
}
