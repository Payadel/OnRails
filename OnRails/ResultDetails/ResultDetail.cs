using System.Reflection;
using System.Text;

namespace OnRails.ResultDetails;

public class ResultDetail {
    public string Title { get; }
    public string? Message { get; }
    public int? StatusCode { get; }
    public List<object> MoreDetails { get; } = [];

    public ResultDetail(string title, string? message = null, int? statusCode = null, object? moreDetails = null) {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(title));

        Title = title;
        StatusCode = statusCode;
        Message = message;
        if (moreDetails is not null)
            MoreDetails.Add(moreDetails);
    }

    public ResultDetail AddDetail(object newDetail) {
        if (newDetail == null) throw new ArgumentNullException(nameof(newDetail));

        MoreDetails.Add(newDetail);
        return this;
    }

    public List<T> GetMoreDetailProperties<T>(string? name = null) {
        if (!MoreDetails.Any())
            return [];

        return MoreDetails
            .Aggregate(new List<T>(), (result, detail) => {
                result.AddRange(GetProperties<T>(detail, name));
                return result;
            });
    }

    private static List<T> GetProperties<T>(object detail, string? name) {
        if (string.IsNullOrWhiteSpace(name) && detail is T targetObject) {
            // The whole object is our target
            return [targetObject];
        }

        var properties = GetProperties<T>(detail);
        if (!string.IsNullOrWhiteSpace(name)) 
            properties = properties.Where(prop => prop.Name == name);

        var matchingObjects = properties
            .Select(prop => prop.GetValue(detail))
            .Where(obj => obj != null)
            .OfType<T>() // Convert to type T
            .ToList();

        return matchingObjects;
    }

    private static IEnumerable<PropertyInfo> GetProperties<T>(object detail) {
        var properties = detail
            .GetType().GetProperties()
            .Where(prop => prop.PropertyType == typeof(T));
        return properties;
    }

    public virtual object GetViewModel() => new {
        Title,
        Message,
    };

    public override string ToString() {
        var sb = new StringBuilder();
        sb.AppendLine("Detail:")
            .AppendLine($"\tTitle: {Title}");
        if (Message is not null)
            sb.AppendLine($"\tMessage: {Message}");
        if (StatusCode is not null)
            sb.AppendLine($"\tStatusCode: {StatusCode}");
        if (MoreDetails.Count > 0) {
            sb.AppendLine("\tMoreDetails:");
            foreach (var detail in MoreDetails)
                sb.AppendLine($"\t\t{detail}");
        }

        return sb.ToString();
    }
}