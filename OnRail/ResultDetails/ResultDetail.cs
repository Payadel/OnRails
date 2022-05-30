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

    public List<object> GetDetailProperty(string name, Type type) {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));
        if (type == null) throw new ArgumentNullException(nameof(type));
        if (MoreDetails is null || !MoreDetails.Any())
            return new List<object>();

        return MoreDetails.Select(detail => detail.GetType()
                .GetProperties()
                .SingleOrDefault(prop => prop.Name == name && prop.PropertyType == type)
                ?.GetValue(detail, null))
            .Where(obj => obj is not null).ToList()!;
    }
}