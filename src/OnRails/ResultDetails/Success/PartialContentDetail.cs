namespace OnRails.ResultDetails.Success;

public class PartialContentDetail : SuccessDetail {
    public PartialContentDetail(string title = nameof(PartialContentDetail), string? message = null,
        object? moreDetails = null) :
        base(title, message, 206, moreDetails) { }
}