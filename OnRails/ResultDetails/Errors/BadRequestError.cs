namespace OnRails.ResultDetails.Errors;

public class BadRequestError(
    string title = nameof(BadRequestError),
    string? message = "Bad request. Please check your request parameters.",
    object? moreDetails = null,
    bool view = false)
    : ErrorDetail(title, message, 400, moreDetails, view);