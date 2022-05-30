namespace OnRail.ResultDetails.Errors {
    public class NotImplementedError : ErrorDetail {
        public NotImplementedError(string? title = null, string? message = null,
            Exception? exception = null, object? moreDetails = null) :
            base(title ?? nameof(NotImplementedError),
                message, 501, exception, moreDetails) { }
    }
}