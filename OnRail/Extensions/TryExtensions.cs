using OnRail.ResultDetails.Errors;

namespace OnRail.Extensions {
    public static class TryExtensions {
        #region Try

        public static Result<TResult> Try<TResult>(
            Func<TResult> function, int numOfTry = 1) {
            var counter = 0;
            while (true) {
                try {
                    return Result<TResult>.Ok(function());
                }
                catch (Exception e) {
                    counter++;
                    if (counter >= numOfTry)
                        return Result<TResult>.Fail(new ExceptionError(e,
                            moreDetails: new {numOfTry}));
                }
            }
        }

        public static Result Try(
            Func<Result> function) {
            try {
                return function();
            }
            catch (Exception e) {
                return Result.Fail(new ExceptionError(e, message: e.Message));
            }
        }

        public static Result<TResult> Try<TResult>(
            Func<Result<TResult>> function) {
            try {
                return function();
            }
            catch (Exception e) {
                return Result<TResult>.Fail(new ExceptionError(e, message: e.Message));
            }
        }

        public static Result Try(Action action) {
            try {
                action();
                return Result.Ok();
            }
            catch (Exception e) {
                return Result.Fail(new ExceptionError(e, message: e.Message));
            }
        }

        public static Result Try<T>(
            this T @this,
            Action<T> action) {
            try {
                action(@this);
                return Result.Ok();
            }
            catch (Exception e) {
                return Result.Fail(new ExceptionError(e));
            }
        }

        #endregion

        #region TryAsync

        public static async Task<Result<T>> TryAsync<T>(
            Func<Task<T>> function,
            int numOfTry) {
            var counter = 0;
            while (true) {
                try {
                    return Result<T>.Ok(await function());
                }
                catch (Exception e) {
                    counter++;
                    if (counter >= numOfTry)
                        return Result<T>.Fail(new ExceptionError(e,
                            moreDetails: new {numOfTry}));
                }
            }
        }

        public static async Task<Result<T>> TryAsync<T>(
            Func<Task<Result<T>>> function,
            int numOfTry) {
            var counter = 0;
            while (true) {
                try {
                    return await function();
                }
                catch (Exception e) {
                    counter++;
                    if (counter >= numOfTry)
                        return Result<T>.Fail(new ExceptionError(e,
                            moreDetails: new {numOfTry}));
                }
            }
        }

        public static async Task<Result> TryAsync(
            Func<Task> function,
            int numOfTry) {
            var counter = 0;
            while (true) {
                try {
                    await function();
                    return Result.Ok();
                }
                catch (Exception e) {
                    counter++;
                    if (counter >= numOfTry)
                        return Result.Fail(new ExceptionError(e,
                            moreDetails: new {numOfTry}));
                }
            }
        }

        public static async Task<Result> TryAsync(
            Func<Task<Result>> function,
            int numOfTry
        ) {
            var counter = 0;
            while (true) {
                try {
                    return await function();
                }
                catch (Exception e) {
                    counter++;
                    if (counter >= numOfTry)
                        return Result.Fail(new ExceptionError(e,
                            moreDetails: new {numOfTry}));
                }
            }
        }

        public static Task<Result> TryAsync<TSource>(
            this TSource @this,
            Func<TSource, Task> function,
            int numOfTry
        ) => TryAsync(() => function(@this), numOfTry);

        public static async Task<Result> TryAsync<TSource>(
            this Task<TSource> @this,
            Action<TSource> onSuccessFunction
        ) {
            try {
                var source = await @this;
                onSuccessFunction(source);
                return Result.Ok();
            }
            catch (Exception e) {
                return Result.Fail(new ExceptionError(e, e.Message));
            }
        }

        public static async Task<Result> TryAsync<TSource>(
            this Task<TSource> @this,
            Action onSuccessFunction
        ) {
            try {
                await @this;
                onSuccessFunction();
                return Result.Ok();
            }
            catch (Exception e) {
                return Result.Fail(new ExceptionError(e, e.Message));
            }
        }

        public static async Task<Result<T>> TryAsync<T>(
            Func<Task<T>> onSuccessFunction
        ) {
            try {
                var result = await onSuccessFunction();
                return Result<T>.Ok(result);
            }
            catch (Exception e) {
                return Result<T>.Fail(new ExceptionError(e, e.Message));
            }
        }

        public static async Task<Result> TryAsync(
            this Task @this,
            Action onSuccessFunction
        ) {
            try {
                await @this;
                onSuccessFunction();
                return Result.Ok();
            }
            catch (Exception e) {
                return Result.Fail(new ExceptionError(e, e.Message));
            }
        }

        public static async Task<Result> TryAsync(
            Func<Task<Result>> onSuccessFunction
        ) {
            try {
                return await onSuccessFunction();
            }
            catch (Exception e) {
                return Result.Fail(new ExceptionError(e, e.Message));
            }
        }

        public static async Task<Result> TryAsync<T>(
            this T @this,
            Func<T, Task<Result>> onSuccessFunction
        ) {
            try {
                return await onSuccessFunction(@this);
            }
            catch (Exception e) {
                return Result.Fail(new ExceptionError(e, e.Message));
            }
        }

        public static async Task<Result> TryAsync<T>(
            this T @this,
            Func<T, Task> onSuccessFunction
        ) {
            try {
                await onSuccessFunction(@this);
                return Result.Ok();
            }
            catch (Exception e) {
                return Result.Fail(new ExceptionError(e, e.Message));
            }
        }

        public static async Task<Result> TryAsync(
            this Task @this,
            Func<Result> onSuccessFunction
        ) {
            try {
                await @this;
                return onSuccessFunction();
            }
            catch (Exception e) {
                return Result.Fail(new ExceptionError(e, e.Message));
            }
        }

        public static async Task<Result> TryAsync(
            this Task @this,
            Func<Task<Result>> onSuccessFunction
        ) {
            try {
                await @this;
                return await onSuccessFunction();
            }
            catch (Exception e) {
                return Result.Fail(new ExceptionError(e, e.Message));
            }
        }

        public static async Task<Result<TResult>> TryAsync<TResult>(
            Func<Task<Result<TResult>>> onSuccessFunction
        ) {
            try {
                return await onSuccessFunction();
            }
            catch (Exception e) {
                return Result<TResult>.Fail(new ExceptionError(e, e.Message));
            }
        }

        public static async Task<Result> TryAsync<TSource>(
            this Task<TSource> @this,
            Func<TSource, Task> function,
            int numOfTry
        ) {
            var t = await @this;
            return await TryAsync(() => function(t), numOfTry);
        }

        public static Task<Result> TryAsync<TSource>(
            this TSource @this,
            Func<TSource, Task<Result>> function,
            int numOfTry
        ) => TryAsync(() => function(@this), numOfTry);

        public static async Task<Result> TryAsync<TSource>(
            this Task<TSource> @this,
            Func<TSource, Task<Result>> function,
            int numOfTry
        ) {
            var t = await @this;
            return await TryAsync(() => function(t), numOfTry);
        }

        #endregion
    }
}