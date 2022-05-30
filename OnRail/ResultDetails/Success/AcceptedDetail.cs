namespace OnRail.ResultDetails.Success {
    public class AcceptedDetail : SuccessDetail {
        public AcceptedDetail(string? title = null, string? message = null, object? moreDetails = null) :
            base(title ?? nameof(AcceptedDetail),
                message, 202, moreDetails) { }
    }
}