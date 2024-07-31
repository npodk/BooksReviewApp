namespace BooksReviewApp.WebApi.Services
{
    public interface ILocalizationService
    {
        string GetValidationMessage(string key, params object[] args);
    }
}
