namespace OnRails.ResultDetails.Success;

public class NotModifiedDetail : SuccessDetail {
    public NotModifiedDetail(string title = nameof(NotModifiedDetail), string? message = null,
        object? moreDetails = null) :
        base(title, message, 304, moreDetails) { }
}