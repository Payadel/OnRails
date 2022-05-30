namespace OnRail.ResultDetails;

public class SuccessDetail : ResultDetail {
    public SuccessDetail(string? title = null, string? message = null, int? statusCode = null,
        object? moreDetails = null) : base(title ?? nameof(SuccessDetail), message, statusCode, moreDetails) { }
}