namespace OnRail.ResultDetails.Errors {
    public class InternalError : ErrorDetail {
        public InternalError(string? title = null, string? message = null,
            Exception? exception = null,
            object? moreDetails = null) : base(
            title ?? nameof(InternalError), message, 500, exception, moreDetails) { }
    }
}