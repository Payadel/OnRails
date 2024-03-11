﻿namespace OnRails.ResultDetails.Success;

public class PartialContentDetail(
    string title = nameof(PartialContentDetail),
    string? message = "Partial content is returned successfully.",
    object? moreDetails = null)
    : SuccessDetail(title, message, 206, moreDetails);