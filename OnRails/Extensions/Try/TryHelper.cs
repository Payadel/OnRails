using System.Text;
using OnRails.ResultDetails;

namespace OnRails.Extensions.Try;

internal static class TryHelper {
    public static ErrorDetail GenerateError(List<object> errors, int numOfTry) {
        var message = new StringBuilder($"Operation failed with {numOfTry} attempts. ");
        if (errors.Any()) {
            message.Append(
                $"The details of the {errors.Count} errors are stored in the {nameof(ErrorDetail.MoreDetails)} field. ");
        }

        var exception = errors.FirstOrDefault(error => error is Exception) as Exception;
        if (exception is not null) {
            message.Append(
                $"At least one of the errors was an exception type, the first exception being stored in the {nameof(ErrorDetail.Exception)} field.");
        }

        var errorDetail = new ErrorDetail(title: "Operation Failed!",
            message: message.ToString(),
            exception: exception,
            statusCode: 500);

        foreach (var error in errors)
            errorDetail.AddDetail(error);

        return errorDetail;
    }
}