namespace BooksReviewApp.Core.Domain
{
    public record Result
    {
        public bool IsSucceeded { get; init; }

        public string? Message { get; init; }

        public static Result Success() => new() { IsSucceeded = true };

        public static Result Failure(string message) => new() { IsSucceeded = false, Message = message };
    }

    public record Result<T> : Result
    {
        public T? Value { get; init; }

        public static Result<T> Success(T value) => new() { IsSucceeded = true, Value = value };

        public static new Result<T> Failure(string message) => new() { IsSucceeded = false, Message = message };
    }
}
