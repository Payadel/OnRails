All notable changes to this project will be documented in this file. We follow
the [Semantic Versioning 2.0.0](http://semver.org/) format.

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