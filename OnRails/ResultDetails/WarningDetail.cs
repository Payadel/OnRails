namespace OnRails.ResultDetails;

public class WarningDetail(
    string title = nameof(WarningDetail),
    string? message = "The operation was completed successfully, but there is a warning.",
    int? statusCode = 200,
    object? moreDetails = null,
    bool view = false)
    : ResultDetail(title, message, statusCode, moreDetails, view);