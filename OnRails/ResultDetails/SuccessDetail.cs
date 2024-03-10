namespace OnRails.ResultDetails;

public class SuccessDetail(
    string title = nameof(SuccessDetail),
    string? message = null,
    int? statusCode = null,
    object? moreDetails = null)
    : ResultDetail(title, message, statusCode, moreDetails);