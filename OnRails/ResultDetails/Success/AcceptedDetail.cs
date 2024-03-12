namespace OnRails.ResultDetails.Success;

public class AcceptedDetail(
    string title = nameof(AcceptedDetail),
    string? message = "Request accepted for processing.",
    object? moreDetails = null,
    bool view = false)
    : SuccessDetail(title, message, 202, moreDetails, view);