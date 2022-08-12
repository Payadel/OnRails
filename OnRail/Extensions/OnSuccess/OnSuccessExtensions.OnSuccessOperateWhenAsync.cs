using OnRail.Extensions.OperateWhen;

namespace OnRail.Extensions.OnSuccess;

public static partial class OnSuccessExtensions {
    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> @this,
        Func<bool> predicate,
        Func<Result> operation
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> @this,
        Func<bool> predicate,
        Func<Task> operation
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> @this,
        Func<bool> predicate,
        Action operation
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Func<Result<T>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Func<Task> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Action<T> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        Func<Result<T>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate(source), operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        Action operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate(source), operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        Func<Task> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate(source), operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        Action<T> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate(source), operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Func<T, Result<T>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        Func<T, Result<T>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate(source), operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Func<T> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Func<T, T> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        Func<T, T> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate(source), operation));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> @this,
        bool predicate,
        Func<Result> operation
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> @this,
        bool predicate,
        Action operation
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> @this,
        bool predicate,
        Func<Task> operation
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<Result<T>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Action operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<Task> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Action<T> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<T, Result<T>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<T> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<T, T> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Result @this,
        Func<bool> predicate,
        Func<Task<Result>> operation
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Result @this,
        Func<bool> predicate,
        Func<Task> operation
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        Func<bool> predicate,
        Func<Task<Result<T>>> operation
    ) => @this.OnSuccess(() => @this.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        Func<T, bool> predicate,
        Func<Task<Result<T>>> operation
    ) => @this.OnSuccess(source => @this.OperateWhen(predicate(source), operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        Func<T, bool> predicate,
        Func<Task> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        Func<bool> predicate,
        Func<T, Task<Result<T>>> operation
    ) => @this.OnSuccess(source => @this.OperateWhen<T>(predicate, () => operation(source)));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        Func<T, bool> predicate,
        Func<T, Task<Result<T>>> operation
    ) => @this.OnSuccess(source => @this.OperateWhen(predicate(source), () => operation(source)));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        Func<bool> predicate,
        Func<Task<T>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        Func<T, bool> predicate,
        Func<Task<T>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate(source), operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        Func<bool> predicate,
        Func<T, Task<T>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        Func<T, bool> predicate,
        Func<T, Task<T>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate(source), operation));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Result @this,
        bool predicate,
        Func<Task<Result>> operation
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Result @this,
        bool predicate,
        Func<Task> operation
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        bool predicate,
        Func<Task<Result<T>>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        bool predicate,
        Func<Task> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        bool predicate,
        Func<T, Task<Result<T>>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        bool predicate,
        Func<Task<T>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        bool predicate,
        Func<T, Task<T>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> @this,
        Func<bool> predicate,
        Func<Task<Result>> operation
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Func<Task<Result<T>>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        Func<Task<Result<T>>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate(source), operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Func<T, Task<Result<T>>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        Func<T, Task<Result<T>>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate(source), operation));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> @this,
        bool predicate,
        Func<Task<Result>> operation
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<Task<Result<T>>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<T, Task<Result<T>>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));
}