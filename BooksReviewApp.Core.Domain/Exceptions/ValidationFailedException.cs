namespace BooksReviewApp.Core.Domain.Exceptions
{
    public class ValidationFailedException : Exception
    {
        public IEnumerable<string> Errors { get; }

        public ValidationFailedException(IEnumerable<string> errors)
        {
            Errors = errors;
        }

        public ValidationFailedException() : base() { }
        public ValidationFailedException(string message) : base(message) { }
        public ValidationFailedException(string message, Exception innerException) : base(message, innerException) { }
    }
}
