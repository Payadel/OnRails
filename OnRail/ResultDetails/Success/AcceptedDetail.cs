namespace OnRail.ResultDetails.Success;

public class AcceptedDetail : SuccessDetail {
    public AcceptedDetail(string title = nameof(AcceptedDetail), string? message = null, object? moreDetails = null) :
        base(title, message, 202, moreDetails) { }
}