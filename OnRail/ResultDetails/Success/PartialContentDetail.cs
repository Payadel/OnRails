namespace OnRail.ResultDetails.Success {
    public class PartialContentDetail : SuccessDetail {
        public PartialContentDetail(string? title = null, string? message = null, object? moreDetails = null) :
            base(title ?? nameof(PartialContentDetail),
                message, 206, moreDetails) { }
    }
}