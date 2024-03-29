All notable changes to this project will be documented in this file. We follow
the [Semantic Versioning 2.0.0](http://semver.org/) format.

## 2.0.0 - 2022-10-18

### Added

- Make `ErrorDetail` nullable in method parameters
- `OperateWhen` overloads
- `OnSuccessExtensions.NewDetail` and `OnSuccessExtensions.NewDetailAsync`
- `OperateWhen` overloads

### Updated

- Uses `Func<Result, Result>` or `Func<Result<T>, Result<T>>` instead of `Func<ResultDetail, Result>` in method
  parameters
- Forces `SuccessDetail` for Ok results and `ErrorDetail` for Fail results.
- Renames `SelectResultsAsync` to `SelectResults`
- Renames `TeeOnSuccess` to `OnSuccessTee`
- Renames `TeeOnFail` to `OnFailTee`

### Moved

- `OnFailExtensions.AddMoreDetail` to `OnFailAddMoreDetails` and `OnFail`
- `OnFail` methods that have the same behavior as `TeeOnFail` are removed or moved.
- The `OnFail` methods that changed the `ErrorDetail` were moved to `OnSuccessExtensions.NewDetail`
- `TeeOnSuccessExtensions` Moved to `OnSuccessExtensions`
- `ThrowExceptionOnFail` methods to `OnFailExtensions` as `OnFailThrowException`

### Deprecate

- ArgumentError

### Fixed

- `numOfTry` implement
- Bug fixed: `public static Task<Result<List<T>>> Bind<T> (this IEnumerable<Task<T>> tasks,int numOfTry = 1)`
- `TryExtensions` error details [#16](https://github.com/Payadel/OnRail/issues/16)

### Removed

- `AddNumOfTry` methods in `Try` methods [#17](https://github.com/Payadel/OnRail/issues/17)

## 1.4.1 - 2022-10-17

### Fixed

- Minor updates in ResultDetails (Adds default title to constructor parameter)

## 1.4.0 - 2022-10-12

### Added

- `public static Task<Result> Map<TSource>(this Task<Result<TSource>> source)`
- `ActionResultExtensions`
- `GetStatusCodeOrDefault` to `ResultBase`
- `GetViewModel` to `ResultDetail`
- `ValidationError`

### Fixed

- Remove DRY in using `Try` methods (#7)

## 1.3.0 - 2022-08-18

### Fixed

- Uses `source` name for `this` parameter name
- Uses `condition` name for `bool` parameter name
- Uses `predicate` name for `Func<bool>` parameter name and etc
- Uses `action` name for `Action` parameter name
- Uses `function` name for `Func` parameter name
