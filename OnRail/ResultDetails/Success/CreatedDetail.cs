namespace OnRail.ResultDetails.Success {
    public class CreatedDetail : SuccessDetail {
        public CreatedDetail(string? title = null, string? message = null, object? moreDetails = null) :
            base(title ?? nameof(CreatedDetail), message, 201, moreDetails) { }
    }
}