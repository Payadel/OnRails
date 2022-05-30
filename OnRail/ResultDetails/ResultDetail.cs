using System.Reflection;

namespace OnRail.ResultDetails;

public class ResultDetail {
    public ResultDetail(string title, string? message = null, int? statusCode = null, object? moreDetails = null) {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(title));

        Title = title;
        StatusCode = statusCode;
        Message = message;
        if (moreDetails is not null)
            MoreDetails = new List<object> {moreDetails};
    }

    public string Title { get; }
    public string? Message { get; }
    public int? StatusCode { get; }
    public List<object>? MoreDetails { get; private set; }

    public void AddDetail(object newDetail) {
        if (newDetail == null!)
            return;
        MoreDetails ??= new List<object>();
        MoreDetails.Add(newDetail);
    }

    public List<object> GetMoreDetailProperties(string? name = null, Type? type = null) {
        if (string.IsNullOrWhiteSpace(name) && type is null)
            throw new ArgumentException("At least one of the inputs must not be empty.");
        if (MoreDetails is null || !MoreDetails.Any())
            return new List<object>();

        var result = new List<object>();
        foreach (var detail in MoreDetails) {
            if (string.IsNullOrWhiteSpace(name) && detail.GetType() == type) {
                //The whole object is our target
                result.Add(detail);
                continue;
            }

            var props = detail.GetType().GetProperties();

            IEnumerable<PropertyInfo> propertyInfos = new List<PropertyInfo>();
            if (!string.IsNullOrWhiteSpace(name))
                propertyInfos = props.Where(prop => prop.Name == name);
            if (type is not null)
                propertyInfos = propertyInfos.Where(prop => prop.PropertyType == type);

            var objs = propertyInfos.Select(prop => prop.GetValue(detail, null))
                .Where(obj => obj is not null);
            result.AddRange(objs!);
        }

        return result;
    }
}