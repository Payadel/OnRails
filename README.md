<div align="center">
  <h1>OnRails</h1>
  <br />
  <a href="#getting-started"><strong>Getting Started »</strong></a>
  <br />
  <br />
  <a href="https://github.com/Payadel/OnRails/issues/new?assignees=&labels=bug&template=BUG_REPORT.md&title=bug%3A+">Report a Bug</a>
  ·
  <a href="https://github.com/Payadel/OnRails/issues/new?assignees=&labels=enhancement&template=FEATURE_REQUEST.md&title=feat%3A+">Request a Feature</a>
  .
  <a href="https://github.com/Payadel/OnRails/issues/new?assignees=&labels=question&template=SUPPORT_QUESTION.md&title=support%3A+">Ask a Question</a>
</div>

<div align="center">
<br />

![Build Status](https://github.com/Payadel/OnRails/actions/workflows/pull-request-check.yaml/badge.svg?branch=BRANCH)
![GitHub release (latest by date)](https://img.shields.io/github/v/release/Payadel/OnRails)
![NuGet Version](https://img.shields.io/nuget/v/OnRails)

![GitHub](https://img.shields.io/github/license/Payadel/OnRails)
[![Pull Requests welcome](https://img.shields.io/badge/PRs-welcome-ff69b4.svg?style=flat-square)](https://github.com/Payadel/OnRails/issues?q=is%3Aissue+is%3Aopen+label%3A%22help+wanted%22)

[![code with love by Payadel](https://img.shields.io/badge/%3C%2F%3E%20with%20%E2%99%A5%20by-Payadel-ff1414.svg?style=flat-square)](https://github.com/Payadel)

</div>

## About

OnRails is a **railway-oriented programming** library for C#. It simplifies handling complex workflows by utilizing the
principles of success and failure paths, making code easier to read, maintain, and extend.

---

### Railway Oriented

The Railway Oriented Programming (ROP) pattern separates the pure functional domain logic from the side effects, by
representing them as a **sequence of functions** that return an Either type, representing either a successful `Result`
or an error. This allows for better **composition** and **testing** of functions, as well as improving the code's **
maintainability** and **readability**.

It also facilitates the **handling of errors**, as the error handling logic is separated from the main logic, making it
easier to reason about and handle errors in a consistent and predictable manner. Overall, ROP can lead to more robust
and reliable software systems.

### Error Handling

In functional programming, it is not always appropriate to use traditional `try-except` blocks because they can lead to
code that is difficult to read, understand, and maintain.

`OnRails` supports functional error handling. The goal of this library is to make error handling **more explicit,
composable, and testable**. By using this library, developers can write code that is **more robust, maintainable, and
expressive**.

### What problems are solved?

Railway Oriented Programming (ROP) solves several common problems in software development, such as:

- **Handling errors:** By using an Either (`Result`) type, ROP makes it easy to represent and handle errors in a
  consistent and predictable manner, avoiding errors being thrown and allowing for error handling logic to be separated
  from the main logic.

- **Composition:** ROP separates the pure functional domain logic from the side effects, such as I/O, by representing
  them as a sequence of functions. This makes it easy to compose and chain functions together, enabling better code
  reuse and maintainability.

- **Readability:** The separation of pure functional domain logic from the side effects makes the code more readable and
  understandable, as it makes it clear what each function does and how they relate to each other.

- **Testing:** The pure functional domain logic can be easily tested, as it does not depend on any external state or
  side effects. This simplifies testing and ensures that the code is correct.

Overall, ROP provides a structured approach to software development that makes it easier to handle errors, compose
functions, and test code, leading to more robust and reliable software systems.

Developers can spend less time debugging and more time writing code that adds value to their organization. Additionally,
by using functional programming concepts, developers can write code that is easier to reason about and understand, which
can lead to faster development cycles and better quality code.

---

## Getting Started

### Prerequisites

- Dotnet 8+

### Installation

Use [nuget](https://www.nuget.org/packages/OnRails) to install the package.

```
dotnet add package OnRails
```

---

## Usage

### Sample 1

```csharp
using OnRails.Extensions.OnFail;
using OnRails.Extensions.OnSuccess;
using OnRails.Extensions.Try;

TryExtensions.Try(() => {
        Console.Write("Enter a number: ");
        var input = Console.ReadLine();
        return Convert.ToInt32(input);
    })
    .OnSuccess(number => Console.WriteLine($"Number is valid: {number}"))
    .OnFail(result => {
        Console.WriteLine($"Is Success? {result.Success}"); // False
        
        Console.WriteLine("Error Detail:");
        Console.WriteLine(result.Detail?.ToString() ?? "No Data!");

        return result;
    });
```

### Sample 2: Custom Error Detail

```csharp
using OnRails;
using OnRails.Extensions.OnFail;
using OnRails.Extensions.OnSuccess;
using OnRails.ResultDetails.Errors.BadRequest;

DivideNumber(5, 0)
    .OnSuccess(value => Console.WriteLine($"Result: {value}"))
    .OnFailOperateWhen(result => result.Detail is DivideByZeroError,
        result => {
            Console.WriteLine($"Oops! We can not divide by zero! \n{result.Detail}");
            return result;
        });

static Result<double> DivideNumber(int a, int b) =>
    b == 0
        ? Result<double>.Fail(new DivideByZeroError(nameof(b)))
        : Result<double>.Ok(a * 1.0 / b);

// Define Custom ErrorDetail
public class DivideByZeroError(
    string fieldName,
    string fieldMessage = "Cannot divide by zero",
    bool view = true) : ValidationError(fieldName, fieldMessage, view);

```

---

### Extensions

- **ActionResult**: Provides methods for working with ASP.NET Action Results, such as `ReturnAccepted`, `ReturnCreated`,
  and `ResetContent`.

- **Bind**: Methods for binding data efficiently, e.g., `BindExtensions`.

- **Configuration**: Extensions for configuration management, e.g., `ConfigurationExtensions`.

- **Fail**: Handles failure conditions with methods like `FailWhen`.

- **ForEach**: Iteration helpers for both synchronous and asynchronous loops.

- **Must**: Asserts conditions using `MustExtensions`.

- **Object**: General-purpose object manipulation methods.

- **OnFail / OnSuccess**: Handles failure and success conditions, including adding or removing details, operations, and
  chaining methods.

- **OperateWhen**: Facilitates conditional operations.

- **Tee / Using**: Implements functional programming patterns like `Tee` and resource management with `Using`.

### Result Details

- **Errors**:
    - Structured error types like `BadRequestError`, `ConflictError`, `ValidationError`, and `UnauthorizedError`.
    - Specialized internal errors (`ExceptionError`, `InternalError`, etc.).
- **Success**:
    - Success result types such as `AcceptedDetail`, `CreatedDetail`, `NoContentDetail`, and more.
- **Warnings**:
    - Supports warning details via `WarningDetail`.

---

## CHANGELOG

Please see the [CHANGELOG](CHANGELOG.md) file.


## Features

- **Rich Extensions**: Offers a wide range of extension methods grouped by functionality for streamlined workflows.

- **Error Handling**: Detailed error management with a structured hierarchy.

- **Customizable**: Extensible design allowing users to add their own custom result details and extensions.

- **Integration Support**: Built-in features for integrating with ASP.NET


## Contributing

First off, thanks for taking the time to contribute! Contributions are what make the free/open-source community such an
amazing place to learn, inspire, and create. Any contributions you make will benefit everybody else and are **greatly
appreciated**.

Please read [our contribution guidelines](docs/CONTRIBUTING.md), and thank you for being involved!


## Authors & contributors

The original setup of this repository is by [Payadel](https://github.com/Payadel).

For a full list of all authors and contributors,
see [the contributors page](https://github.com/Payadel/OnRails/contributors).


## Security

OnRails follows good practices of security, but 100% security cannot be assured. OnRails is provided **"as
is"** without any **warranty**.

_For more information and to report security issues, please refer to our [security documentation](docs/SECURITY.md)._


## License

This project is licensed under the **GPLv3**.

See [LICENSE](LICENSE) for more information.


## Related

Here are some related projects

[on_rails - Python](https://github.com/Payadel/on_rails)


