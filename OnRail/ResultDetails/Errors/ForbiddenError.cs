namespace OnRail.ResultDetails.Errors {
    public class ForbiddenError : ErrorDetail {
        public ForbiddenError(string? title = null, string? message = null, Exception? exception = null,
            object? moreDetails = null) :
            base(title ?? nameof(ForbiddenError),
                message, 403, exception, moreDetails) { }
    }
}