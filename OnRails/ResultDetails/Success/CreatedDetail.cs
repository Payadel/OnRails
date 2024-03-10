namespace OnRails.ResultDetails.Success;

public class CreatedDetail(string title = nameof(CreatedDetail), string? message = null, object? moreDetails = null)
    : SuccessDetail(title, message, 201, moreDetails);