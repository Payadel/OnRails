using System.Text;
using OnRails.ResultDetails;
using OnRails.ResultDetails.Errors;

namespace OnRails.Extensions.Try;

internal static class TryHelper {
    public static CollectionErrorDetail GenerateError(List<ErrorDetail> errors, int numOfTry) {
        var message = new StringBuilder($"Operation failed with {numOfTry} attempts. ");

        if (errors.Count > 0) {
            message.Append(
                $"The details of the {errors.Count} error(s) are stored in the '{nameof(CollectionErrorDetail)}.{nameof(CollectionErrorDetail.Errors)}' field. ");
        }

        var errorDetail = new CollectionErrorDetail(errors, message: message.ToString());
        return errorDetail;
    }
}