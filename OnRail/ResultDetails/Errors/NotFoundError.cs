namespace OnRail.ResultDetails.Errors {
    public class NotFoundError : ErrorDetail {
        public NotFoundError(string? title = null, string? message = null, Exception? exception = null,
            object? moreDetails = null) :
            base(title ?? nameof(NotFoundError), message, 404,
                exception, moreDetails) { }
    }
}