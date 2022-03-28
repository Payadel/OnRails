# OnRail library

Simple and powerful **Railway Oriented** library for C#.

## Simple Sample

```C#
using FunctionalUtility.Extensions;

TryExtensions.Try(() => {
        Console.Write("Enter a number: ");
        var input = Console.ReadLine();
        return Convert.ToInt32(input);
    })
    .OnSuccess(number => Console.WriteLine($"Number is valid: {number}"))
    .OnFail(result => {
        Console.WriteLine("Result:");
        Console.WriteLine($"Is Success? {result.IsSuccess}"); //Is Success? False
        Console.WriteLine($"Error title: {result.Detail.Title}"); //Sample: Error title: ExceptionError
        Console.WriteLine($"Error message: {result.Detail.Message}"); //Sample: Error message: Input string was not in a correct format.
    });
```

## Document

The output of each method is a [MethodResult](https://github.com/hamidmolareza/FunctionalUtility/blob/master/FunctionalUtility/ResultUtility/MethodResult.cs) class.
The MethodResult class has two important fields.

1. **IsSuccess**: Determines whether the operation was successful or not.
2. **[Detail](https://github.com/hamidmolareza/FunctionalUtility/blob/master/FunctionalUtility/ResultUtility/ResultDetail.cs)**: It keeps more details of the result. Like title, message, etc.

There are two types of MethodResult:

1. **`MethodResult`**: Simple MethodResult that have no data.
2. **`MethodResult<T>`**: MethodResult that holds data of type **T**.

The MethodResult class has two important methods.

1. **Ok**: Indicates that the operation was **successful** and can include **data** and **detail**.

    - `MethodResult.Ok()`
    - `MethodResult<string>.Ok("Hello")`

    - `MethodResult.Ok(new ResultDetail(statusCode: 200, "Title", "Message"))`
    - `MethodResult<string>.Ok("Hello", new ResultDetail(statusCode: 200, "Title", "Message"))`

2. **Fail**: Indicates that the operation **failed** and contains **detail**.

    `MethodResult.Fail(new BadRequestError("title", "message"))`

## Sample

```C#
using FunctionalUtility.ResultUtility;

// This method returns "Hello" string.
private static MethodResult<string> GetHello() {
    return MethodResult<string>.Ok("Hello");
}

public static MethodResult PrintHello() =>
    GetHello()
        .OnSuccess(message => Console.WriteLine(message))
        .OnFail(result => Console.WriteLine($"Operation failed. {result.Detail.Title}-{result.Detail.Message}"));


public static MethodResult PrintHelloVerbose() {
    var messageResult = GetHello();

    if (!messageResult.IsSuccess) {
        //Operation was not successful. Print detail.
        var detail = messageResult.Detail;
        Console.WriteLine($"Operation failed. {detail.Title}-{detail.Message}");
        return MethodResult.Fail(detail);
    }

    //Operation was successful.
    Console.WriteLine(messageResult.Value); //Hello
    return MethodResult.Ok();
}
```

## Custom ResultDetail

For simplicity, you can customize the [ResultDetail](https://github.com/hamidmolareza/FunctionalUtility/blob/master/FunctionalUtility/ResultUtility/ResultDetail.cs):

```csharp
public class CustomDetail : ResultDetail {
    public CustomDetail(int statusCode = 1000, string title = "Custom Title",
        string? message = "Custom Message") : base(statusCode, title, message) { }
}

static void PrintCustomDetail() =>
    MethodResult.Fail(new CustomDetail())
        .OnFail(result => {
            var detail = result.Detail;
            Console.WriteLine(detail.StatusCode); //1000
            Console.WriteLine(detail.Title); //Custom Title
            Console.WriteLine(detail.Message); //Custom Message
        });
```

You can also customize the fields:
```csharp
public class CustomDetail : ResultDetail {
    public string CustomField { get; set; }

    public CustomDetail(string customField, int statusCode = 1000, string title = "Custom Title",
        string? message = "Custom Message") : base(statusCode, title, message) {
        CustomField = customField;
    }
}

static void PrintCustomDetail() =>
    MethodResult.Fail(new CustomDetail("Custom Field"))
        .OnFail(result => {
            if (result.Detail is CustomDetail customDetail) {
                Console.WriteLine(customDetail.CustomField); //Custom Field
            }

            var detail = result.Detail;
            Console.WriteLine(detail.StatusCode); //1000
            Console.WriteLine(detail.Title); //Custom Title
            Console.WriteLine(detail.Message); //Custom Message
        });
```

## Customize Error Details

It is better to inherit from the [ErrorDetail](https://github.com/hamidmolareza/FunctionalUtility/blob/master/FunctionalUtility/ResultDetails/Errors/ErrorDetail.cs) class to customize the **error details**. Because the ErrorDetail class includes fields like **StackTrace** and **exception data**.

ResultDetail is a **base class** for successful and unsuccessful operations. But the ErrorDetail class is designed for **failed operations**.

Usually, to increase the **security** of the program, the details of the errors (such as 500 errors in the server) are not displayed to users. With the [ShowDefaultMessageToUser](https://github.com/hamidmolareza/FunctionalUtility/blob/master/FunctionalUtility/ResultDetails/Errors/ErrorDetail.cs#L16) field in the ErrorDetail class you can specify whether the default message is displayed or not.

For example:

```csharp
static MethodResult Print(bool showDefaultMessage) =>
    MethodResult.Fail(new InternalError(message: "This is an important bug",
            showDefaultMessageToUser: showDefaultMessage))
        .OnFail(result => Console.WriteLine(result.Detail.GetViewModel()));

Print(false);
/*
 * Output:
 * { StatusCode = 500, Title = InternalError, Message = This is an important bug }
 */

Print(true);
/*
 * Output:
 * { StatusCode = 500, Title = Error!, Message = something went wrong. }
 */
```

## Add More Details

You can easily add the objects you need to the details.

```csharp
static MethodResult Print(string input) =>
    MethodResult.Fail(new BadRequestError())
        .OnFail(result => result.Detail.AddDetail(new {input}))
        .OnFail(result => {
            if (result.Detail.MoreDetails is null)
                return;
            foreach (var detail in result.Detail.MoreDetails) {
                Console.WriteLine(detail);
            }
        });

/*
 * Sample Output:
 * { input = Test }
 */
```

## Default ResultDetail

[Types of Result Details that exist:](https://github.com/hamidmolareza/FunctionalUtility/tree/master/FunctionalUtility/ResultDetails/Errors)

- BadRequestError.cs
- ConflictError.cs
- ErrorDetail.cs
- ExceptionData.cs
- ExceptionError.cs
- ForbiddenError.cs
- InternalError.cs
- NotFoundError.cs
- NotImplementedError.cs
- UnauthorizedError.cs
