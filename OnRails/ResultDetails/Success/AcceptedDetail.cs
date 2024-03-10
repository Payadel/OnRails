namespace OnRails.ResultDetails.Success;

public class AcceptedDetail(string title = nameof(AcceptedDetail), string? message = null, object? moreDetails = null)
    : SuccessDetail(title, message, 202, moreDetails);