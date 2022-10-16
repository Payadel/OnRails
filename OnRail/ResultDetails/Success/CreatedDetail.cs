namespace OnRail.ResultDetails.Success;

public class CreatedDetail : SuccessDetail {
    public CreatedDetail(string title = nameof(CreatedDetail), string? message = null, object? moreDetails = null) :
        base(title, message, 201, moreDetails) { }
}