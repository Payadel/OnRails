using OnRails.ResultDetails;

namespace OnRails.Utilities;

public static class ResultDetailExtensions {
    public static bool IsGenericErrorDetail(this ResultDetail resultDetail) {
        return resultDetail.GetType().IsGenericType &&
               resultDetail.GetType().GetGenericTypeDefinition() == typeof(ErrorDetail<>);
    }
}