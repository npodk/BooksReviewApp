namespace BooksReviewApp.WebApi.Cache
{
    public interface IValidationMessagesCache
    {
        Dictionary<string, Dictionary<string, string>> GetMessages();
    }
}
