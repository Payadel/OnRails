﻿namespace OnRails.ResultDetails.Errors;

public class ConflictError(
    string title = nameof(ConflictError),
    string? message =
        "The request could not be completed due to a conflict with the current state of the target resource.",
    string? objectIdentity = null,
    object? moreDetails = null)
    : ErrorDetail(title, message, 409, moreDetails) {
    public string? ObjectIdentity { get; } = objectIdentity;

    protected override string? CustomFieldsToString() {
        return ObjectIdentity is null
            ? null
            : $"Object Identity: {ObjectIdentity}";
    }
}