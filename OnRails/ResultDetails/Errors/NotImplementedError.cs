﻿namespace OnRails.ResultDetails.Errors;

public class NotImplementedError(
    string title = nameof(NotImplementedError),
    string? message = null,
    Exception? exception = null,
    object? moreDetails = null)
    : ErrorDetail(title, message, 501, exception, moreDetails);