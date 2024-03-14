namespace OnRails.ResultDetails;

public class WarningDetail : ResultDetail {
    public string WarningMessage { get; }

    public WarningDetail(
        string warningMessage,
        string title = nameof(WarningDetail),
        string? message = "The operation was completed successfully, but there is a warning.",
        int? statusCode = 200,
        object? moreDetails = null,
        bool view = false) : base(title, message, statusCode, moreDetails, view) {
        if (string.IsNullOrWhiteSpace(warningMessage))
            throw new ArgumentNullException(nameof(warningMessage));
        WarningMessage = warningMessage;
    }

    public override Dictionary<string, object?> GetViewModel() =>
        new() {
            { nameof(Title), Title },
            { nameof(Message), Message },
            { nameof(WarningMessage), WarningMessage },
        };

    protected override string CustomFieldsToString() {
        return $"Warning Message: {WarningMessage}";
    }
}