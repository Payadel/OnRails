All notable changes to this project will be documented in this file. We follow
the [Semantic Versioning 2.0.0](http://semver.org/) format.

## [3.0.0](https://github.com/Payadel/OnRails/compare/v2.0.0...v3.0.0) (2024-12-12)


### ⚠ BREAKING CHANGES

* **ConfigurationExtensions:** change output of `GetConfig` to nullable
* **BadRequestError:** use `Dictionary<string, List<string>> Errors` as custom field
* refactor CollectionErrorDetail.cs to ErrorDetailList.cs
* **Detail:** change default message of CreatedDetail.cs and AcceptedDetail.cs
* **Detail:** update WarningDetail.cs
* use `Microsoft.AspNetCore.App` instead of deprecated packages
* **ResultDetail:** change setter fields to `protected init`
* **WarningDetail:** 
* **AcceptedDetail:** big changes. add some props, update constructor, etc
* **CreatedDetail:** big changes. add some props, update constructor, etc
* **ResultDetail:** make setter for properties `public`
* **ResultDetail:** big changes
* **ActionResultView:** In the previous version, 200 code was default for success result even we have not any value. But in this version we use 204 for null value.
* **ActionResult:** rename `ActionResultObject` to `ActionResultView`
* **ResultDetail:** use `Dictionary` instead of `object` in `GetViewModel`
* **ErrorDetail:** `Exception` field is removed
* **ResultDetail:** change output of `AddDetail` method to `void`
* **Try:** update error detail
* **ObjectExtensions:** the `IsNullOrEmpty` removed
* **MustExtensions:** the `MustNotNullOrEmpty` removed
* **ExceptionError:** In constructor, default value for `message` removed and we set `exception.message` if it be null.
* **ResultDetail:** improve `ToString()`
* update dotnet sdk version to 8.0
* **ValidationError:** In this version the `ValidationError` is `sealed`. So you can not inheritance from it. Create your custom class from `ErrorDetail`.
* **ErrorDetail:** `ExceptionData` class has removed and replaced with `Exception` class
* **Result:** In the previous version, the value was added only when it was not null, but in this version, if the result is successful, it will be added anyway.
* **ResultBase:** Result objects are more immutable.
* **ErrorDetail:** Use `ValidationError` instead of `ArgumentError`
* **ResultDetail:** Instead of checking if `MoreDetails` is null, check the number of elements in the list.
* Increase minimum dotnet version to 6
* rename `IsSuccess` to `Success`. fix #23
* rename `OnRail` to `OnRails`
* add `ToString()` to `Result` and `ResultDetails`

### Features

* **AcceptedAtActionDetail:** add more constructor ([475c7c1](https://github.com/Payadel/OnRails/commit/475c7c1bbc9dad74d264daea309484ebbbc87ce1))
* **AcceptedDetail:** break it to multi classes ([b6d56d6](https://github.com/Payadel/OnRails/commit/b6d56d6b87cf6c778592e67e21529773c38e62d9))
* **ActionResult:** add extensions ([fe8c152](https://github.com/Payadel/OnRails/commit/fe8c152b278d34f574b6cdbca8baed9a77a82147))
* **ActionResult:** use asp action results for `CreatedDetail` and `AcceptedDetail` ([aa0bf2c](https://github.com/Payadel/OnRails/commit/aa0bf2cb15ceccb971f112bc339dbb4e2eeaa59f))
* add `NoContentDetail` ([fed6fc0](https://github.com/Payadel/OnRails/commit/fed6fc0f89648d3684153a67bb374ad1cffdfbce))
* add `ResetContentDetail` ([4ea15d3](https://github.com/Payadel/OnRails/commit/4ea15d38863d219e4fa61318502afe75c237f63f))
* add `ToString()` to `Result` and `ResultDetails` ([8bf83db](https://github.com/Payadel/OnRails/commit/8bf83db980ff123771f1ae05211b8256304facf9))
* add `ToString()` to `Result` and `ResultDetails` ([ce6850e](https://github.com/Payadel/OnRails/commit/ce6850ea05fbe5cfea7feebeeb128549c487851a))
* add RemoveDetail ([42dd061](https://github.com/Payadel/OnRails/commit/42dd06134d814858d3d04a4a32a354b99f1cbc07))
* add RequestTrackingMiddleware.cs ([21c57a9](https://github.com/Payadel/OnRails/commit/21c57a938ad13c7852267d890eabc61e6790170d))
* **ConflictError:** add objectIdentity filed ([c04a5e8](https://github.com/Payadel/OnRails/commit/c04a5e88e472c3791ae2fb8d4c4e996bb5279a68))
* **CreatedAtActionDetail:** add more constructor ([ba2ca91](https://github.com/Payadel/OnRails/commit/ba2ca9123e5da3452fcd9189cf64fe232dff3363))
* **CreatedDetail:** break it to multi classes ([97be240](https://github.com/Payadel/OnRails/commit/97be240a8fa15104ef96ecc247a740ec91fa268e))
* **Detail:** update WarningDetail.cs ([6397fdc](https://github.com/Payadel/OnRails/commit/6397fdcf879a1cf760f2f3167d6f1f4de547b78d))
* **ErrorDetail:** add `HasErrorTypeOf` method ([a63eaf2](https://github.com/Payadel/OnRails/commit/a63eaf226547e8ba50a62e56db8085e615531f8f))
* **ErrorDetail:** add key-value error list to `ErrorDetail` ([3ea85a6](https://github.com/Payadel/OnRails/commit/3ea85a6b3784df16ab1e0c3a5f024d2320e3f0f1))
* **GetValuesExtensions:** add `GetValuesExtensions` class ([aae4e79](https://github.com/Payadel/OnRails/commit/aae4e790b19f64b7448c1cb8b9347b7bcceaa5ae))
* **InternalError:** add status code to constructor parameters ([38f2a38](https://github.com/Payadel/OnRails/commit/38f2a383931a22f3a9c6805adea478a467ae6852))
* make some fields more accessible for inherent classes ([134b6e5](https://github.com/Payadel/OnRails/commit/134b6e5a51f47108abe431284a952fada1fec4ce))
* **NotFoundError:** use `List&lt;KeyValue<object?&gt;>` for save object keys ([ac1f3ba](https://github.com/Payadel/OnRails/commit/ac1f3ba311d57a832847a99606050af46ab27f1c))
* **OnFailExtensions:** add `OnFailOperateWhen` extensions with `Type` condition ([e35c437](https://github.com/Payadel/OnRails/commit/e35c437116edb5279557134200588801c98347ef))
* **OnFailExtensions:** add conditions base ErrorDetail or Exception type ([bef8d69](https://github.com/Payadel/OnRails/commit/bef8d698fb8bc80a0f95d083cee2cd4d4f1e9968))
* **OnFailThrowException:** support async ([d2ff11c](https://github.com/Payadel/OnRails/commit/d2ff11cd73ef405bddc37adc4088fb087c026a75))
* **OnSuccess:** add `OnSuccessAddMoreDetails` ([b9bfa04](https://github.com/Payadel/OnRails/commit/b9bfa04cdf5adb60f618cac9976e8d3b6701ba4c))
* **OnSuccess:** add overloads ([f182965](https://github.com/Payadel/OnRails/commit/f1829658ac922c906bb7b0e1604d8d78239a1a10))
* **OnSuccessExtensions:** add more extensions ([fb24057](https://github.com/Payadel/OnRails/commit/fb24057643f5adb95ef2e123aef42dc28bea2164))
* **OnSuccessExtensions:** add more extensions ([92884e5](https://github.com/Payadel/OnRails/commit/92884e599ae296ede82099a20685c714a14d1d0e))
* **OperateWhenExtensions:** add `OperateWhen` extensions with `Type` condition ([0e9381f](https://github.com/Payadel/OnRails/commit/0e9381f26e58f3d553384a244b07742f981f1b08))
* **PartialContentDetail:** add `RangeData` class as custom data ([04af280](https://github.com/Payadel/OnRails/commit/04af2801dd4c7df1fc1798e07f47b6438d33aaa5))
* **Result:** add `GetViewValue` and `GetViewStatusCode` methods ([f33684e](https://github.com/Payadel/OnRails/commit/f33684e8006b8a37df150e554064387cdaf00fa7))
* **ResultBase:** add `IsDetailTypeOf` method ([e45a084](https://github.com/Payadel/OnRails/commit/e45a084ecb813b21b1123af154e116a8f5d9dc5f))
* **ResultDetail:** add `IsTypeOf` method ([33181f3](https://github.com/Payadel/OnRails/commit/33181f37b985320520a8dba9730823c9423ab7cd))
* **ResultDetail:** add `View` prop to determine the detail is suitable for view/user or not ([993ad8f](https://github.com/Payadel/OnRails/commit/993ad8ff6a85a0d8f72157085ebd791e186b4b54))
* **ResultDetail:** add CollectionErrorDetail.cs ([5f5c253](https://github.com/Payadel/OnRails/commit/5f5c253eb103f126b2a3a8538bd2b2bf7fc8572b))
* **TeeUsing:** add more methods ([fa5a8e9](https://github.com/Payadel/OnRails/commit/fa5a8e9366f9b1d39f7015eb83345de20f3ff7dc))
* **TeeUsing:** add overloads ([604da26](https://github.com/Payadel/OnRails/commit/604da2688f12687afe51c6bc6b61a66320086085))
* **Try:** add TryOnExceptions for func params that return `Result` (without value) ([f8e3481](https://github.com/Payadel/OnRails/commit/f8e34816822cec0c1bcf8a294b095f0af334a3fa)), closes [#22](https://github.com/Payadel/OnRails/issues/22)
* **Using:** add more methods for async types ([19a6dc5](https://github.com/Payadel/OnRails/commit/19a6dc5615ce8caf0443cf3b4a4c39f60cca8ba5))
* **Using:** add overloads ([2487fe4](https://github.com/Payadel/OnRails/commit/2487fe4c4af083149c9bcbc2ecba0981a33cfd23))
* **utility:** add ResultDetailExtensions.cs ([2454e5d](https://github.com/Payadel/OnRails/commit/2454e5d5eafeb04f23a5608a369c6d0075fa272f))
* **ValidationError:** add `List&lt;KeyValuePair<string, string&gt;> errors` to constructor ([7ccf110](https://github.com/Payadel/OnRails/commit/7ccf110dcaced0ad99d04582546afd9d3e5d4607))
* **WarningDetail:** add new custom `ResultDetail` ([101c25b](https://github.com/Payadel/OnRails/commit/101c25b37291bb83854dff9efdaba4f5b9e84992))


### Bug Fixes

* **AcceptedDetail:** big changes. add some props, update constructor, etc ([dc223b9](https://github.com/Payadel/OnRails/commit/dc223b95c41017a5aca8b8c995ae4bf526862f2d))
* **ActionResult:** improve `ReturnAcceptedAtAction` methods ([2671c95](https://github.com/Payadel/OnRails/commit/2671c9534fb0424e7db63c1aba7185e4a4b8fd89))
* **ActionResult:** improve `ReturnCreatedAtLocation` methods ([784bc24](https://github.com/Payadel/OnRails/commit/784bc2422faa50f592f2fc4571cd819fe9e7aff2))
* **ActionResultObject:** fix using of `GetStatusCodeOrDefault` ([0312bf5](https://github.com/Payadel/OnRails/commit/0312bf5f14a4867530031d1332f3ab0112c0ff37))
* **ActionResult:** rename `ActionResultObject` to `ActionResultView` ([a6892de](https://github.com/Payadel/OnRails/commit/a6892ded240d2dadf067e773605bc524dbc568a7))
* **ActionResultView:** returns 204 code for null value ([bc08f7e](https://github.com/Payadel/OnRails/commit/bc08f7e021157c8d0b2708c1048dcfdba796c009))
* add `[DebuggerStepThrough]` to KeyValue.cs ([ba4b050](https://github.com/Payadel/OnRails/commit/ba4b050797e9943e0a3c12ecbff00fbb9e428815))
* add `Obsolete` attribute for non useful methods ([e4d71a2](https://github.com/Payadel/OnRails/commit/e4d71a240a2c95c3654cc4f61b4fa51de4afcc42))
* **BadRequestError:** use `Dictionary&lt;string, List<string&gt;> Errors` as custom field ([afbaad1](https://github.com/Payadel/OnRails/commit/afbaad135565250b175940ca3b08714850a5a8a2))
* **BadRequestError:** use `KeyValue&lt;object?&gt;` to save errors ([f45a974](https://github.com/Payadel/OnRails/commit/f45a974128266743aae119588730f55e12c56ff5))
* Break `Result&lt;T&gt;` constructor ([96218f3](https://github.com/Payadel/OnRails/commit/96218f392603916af12716385e4db502dc832b97))
* change dotnet version from 3.1 to 6 ([cb80623](https://github.com/Payadel/OnRails/commit/cb80623efb75917dae634e24f30be243dda2744b))
* classify and minor updates ([9a92a40](https://github.com/Payadel/OnRails/commit/9a92a404f4848bb2278c62cc5b7cec9a3000120b))
* **CollectionErrorDetail:** start `i` in `ToString()` from 1 ([6ce221f](https://github.com/Payadel/OnRails/commit/6ce221f07e44bac528fe51ea1164979587c5ff90))
* **ConfigurationExtensions:** change output of `GetConfig` to nullable ([73b90e3](https://github.com/Payadel/OnRails/commit/73b90e34bb409c2abfa01e8dac58cdb65025c668))
* **ConflictError:** add `GetViewModel` ([66bb7d2](https://github.com/Payadel/OnRails/commit/66bb7d20ed9b4d6ce09a8f7f2088db55d66bc5e3))
* **ConflictError:** from now on, it will be a subclass of `BadRequestError` ([e7704d1](https://github.com/Payadel/OnRails/commit/e7704d1bd3e3814f7dfe06486bbb9d913bcb0a38))
* **ConflictError:** make `errors` optional. ([e51d89c](https://github.com/Payadel/OnRails/commit/e51d89c2fb5a039533b038787823592af6baa872))
* **CreatedDetail:** big changes. add some props, update constructor, etc ([8a64c92](https://github.com/Payadel/OnRails/commit/8a64c9281c34abd25aca84bec25c9a5e7c02d4c9))
* **Debugger:** Use `[DebuggerStepThrough]` ([5d5b207](https://github.com/Payadel/OnRails/commit/5d5b2073bce3c696b04acf78f7536c6b4dc7b7a3)), closes [#32](https://github.com/Payadel/OnRails/issues/32)
* **Debugger:** Use `[DebuggerStepThrough]` for `ResultBase` ([50c6386](https://github.com/Payadel/OnRails/commit/50c638638633a8bd36d47aa09e8e5db2b90efde3)), closes [#32](https://github.com/Payadel/OnRails/issues/32)
* **Detail:** change default message of CreatedDetail.cs and AcceptedDetail.cs ([0b5ffbf](https://github.com/Payadel/OnRails/commit/0b5ffbf500661f5f5c63a4bc9d47582eae441a31))
* **ErrorDetail:** add `GetViewModel` ([5df8171](https://github.com/Payadel/OnRails/commit/5df817152208fd5adcb9b5a0e01432b1fd66a332))
* **ErrorDetail:** improve `ToString()` ([3b44a76](https://github.com/Payadel/OnRails/commit/3b44a76bb20650971b04aa2171554f52daab117e))
* **ErrorDetail:** Remove `ArgumentError` ([33221af](https://github.com/Payadel/OnRails/commit/33221af02115d55f78786d7b1641a12e9a15eadf))
* **ErrorDetail:** remove `ErrorDetail&lt;T&gt;` ([9b279fa](https://github.com/Payadel/OnRails/commit/9b279faa146474f4d32509ff9ddc379a261cb165))
* **ErrorDetail:** remove exception field ([0677972](https://github.com/Payadel/OnRails/commit/06779720ba387ab40cbcf7bb740e8d4547b065e3))
* **ErrorDetail:** Use `Exception` instead of `ExceptionData` ([9fa9cd5](https://github.com/Payadel/OnRails/commit/9fa9cd5545508ff083839cd0fa37cf02091bce89))
* **ExceptionError:** update default message ([caac994](https://github.com/Payadel/OnRails/commit/caac994b61abda0861ebc87ef79bd4e33ea46899))
* **KeyValue:** move it to `Models` folder ([f718589](https://github.com/Payadel/OnRails/commit/f718589fc3e4a2fb161031356f2b24c2174edb00))
* **KeyValue:** use generic for KeyValue.cs ([0ea122e](https://github.com/Payadel/OnRails/commit/0ea122e3c85470a6d77e9a1751b8c9bea25cce5f))
* **MustExtensions:** remove `MustNotNullOrEmpty` as `Obsolete` ([4bae77b](https://github.com/Payadel/OnRails/commit/4bae77bea23e73d515a1776cd756300f920908ef))
* **NotFoundError:** chane type `T` from `string` to `object`. ([93b73f9](https://github.com/Payadel/OnRails/commit/93b73f92a3f79b598410c410be2db43ece53d3d7))
* **NotFoundError:** use `HashSet&lt;string&gt;` to store `Keys` ([95715ac](https://github.com/Payadel/OnRails/commit/95715acb7d07abdecbc5ea7ed30fab6eb00c8f1d))
* **NotFoundError:** use sing id instead of error list for saving items. Also make it optional. ([a77c30e](https://github.com/Payadel/OnRails/commit/a77c30e63efad24ad40307a4c6e42d26b303cc43))
* **NotImplementError:** from now on, it will be a subclass of `InternalError` ([9fe5e89](https://github.com/Payadel/OnRails/commit/9fe5e89246f1edfcb736d4fa150f30496553d3c5))
* **ObjectExtensions:** remove `IsNullOrEmpty` as `Obsolete` ([6dc3f23](https://github.com/Payadel/OnRails/commit/6dc3f232d0b8720edd564e96d3ecf152f358751f))
* refactor CollectionErrorDetail.cs to ErrorDetailList.cs ([903ee5a](https://github.com/Payadel/OnRails/commit/903ee5a35a75d6b32831c3ca5caed6f94e4528d9))
* remove excess `await` from TeeExtensions.Async.cs ([9251a7e](https://github.com/Payadel/OnRails/commit/9251a7ec1aa5c1dc889e431ae86ca016e74884fe))
* rename `IsSuccess` to `Success`. fix [#23](https://github.com/Payadel/OnRails/issues/23) ([fc90402](https://github.com/Payadel/OnRails/commit/fc9040278f6e84413b95991687bbe3eac5db99cf))
* rename `OnRail` to `OnRails` ([25e42e6](https://github.com/Payadel/OnRails/commit/25e42e66fb9a5038265130936ede2c93f492a4f6))
* **ResultBase:** Remove `set` access from `Success` prop ([1c1247d](https://github.com/Payadel/OnRails/commit/1c1247d0498cfa86036a65573a2bbe8414be38e7))
* **ResultBase:** remove default value for `GetStatusCodeOrDefault` parameters ([31d34f4](https://github.com/Payadel/OnRails/commit/31d34f4aad35a70117802e71f99a15a89a782509))
* **ResultDetail:** big changes ([764fa62](https://github.com/Payadel/OnRails/commit/764fa62c00271dc811470d964b554756702d7322))
* **ResultDetail:** change output of `AddDetail` method to `void` ([543538d](https://github.com/Payadel/OnRails/commit/543538d5eda26fc6685a4d2810b8a9848dab00ee))
* **ResultDetail:** change setter fields to `protected init` ([c1aa93c](https://github.com/Payadel/OnRails/commit/c1aa93c64452225787f873fa09052a32bd43a73e))
* **ResultDetail:** improve `ToString()` ([08845d2](https://github.com/Payadel/OnRails/commit/08845d248e3d7a357cc0596bf48c1e05f2013f79))
* **ResultDetail:** make setter for properties `public` ([3d0113f](https://github.com/Payadel/OnRails/commit/3d0113f0d38ceb1dd171a9969883e4baebee1191))
* **ResultDetail:** minor update in constructor logic ([9e2dafe](https://github.com/Payadel/OnRails/commit/9e2dafe050349c34732e5cb4eee16ea6b173a226))
* **ResultDetail:** Remove nullable from `MoreDetails` ([6404a21](https://github.com/Payadel/OnRails/commit/6404a21419b491debed04dac9ffe3b809502c1f3)), closes [#34](https://github.com/Payadel/OnRails/issues/34)
* **ResultDetail:** use `Dictionary` instead of `object` in `GetViewModel` ([5505db8](https://github.com/Payadel/OnRails/commit/5505db882f010db8c0ba5fdc2eb08386024b5840))
* **Result:** handling possible error in the execution of the `errorDetailFunc` in `OnRails.Result&lt;T&gt;.Fail` ([3c9bfb5](https://github.com/Payadel/OnRails/commit/3c9bfb54f17e056c76748b69e800e19edeb50d60))
* **Result:** whether the `Value` is null or not, it will be added to `ToString`. ([bf93d4f](https://github.com/Payadel/OnRails/commit/bf93d4f8e54bbfd6f746a67e3932874c41d29f41))
* set view for success details to `true` ([cf86a81](https://github.com/Payadel/OnRails/commit/cf86a816d915ba84f2fccb033dd8b11311dccefd))
* **stacktrace:** get library namespace dynamically ([a57ba39](https://github.com/Payadel/OnRails/commit/a57ba395ca4da7a974965b2e55c91be0c9274f5b))
* **StackTrace:** remove frames related to `OnRails` ([2e7eaad](https://github.com/Payadel/OnRails/commit/2e7eaad5f5ff9a4900c1992a00d9eab1e12feffe))
* **Try:** add `this` key to source parameters ([fad8c02](https://github.com/Payadel/OnRails/commit/fad8c02613a029deae6ae7941fddf0d8557a6fb4))
* **Try:** update error detail ([9162e21](https://github.com/Payadel/OnRails/commit/9162e212b9f413ddf4b741f770a907aa65729f5a))
* **Try:** use `CollectionErrorDetail` for save errors ([0932cbe](https://github.com/Payadel/OnRails/commit/0932cbe926b2bb82e90d393089ddcd6bee329cd6))
* update dotnet sdk version to 8.0 ([4fe06f3](https://github.com/Payadel/OnRails/commit/4fe06f320f0edd794cd5aafb4b6bab9bfd70e8ad))
* update ResultDetail.cs ([b01e3dd](https://github.com/Payadel/OnRails/commit/b01e3dd95ee71b31ed2ae3e9bc5c1f66e081b213))
* use `Microsoft.AspNetCore.App` instead of deprecated packages ([a577b25](https://github.com/Payadel/OnRails/commit/a577b25d3493d27539f90205c10acd81d2f60eaf))
* use `object` type as `Errors` and improve `ToString()` ([bffbb0b](https://github.com/Payadel/OnRails/commit/bffbb0b4b219683674e5400709594ada3927a04b))
* Use new features of C# ([1dc8e26](https://github.com/Payadel/OnRails/commit/1dc8e2656b4fed1135fe459aa7e6af91ce518bda)), closes [#30](https://github.com/Payadel/OnRails/issues/30)
* **Using:** add await for async methods and refactor ([107c4ad](https://github.com/Payadel/OnRails/commit/107c4ad275763e7285eae8aaaab67064a18abf7e))
* **Using:** rename `T` to `TSource` ([a3a51f7](https://github.com/Payadel/OnRails/commit/a3a51f76689314a0ca3389423d324312c1553b62))
* **ValidationError:** improve it to suitable for view ([0ca6bcf](https://github.com/Payadel/OnRails/commit/0ca6bcfa6eef2b6881d201bdebb828670ac016f7))
* **ValidationError:** make class `sealed` ([596ca49](https://github.com/Payadel/OnRails/commit/596ca49ef71fae2e6bbc7432d8917afe16ec0a59))
* **ValidationError:** match with `BadRequestError` class ([7aaf460](https://github.com/Payadel/OnRails/commit/7aaf46010bb1a59667aa717aea56d38d187df867))
* **ValidationError:** remove excess empty line for errors in `ErrorsToString` method ([876a42b](https://github.com/Payadel/OnRails/commit/876a42b0a0fc83aa4c3938bbcd6183a0252e8646))
* **ValidationError:** use custom `Errors` field with key-value structure ([bca0d1c](https://github.com/Payadel/OnRails/commit/bca0d1cfd4e5beaa6ff58062d1e803471f3a3090))
* **ValidationError:** use custom `KeyValue` record for errors. ([67731bd](https://github.com/Payadel/OnRails/commit/67731bdb54a59fc37a8d66896d3025a500da65f3))
* **WarningDetail:** remove custom field ([a5d7f2c](https://github.com/Payadel/OnRails/commit/a5d7f2c5c4d49af365a8f7d7bfa1fd43b20d3891))

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
