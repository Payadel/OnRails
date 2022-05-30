namespace OnRail.ResultDetails.Errors {
    public class BadRequestError : ErrorDetail {
        public BadRequestError(string? title = null, string? message = null, Exception? exception = null,
            object? moreDetails = null) :
            base(title ?? nameof(BadRequestError),
                message, 400, exception, moreDetails) { }
    }
}