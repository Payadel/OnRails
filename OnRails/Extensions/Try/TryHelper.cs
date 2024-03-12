using System.Text;
using OnRails.ResultDetails;

namespace OnRails.Extensions.Try;

internal static class TryHelper {
    public static ErrorDetail GenerateError(List<ErrorDetail> errors, int numOfTry) {
        var message = new StringBuilder($"Operation failed with {numOfTry} attempts. ");
        if (errors.Count > 0) {
            message.Append(
                $"The details of the {errors.Count} error(s) are stored in the '{nameof(ErrorDetail.Errors)}' field. ");
        }

        var errorDetail = new ErrorDetail(message: message.ToString());
        errorDetail.Errors.AddRange(errors);

        return errorDetail;
    }
}