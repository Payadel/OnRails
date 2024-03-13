using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace OnRails.ResultDetails;

[DebuggerStepThrough]
public class ResultDetail {
    public string Title { get; protected init; }
    public string? Message { get; protected init; }
    public int? StatusCode { get; protected init; }
    public List<object> MoreDetails { get; } = [];
    public bool View { get; set; }

    public ResultDetail(string title, string? message = null, int? statusCode = null, object? moreDetails = null,
        bool view = false) {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(title));

        Title = title;
        Message = message;
        StatusCode = statusCode;
        View = view;
        if (moreDetails is not null)
            MoreDetails.Add(moreDetails);
    }

    public void AddDetail(object newDetail) {
        ArgumentNullException.ThrowIfNull(newDetail);
        MoreDetails.Add(newDetail);
    }

    public bool IsTypeOf(Type type) => GetType() == type;

    public List<T> GetMoreDetailProperties<T>(string? name = null) {
        if (MoreDetails.Count == 0)
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

    public virtual Dictionary<string, object?> GetViewModel() =>
        new() {
            { nameof(Title), Title },
            { nameof(Message), Message }
        };

    public override string ToString() {
        var sb = new StringBuilder();

        sb.AppendLine($"Title: {Title}");
        if (Message is not null)
            sb.AppendLine($"Message: {Message}");
        if (StatusCode is not null)
            sb.AppendLine($"Status Code: {StatusCode}");
        sb.AppendLine($"View: {View}");

        if (MoreDetails.Count > 0) {
            sb.AppendLine("MoreDetails:");
            foreach (var detail in MoreDetails)
                sb.AppendLine($"\t{detail}");
        }

        return sb.ToString();
    }
}