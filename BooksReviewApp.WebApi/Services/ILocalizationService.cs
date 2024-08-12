namespace BooksReviewApp.WebApi.Services
{
    //TODO: move it to infrastructure layer
    public interface ILocalizationService
    {
        string GetValidationMessage(string key, params object[] args);
    }
}
