namespace OnRails.ResultDetails;

public class SuccessDetail(
    string title = nameof(SuccessDetail),
    string? message = "Operation was successful",
    int? statusCode = 200,
    object? moreDetails = null)
    : ResultDetail(title, message, statusCode, moreDetails);