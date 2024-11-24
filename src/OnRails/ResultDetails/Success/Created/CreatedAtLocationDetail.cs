using System.Diagnostics;
using System.Text;

namespace OnRails.ResultDetails.Success.Created;

[DebuggerStepThrough]
public class CreatedAtLocationDetail : CreatedDetail {
    public string? Location { get; }
    public Uri? LocationUri { get; }

    public CreatedAtLocationDetail(string location) : base(nameof(CreatedAtLocationDetail)) {
        Location = location;
    }

    public CreatedAtLocationDetail(Uri location) : base(nameof(CreatedAtLocationDetail)) {
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