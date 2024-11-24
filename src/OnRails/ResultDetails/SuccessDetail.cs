namespace OnRails.ResultDetails;

public class SuccessDetail : ResultDetail {
    public SuccessDetail(string title = nameof(SuccessDetail), string? message = null, int? statusCode = null,
        object? moreDetails = null) : base(title, message, statusCode, moreDetails) { }
}