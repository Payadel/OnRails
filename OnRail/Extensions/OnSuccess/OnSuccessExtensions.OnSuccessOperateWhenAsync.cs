using OnRail.Extensions.OperateWhen;

namespace OnRail.Extensions.OnSuccess;

public static partial class OnSuccessExtensions {
    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> @this,
        Func<bool> predicate,
        Func<Result> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> @this,
        Func<bool> predicate,
        Func<Task> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> @this,
        Func<bool> predicate,
        Action operation,
        int numOfTry = 1
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Func<Result<T>> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Func<Task> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Action<T> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        Func<Result<T>> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        Action operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        Func<Task> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        Action<T> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Func<T, Result<T>> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        Func<T, Result<T>> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Func<T> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Func<T, T> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        Func<T, T> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> @this,
        bool predicate,
        Func<Result> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> @this,
        bool predicate,
        Action operation,
        int numOfTry = 1
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> @this,
        bool predicate,
        Func<Task> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<Result<T>> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Action operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<Task> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Action<T> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<T, Result<T>> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<T> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<T, T> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Result @this,
        Func<bool> predicate,
        Func<Task<Result>> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Result @this,
        Func<bool> predicate,
        Func<Task> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        Func<bool> predicate,
        Func<Task<Result<T>>> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(() => @this.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        Func<T, bool> predicate,
        Func<Task<Result<T>>> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        Func<T, bool> predicate,
        Func<Task> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        Func<bool> predicate,
        Func<T, Task<Result<T>>> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        Func<T, bool> predicate,
        Func<T, Task<Result<T>>> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        Func<bool> predicate,
        Func<Task<T>> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        Func<T, bool> predicate,
        Func<Task<T>> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        Func<bool> predicate,
        Func<T, Task<T>> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        Func<T, bool> predicate,
        Func<T, Task<T>> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Result @this,
        bool predicate,
        Func<Task<Result>> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Result @this,
        bool predicate,
        Func<Task> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        bool predicate,
        Func<Task<Result<T>>> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        bool predicate,
        Func<Task> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        bool predicate,
        Func<T, Task<Result<T>>> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        bool predicate,
        Func<Task<T>> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        bool predicate,
        Func<T, Task<T>> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> @this,
        Func<bool> predicate,
        Func<Task<Result>> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Func<Task<Result<T>>> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        Func<Task<Result<T>>> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Func<T, Task<Result<T>>> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        Func<T, Task<Result<T>>> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> @this,
        bool predicate,
        Func<Task<Result>> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<Task<Result<T>>> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<T, Task<Result<T>>> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation, numOfTry));
}