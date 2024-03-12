namespace OnRails.ResultDetails.Errors;

public class UnauthorizedError(
    string title = nameof(UnauthorizedError),
    string? message = "Authentication is required to access the requested resource.",
    object? moreDetails = null)
    : ErrorDetail(title, message, 401, moreDetails);