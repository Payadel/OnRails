namespace OnRails.ResultDetails;

public class SuccessDetail(
    string title = nameof(SuccessDetail),
    string? message = "Operation was successful",
    int? statusCode = 200,
    object? moreDetails = null,
    bool view = false)
    : ResultDetail(title, message, statusCode, moreDetails, view);