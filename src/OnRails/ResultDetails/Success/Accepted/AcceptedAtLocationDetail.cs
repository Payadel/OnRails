using System.Diagnostics;
using System.Text;

namespace OnRails.ResultDetails.Success.Accepted;

[DebuggerStepThrough]
public class AcceptedAtLocationDetail : AcceptedDetail {
    public string? Location { get; }
    public Uri? LocationUri { get; }

    public AcceptedAtLocationDetail(string location) : base(nameof(AcceptedAtLocationDetail)) {
        Location = location;
    }

    public AcceptedAtLocationDetail(Uri location) : base(nameof(AcceptedAtLocationDetail)) {
        LocationUri = location;
    }

    protected override string CustomFieldsToString() {
        var sb = new StringBuilder();

        if (Location is not null)
            sb.AppendLine($"Location: {Location}");
        else if (LocationUri is not null)
            sb.AppendLine($"Location: {LocationUri!.ToString()}");
        else
            throw new Exception(message: "Not Implemented.");

        return sb.ToString();
    }
}