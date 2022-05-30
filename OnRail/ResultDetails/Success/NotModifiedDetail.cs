namespace OnRail.ResultDetails.Success;

public class NotModifiedDetail : SuccessDetail {
    public NotModifiedDetail(string? title = null, string? message = null, object? moreDetails = null) :
        base(title ?? nameof(NotModifiedDetail),
            message, 304, moreDetails) { }
}