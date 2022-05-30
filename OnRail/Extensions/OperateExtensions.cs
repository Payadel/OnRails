namespace OnRail.Extensions {
    public static class OperateExtensions {
        #region OperateWhen

        public static Result OperateWhen(
            bool predicate,
            Func<Result> function
        ) => predicate ? function() : Result.Ok();

        public static Result OperateWhen(
            Func<bool> predicate,
            Func<Result> function
        ) => OperateWhen(predicate(), function);

        public static Result OperateWhen(
            bool predicate,
            Action action) {
            if (predicate)
                action();
            return Result.Ok();
        }

        public static Result OperateWhen(
            Func<bool> predicate,
            Action action) => OperateWhen(predicate(), action);

        public static Result<T> OperateWhen<T>(
            this T @this,
            bool predicate,
            Func<Result<T>> function
        ) => predicate ? function() : Result<T>.Ok(@this);

        public static Result<T> OperateWhen<T>(
            this Result<T> @this,
            Result predicate,
            Func<Result<T>> operation
        ) => predicate.IsSuccess ? operation() : @this;

        public static Result<T> OperateWhen<T>(
            this Result<T> @this,
            Result predicate,
            Action operation
        ) {
            if (predicate.IsSuccess) {
                operation();
            }

            return @this;
        }

        public static Result<T> OperateWhen<T>(
            this Result<T> @this,
            bool predicate,
            Func<Result<T>> operation
        ) => predicate ? operation() : @this;

        public static Result<T> OperateWhen<T>(
            this Result<T> @this,
            bool predicate,
            Action operation
        ) {
            if (predicate) {
                operation();
            }

            return @this;
        }

        public static Result<T> OperateWhen<T>(
            this Result<T> @this,
            Func<Result> predicate,
            Func<Result<T>> operation
        ) => @this.OperateWhen(predicate().IsSuccess, operation);

        public static Result<T> OperateWhen<T>(
            this Result<T> @this,
            Func<Result> predicate,
            Action operation
        ) => @this.OperateWhen(predicate().IsSuccess, operation);

        public static Result<T> OperateWhen<T>(
            this T @this,
            Func<bool> predicate,
            Func<Result<T>> function
        ) => @this.OperateWhen(predicate(), function);

        public static Result<T> OperateWhen<T>(
            this T @this,
            bool predicate,
            Func<Result> function
        ) => predicate ? function().MapMethodResult(@this) : Result<T>.Ok(@this);

        public static Result<T> OperateWhen<T>(
            this T @this,
            Func<bool> predicate,
            Func<Result> function
        ) => @this.OperateWhen(predicate(), function);

        public static Result<T> OperateWhen<T>(
            this T @this,
            Func<T, bool> predicate,
            Func<Result<T>> function
        ) => @this.OperateWhen(predicate(@this), function);

        public static Result<T> OperateWhen<T>(
            this T @this,
            Func<T, bool> predicate,
            Func<Result> function
        ) => @this.OperateWhen(predicate(@this), function);

        public static Result<T> OperateWhen<T>(
            this T @this,
            bool predicate,
            Func<T, Result<T>> function
        ) => predicate ? function(@this) : Result<T>.Ok(@this);

        public static Result<T> OperateWhen<T>(
            this T @this,
            Func<bool> predicate,
            Func<T, Result<T>> function
        ) => @this.OperateWhen(predicate(), function);

        public static Result<T> OperateWhen<T>(
            this T @this,
            bool predicate,
            Func<T, Result> function
        ) => predicate ? function(@this).MapMethodResult(@this) : Result<T>.Ok(@this);

        public static Result<T> OperateWhen<T>(
            this T @this,
            Func<T, bool> predicate,
            Func<T, Result<T>> function
        ) => @this.OperateWhen(predicate(@this), function);

        public static Result<T> OperateWhen<T>(
            this T @this,
            Func<T, bool> predicate,
            Func<T, Result> function
        ) => @this.OperateWhen(predicate(@this), function);

        public static Result OperateWhen(
            Func<Result> predicate,
            Func<Result> function
        ) => OperateWhen(predicate().IsSuccess, function);

        public static Result OperateWhen(
            Func<Result> predicate,
            Action action
        ) => OperateWhen(predicate().IsSuccess, action);

        public static Result OperateWhen(
            Result predicate,
            Func<Result> function
        ) => OperateWhen(predicate.IsSuccess, function);

        public static Result<T> OperateWhen<T>(
            this T @this,
            Func<Result> predicate,
            Func<Result<T>> function
        ) => @this.OperateWhen(predicate().IsSuccess, function);

        public static Result<T> OperateWhen<T>(
            this T @this,
            Func<T, Result> predicate,
            Func<Result<T>> function
        ) => @this.OperateWhen(predicate(@this).IsSuccess, function);

        public static Result<T> OperateWhen<T>(
            this T @this,
            Func<Result> predicate,
            Func<T, Result<T>> function
        ) => @this.OperateWhen(predicate().IsSuccess, function);

        public static Result<T> OperateWhen<T>(
            this T @this,
            Result predicate,
            Func<T, Result<T>> function
        ) => @this.OperateWhen(predicate.IsSuccess, function);

        public static Result<T> OperateWhen<T>(
            this T @this,
            Func<T, Result> predicate,
            Func<T, Result<T>> function
        ) => @this.OperateWhen(predicate(@this).IsSuccess, function);

        public static T OperateWhen<T>(
            this T @this,
            bool predicate,
            Func<T> function
        ) => predicate ? function() : @this;

        public static T OperateWhen<T>(
            this T @this,
            Func<bool> predicate,
            Func<T> function
        ) => @this.OperateWhen(predicate(), function);

        public static Result<T> OperateWhen<T>(
            this T @this,
            bool predicate,
            Action action) {
            if (predicate)
                action();
            return Result<T>.Ok(@this);
        }

        public static Result<T> OperateWhen<T>(
            this T @this,
            Func<bool> predicate,
            Action action) =>
            @this.OperateWhen(predicate(), action);

        public static T OperateWhen<T>(
            this T @this,
            Func<T, bool> predicate,
            Func<T> function
        ) => @this.OperateWhen(predicate(@this), function);

        public static Result<T> OperateWhen<T>(
            this T @this,
            Func<T, bool> predicate,
            Action action) =>
            @this.OperateWhen(predicate(@this), action);

        public static T OperateWhen<T>(
            this T @this,
            bool predicate,
            Func<T, T> function
        ) => predicate ? function(@this) : @this;

        public static T OperateWhen<T>(
            this T @this,
            Func<bool> predicate,
            Func<T, T> function
        ) => @this.OperateWhen(predicate(), function);

        public static Result<T> OperateWhen<T>(
            this T @this,
            bool predicate,
            Action<T> action) {
            if (predicate)
                action(@this);
            return Result<T>.Ok(@this);
        }

        public static Result<T> OperateWhen<T>(
            this T @this,
            Func<bool> predicate,
            Action<T> action) =>
            @this.OperateWhen(predicate(), action);

        public static T OperateWhen<T>(
            this T @this,
            Func<T, bool> predicate,
            Func<T, T> function
        ) => @this.OperateWhen(predicate(@this), function);

        public static Result<T> OperateWhen<T>(
            this T @this,
            Func<T, bool> predicate,
            Action<T> action) =>
            @this.OperateWhen(predicate(@this), action);

        public static T OperateWhen<T>(
            this T @this,
            Result predicate,
            Func<T> function) =>
            @this.OperateWhen(predicate.IsSuccess, function);

        public static Result<T> OperateWhen<T>(
            this T @this,
            Result predicate,
            Action action
        ) => @this.OperateWhen(predicate.IsSuccess, action);

        public static T OperateWhen<T>(
            this T @this,
            Func<T, Result> predicate,
            Func<T> function) =>
            @this.OperateWhen(predicate(@this).IsSuccess, function);

        public static Result<T> OperateWhen<T>(
            this T @this,
            Func<T, Result> predicate,
            Action action
        ) => @this.OperateWhen(predicate(@this).IsSuccess, action);

        public static T OperateWhen<T>(
            this T @this,
            Result predicate,
            Func<T, T> function) =>
            @this.OperateWhen(predicate.IsSuccess, function);

        public static Result<T> OperateWhen<T>(
            this T @this,
            Result predicate,
            Action<T> action
        ) => @this.OperateWhen(predicate.IsSuccess, action);

        public static T OperateWhen<T>(
            this T @this,
            Func<T, Result> predicate,
            Func<T, T> function) =>
            @this.OperateWhen(predicate(@this).IsSuccess, function);

        public static Result<T> OperateWhen<T>(
            this T @this,
            Func<T, Result> predicate,
            Action<T> action
        ) => @this.OperateWhen(predicate(@this).IsSuccess, action);

        #endregion

        #region OperateWhenAsync

        public static async Task OperateWhenAsync(
            bool predicate,
            Func<Task> function) {
            if (predicate)
                await function();
        }

        public static Task OperateWhenAsync(
            Func<bool> predicate,
            Func<Task> function) =>
            OperateWhenAsync(predicate(), function);

        public static async Task<Result> OperateWhenAsync(
            bool predicate,
            Func<Task<Result>> function) {
            if (predicate)
                return await function();
            return Result.Ok();
        }

        public static Task<Result> OperateWhenAsync(
            Func<bool> predicate,
            Func<Task<Result>> function) =>
            OperateWhenAsync(predicate(), function);

        public static async Task<T> OperateWhenAsync<T>(
            this Task<T> @this,
            bool predicate,
            Func<Task<T>> function) {
            var t = await @this;
            if (predicate)
                return await function();
            return t;
        }

        public static async Task<Result<T>> OperateWhenAsync<T>(
            this Task<Result<T>> @this,
            bool predicate,
            Func<Task<T>> function) {
            var t = await @this;
            return predicate ? Result<T>.Ok(await function()) : t;
        }

        public static async Task<Result<T>> OperateWhenAsync<T>(
            this Task<T> @this,
            bool predicate,
            Func<Task<Result<T>>> function) {
            var t = await @this;
            if (predicate)
                return await function();
            return Result<T>.Ok(t);
        }

        public static async Task<T> OperateWhenAsync<T>(
            this Task<T> @this,
            bool predicate,
            Func<T, Task<T>> function) {
            var t = await @this;
            if (predicate)
                return await function(t);
            return t;
        }

        public static async Task<Result<T>> OperateWhenAsync<T>(
            this Task<T> @this,
            bool predicate,
            Func<T, Task<Result<T>>> function) {
            var t = await @this;
            if (predicate)
                return await function(t);
            return Result<T>.Ok(t);
        }

        public static Task<T> OperateWhenAsync<T>(
            this Task<T> @this,
            Func<bool> predicate,
            Func<T, Task<T>> function) =>
            @this.OperateWhenAsync(predicate(), function);

        public static Task<Result<T>> OperateWhenAsync<T>(
            this Task<T> @this,
            Func<bool> predicate,
            Func<T, Task<Result<T>>> function) =>
            @this.OperateWhenAsync(predicate(), function);

        public static async Task<T> OperateWhenAsync<T>(
            this Task<T> @this,
            Func<T, bool> predicate,
            Func<T, Task<T>> function) {
            var t = await @this;
            if (predicate(t))
                return await function(t);
            return t;
        }

        public static async Task<Result<T>> OperateWhenAsync<T>(
            this Task<T> @this,
            Func<T, bool> predicate,
            Func<T, Task<Result<T>>> function) {
            var t = await @this;
            if (predicate(t))
                return await function(t);
            return Result<T>.Ok(t);
        }

        public static async Task<T> OperateWhenAsync<T>(
            this Task<T> @this,
            bool predicate,
            Func<T, T> function) {
            var t = await @this;
            return predicate ? function(t) : t;
        }

        public static async Task<Result<T>> OperateWhenAsync<T>(
            this Task<T> @this,
            bool predicate,
            Func<T, Result<T>> function) {
            var t = await @this;
            return predicate ? function(t) : Result<T>.Ok(t);
        }

        public static Task<T> OperateWhenAsync<T>(
            this Task<T> @this,
            Func<bool> predicate,
            Func<T, T> function) =>
            @this.OperateWhenAsync(predicate(), function);

        public static Task<Result<T>> OperateWhenAsync<T>(
            this Task<T> @this,
            Func<bool> predicate,
            Func<T, Result<T>> function) =>
            @this.OperateWhenAsync(predicate(), function);

        public static async Task<T> OperateWhenAsync<T>(
            this Task<T> @this,
            Func<T, bool> predicate,
            Func<T, T> function) {
            var t = await @this;
            return predicate(t) ? function(t) : t;
        }

        public static async Task<Result<T>> OperateWhenAsync<T>(
            this Task<T> @this,
            Func<T, bool> predicate,
            Func<T, Result<T>> function) {
            var t = await @this;
            return predicate(t) ? function(t) : Result<T>.Ok(t);
        }

        public static Task<T> OperateWhenAsync<T>(
            this Task<T> @this,
            Func<bool> predicate,
            Func<Task<T>> function) =>
            @this.OperateWhenAsync(predicate(), function);

        public static Task<Result<T>> OperateWhenAsync<T>(
            this Task<Result<T>> @this,
            Func<bool> predicate,
            Func<Task<T>> function) =>
            @this.OperateWhenAsync(predicate(), function);

        public static Task<Result<T>> OperateWhenAsync<T>(
            this Task<T> @this,
            Func<bool> predicate,
            Func<Task<Result<T>>> function) =>
            @this.OperateWhenAsync(predicate(), function);

        public static async Task<T> OperateWhenAsync<T>(
            this Task<T> @this,
            Func<T, bool> predicate,
            Func<Task<T>> function) {
            var t = await @this;
            if (predicate(t))
                return await function();
            return t;
        }

        public static async Task<Result<T>> OperateWhenAsync<T>(
            this Task<T> @this,
            Func<T, bool> predicate,
            Func<Task<Result<T>>> function) {
            var t = await @this;
            if (predicate(t))
                return await function();
            return Result<T>.Ok(t);
        }

        public static async Task<T> OperateWhenAsync<T>(
            this T @this,
            bool predicate,
            Func<Task<T>> function) {
            if (predicate)
                return await function();
            return @this;
        }

        public static async Task<T> OperateWhenAsync<T>(
            this T @this,
            bool predicate,
            Func<Task> function) {
            if (predicate)
                await function();
            return @this;
        }

        public static async Task<Result<T>> OperateWhenAsync<T>(
            this Result<T> @this,
            bool predicate,
            Func<Task<T>> function) =>
            predicate ? Result<T>.Ok(await function()) : @this;

        public static async Task<Result<T>> OperateWhenAsync<T>(
            this T @this,
            bool predicate,
            Func<Task<Result<T>>> function) {
            if (predicate)
                return await function();
            return Result<T>.Ok(@this);
        }

        public static async Task<Result<T>> OperateWhenAsync<T>(
            this Result<T> @this,
            bool predicate,
            Func<Task<Result<T>>> function) {
            if (predicate)
                return await function();
            return @this;
        }

        public static Task<T> OperateWhenAsync<T>(
            this T @this,
            Func<bool> predicate,
            Func<Task<T>> function) =>
            @this.OperateWhenAsync(predicate(), function);

        public static Task<T> OperateWhenAsync<T>(
            this T @this,
            Func<bool> predicate,
            Func<Task> function) =>
            @this.OperateWhenAsync(predicate(), function);

        public static Task<Result<T>> OperateWhenAsync<T>(
            this Result<T> @this,
            Func<bool> predicate,
            Func<Task<T>> function) =>
            @this.OperateWhenAsync(predicate(), function);

        public static Task<Result<T>> OperateWhenAsync<T>(
            this T @this,
            Func<bool> predicate,
            Func<Task<Result<T>>> function) =>
            @this.OperateWhenAsync(predicate(), function);

        public static Task<Result<T>> OperateWhenAsync<T>(
            this Result<T> @this,
            Func<bool> predicate,
            Func<Task<Result<T>>> function) =>
            @this.OperateWhenAsync(predicate(), function);

        public static async Task<Result<T>> OperateWhenAsync<T>(
            this Task<Result<T>> @this,
            bool predicate,
            Func<Task<Result<T>>> function) {
            var t = await @this;
            if (predicate)
                return await function();
            return t;
        }

        public static Task<T> OperateWhenAsync<T>(
            this T @this,
            Func<T, bool> predicate,
            Func<Task<T>> function) =>
            @this.OperateWhenAsync(predicate(@this), function);

        public static Task<Result<T>> OperateWhenAsync<T>(
            this T @this,
            Func<T, bool> predicate,
            Func<Task<Result<T>>> function) =>
            @this.OperateWhenAsync(predicate(@this), function);

        public static async Task<T> OperateWhenAsync<T>(
            this T @this,
            bool predicate,
            Func<T, Task<T>> function) {
            if (predicate)
                return await function(@this);
            return @this;
        }

        public static async Task<Result<T>> OperateWhenAsync<T>(
            this T @this,
            bool predicate,
            Func<T, Task<Result<T>>> function) {
            if (predicate)
                return await function(@this);
            return Result<T>.Ok(@this);
        }

        public static Task<T> OperateWhenAsync<T>(
            this T @this,
            Func<bool> predicate,
            Func<T, Task<T>> function) =>
            @this.OperateWhenAsync(predicate(), function);

        public static Task<Result<T>> OperateWhenAsync<T>(
            this T @this,
            Func<bool> predicate,
            Func<T, Task<Result<T>>> function) =>
            @this.OperateWhenAsync(predicate(), function);

        public static Task<T> OperateWhenAsync<T>(
            this T @this,
            Func<T, bool> predicate,
            Func<T, Task<T>> function) =>
            @this.OperateWhenAsync(predicate(@this), function);

        public static Task<Result<T>> OperateWhenAsync<T>(
            this T @this,
            Func<T, bool> predicate,
            Func<T, Task<Result<T>>> function) =>
            @this.OperateWhenAsync(predicate(@this), function);

        public static Task<T> OperateWhenAsync<T>(
            this T @this,
            Func<T, Result> predicate,
            Func<Task<T>> function) =>
            @this.OperateWhenAsync(predicate(@this).IsSuccess, function);

        public static Task<Result<T>> OperateWhenAsync<T>(
            this T @this,
            Func<T, Result> predicate,
            Func<Task<Result<T>>> function) =>
            @this.OperateWhenAsync(predicate(@this).IsSuccess, function);

        #endregion

        #region TeeOperateWhen

        public static Result<T> TeeOperateWhen<T>(
            this T @this,
            bool predicate,
            Func<Result> function
        ) => predicate ? function().MapMethodResult(@this) : Result<T>.Ok(@this);

        public static Result<T> TeeOperateWhen<T>(
            this T @this,
            Result predicate,
            Func<Result> function
        ) => @this.TeeOperateWhen(predicate.IsSuccess, function);

        public static T TeeOperateWhen<T>(
            this T @this,
            bool predicate,
            Action action
        ) => predicate ? @this.Tee(action) : @this;

        public static T TeeOperateWhen<T>(
            this T @this,
            Func<T, bool> predicate,
            Action action
        ) => @this.TeeOperateWhen(predicate(@this), action);

        public static T TeeOperateWhen<T>(
            this T @this,
            bool predicate,
            Action<T> action
        ) => predicate ? @this.Tee(action) : @this;

        public static T TeeOperateWhen<T>(
            this T @this,
            Func<T, bool> predicate,
            Action<T> action
        ) => @this.TeeOperateWhen(predicate(@this), action);

        public static T TeeOperateWhen<T>(
            this T @this,
            Result predicate,
            Action action
        ) => @this.TeeOperateWhen(predicate.IsSuccess, action);

        public static T TeeOperateWhen<T>(
            this T @this,
            Func<T, Result> predicate,
            Action action
        ) => @this.TeeOperateWhen(predicate(@this).IsSuccess, action);

        public static T TeeOperateWhen<T>(
            this T @this,
            Result predicate,
            Action<T> action
        ) => @this.TeeOperateWhen(predicate.IsSuccess, action);

        public static T TeeOperateWhen<T>(
            this T @this,
            Func<T, Result> predicate,
            Action<T> action
        ) => @this.TeeOperateWhen(predicate(@this).IsSuccess, action);

        #endregion

        #region TeeOperateWhenAsync

        public static async Task<T> TeeOperateWhenAsync<T>(
            this T @this,
            bool predicate,
            Func<Task> function) {
            if (predicate)
                await function();
            return @this;
        }

        public static async Task<Result<T>> TeeOperateWhenAsync<T>(
            this Result<T> @this,
            bool predicate,
            Func<Task> function) {
            if (predicate)
                await function();
            return @this;
        }

        public static async Task<Result<TSource>> TeeOperateWhenAsync<TSource, TResult>(
            this TSource @this,
            bool predicate,
            Func<Task<TResult>> function) {
            if (predicate)
                await function();
            return Result<TSource>.Ok(@this);
        }

        public static async Task<Result<TSource>> TeeOperateWhenAsync<TSource, TResult>(
            this Result<TSource> @this,
            bool predicate,
            Func<Task<TResult>> function) {
            if (predicate)
                await function();
            return @this;
        }

        public static Task<T> TeeOperateWhenAsync<T>(
            this T @this,
            Func<bool> predicate,
            Func<Task> function) =>
            @this.TeeOperateWhenAsync(predicate(), function);

        public static Task<Result<T>> TeeOperateWhenAsync<T>(
            this Result<T> @this,
            Func<bool> predicate,
            Func<Task> function) =>
            @this.TeeOperateWhenAsync(predicate(), function);

        public static Task<Result<TSource>> TeeOperateWhenAsync<TSource, TResult>(
            this TSource @this,
            Func<bool> predicate,
            Func<Task<TResult>> function) =>
            @this.TeeOperateWhenAsync(predicate(), function);

        public static Task<Result<TSource>> TeeOperateWhenAsync<TSource, TResult>(
            this Result<TSource> @this,
            Func<bool> predicate,
            Func<Task<TResult>> function) =>
            @this.TeeOperateWhenAsync(predicate(), function);

        public static Task<T> TeeOperateWhenAsync<T>(
            this T @this,
            Func<T, bool> predicate,
            Func<Task> function) =>
            @this.TeeOperateWhenAsync(predicate(@this), function);

        public static Task<Result<TSource>> TeeOperateWhenAsync<TSource, TResult>(
            this TSource @this,
            Func<TSource, bool> predicate,
            Func<Task<TResult>> function) =>
            @this.TeeOperateWhenAsync(predicate(@this), function);

        public static async Task<T> TeeOperateWhenAsync<T>(
            this T @this,
            bool predicate,
            Func<T, Task> function) {
            if (predicate)
                await function(@this);
            return @this;
        }

        public static Task<T> TeeOperateWhenAsync<T>(
            this T @this,
            Func<bool> predicate,
            Func<T, Task> function) =>
            @this.TeeOperateWhenAsync(predicate(), function);

        public static async Task<Result<TSource>> TeeOperateWhenAsync<TSource, TResult>(
            this TSource @this,
            bool predicate,
            Func<TSource, Task<TResult>> function) {
            if (predicate)
                await function(@this);
            return Result<TSource>.Ok(@this);
        }

        public static Task<Result<TSource>> TeeOperateWhenAsync<TSource, TResult>(
            this TSource @this,
            Func<bool> predicate,
            Func<TSource, Task<TResult>> function) =>
            @this.TeeOperateWhenAsync(predicate(), function);

        #endregion

        #region TryOperateWhen

        public static Result TryOperateWhen(
            Func<bool> predicateFun,
            Func<Result> function
        ) => TryExtensions.Try(predicateFun)
            .OnSuccess(predict => OperateWhen(predict, function));

        public static Result TryOperateWhen(
            bool predicate, Action action) =>
            OperateWhen(predicate, () => TryExtensions.Try(action));

        public static Result TryOperateWhen(
            Func<bool> predicateFun, Action action) =>
            TryExtensions.Try(predicateFun)
                .OnSuccess(predict => TryOperateWhen(predict, action));

        public static Result<T> TryOperateWhen<T>(
            this T @this,
            Func<bool> predicateFun,
            Func<Result<T>> function
        ) => TryExtensions.Try(predicateFun)
            .OnSuccess(predict => @this.OperateWhen(predict, function));

        public static Result<T> TryOperateWhen<T>(
            this T @this,
            Func<bool> predicateFun,
            Func<Result> function
        ) => TryExtensions.Try(predicateFun)
            .OnSuccess(predict => @this.OperateWhen(predict, function));

        public static Result<T> TryOperateWhen<T>(
            this T @this,
            Func<T, bool> predicateFun,
            Func<Result<T>> function
        ) => @this.TryMap(predicateFun)
            .OnSuccess(predict => @this.OperateWhen(predict, function));

        public static Result<T> TryOperateWhen<T>(
            this T @this,
            Func<T, bool> predicateFun,
            Func<Result> function
        ) => @this.TryMap(predicateFun)
            .OnSuccess(predict => @this.OperateWhen(predict, function));

        public static Result<T> TryOperateWhen<T>(
            this T @this,
            Func<bool> predicateFun,
            Func<T, Result<T>> function
        ) => TryExtensions.Try(predicateFun)
            .OnSuccess(predict => @this.OperateWhen(predict, function));

        public static Result<T> TryOperateWhen<T>(
            this T @this,
            Func<T, bool> predicateFun,
            Func<T, Result<T>> function
        ) => @this.TryMap(predicateFun)
            .OnSuccess(predict => @this.OperateWhen(predict, function));

        public static Result<T> TryOperateWhen<T>(
            this T @this,
            Func<T, bool> predicateFun,
            Func<T, Result> function
        ) => @this.TryMap(predicateFun)
            .OnSuccess(predict => @this.OperateWhen(predict, function));

        public static Result TryOperateWhen(
            Func<Result> predicate,
            Action action
        ) => TryOperateWhen(predicate().IsSuccess, action);

        public static Result<T> TryOperateWhen<T>(
            this T @this,
            bool predicate, Action action) =>
            @this.OperateWhen(predicate, () => TryExtensions.Try(action));

        public static Result<T> TryOperateWhen<T>(
            this T @this,
            Func<bool> predicateFun, Action action) =>
            TryExtensions.Try(predicateFun)
                .TryOnSuccess(predict => @this.TryOperateWhen(predict, action));

        public static Result<T> TryOperateWhen<T>(
            this T @this,
            Func<T, bool> predicateFun,
            Action action) => @this.TryMap(predicateFun)
            .OnSuccess(predict => @this.OperateWhen(predict, action));

        public static Result<T> TryOperateWhen<T>(
            this T @this,
            bool predicate,
            Action<T> action) =>
            @this.OperateWhen(predicate, () => @this.Try(action));

        public static Result<T> TryOperateWhen<T>(
            this T @this,
            Func<bool> predicateFun,
            Action<T> action) =>
            TryExtensions.Try(predicateFun)
                .TryOnSuccess(predict => @this.TryOperateWhen(predict, action));

        public static Result<T> TryOperateWhen<T>(
            this T @this,
            Func<T, bool> predicateFun,
            Action<T> action) => @this.TryMap(predicateFun)
            .OnSuccess(predict => @this.OperateWhen(predict, action));

        public static Result<T> TryOperateWhen<T>(
            this T @this,
            Result predicate,
            Action action
        ) => @this.TryOperateWhen(predicate.IsSuccess, action);

        public static Result<T> TryOperateWhen<T>(
            this T @this,
            Func<T, Result> predicate,
            Action action
        ) => @this.TryOperateWhen(predicate(@this).IsSuccess, action);

        public static Result<T> TryOperateWhen<T>(
            this T @this,
            Result predicate,
            Action<T> action
        ) => @this.TryOperateWhen(predicate.IsSuccess, action);

        public static Result<T> TryOperateWhen<T>(
            this T @this,
            Func<T, Result> predicate,
            Action<T> action
        ) => @this.TryOperateWhen(predicate(@this).IsSuccess, action);

        #endregion

        //TODO: TryOperateWhenAsync
    }
}