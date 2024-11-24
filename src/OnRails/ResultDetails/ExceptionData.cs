using System.Collections;

namespace OnRails.ResultDetails;

public sealed class ExceptionData {
    public ExceptionData(Exception exception) {
        StackTrace = exception.StackTrace;
        Source = exception.Source;
        Message = exception.Message;
        InnerException = exception.InnerException?.ToString();
        HResult = exception.HResult;
        Data = exception.Data;
        HelpLink = exception.HelpLink;
    }

    // Summary:
    //     Gets a string representation of the immediate frames on the call stack.
    //
    // Returns:
    //     A string that describes the immediate frames of the call stack.
    public string? StackTrace { get; }

    //
    // Summary:
    //     Gets or sets the name of the application or the object that causes the error.
    //
    // Returns:
    //     The name of the application or the object that causes the error.
    //
    // Exceptions:
    //   T:System.ArgumentException:
    //     The object must be a runtime System.Reflection object.
    public string? Source { get; }

    //
    // Summary:
    //     Gets a message that describes the current exception.
    //
    // Returns:
    //     The error message that explains the reason for the exception, or an empty string
    //     ("").
    public string Message { get; }

    //
    // Summary:
    //     Gets the System.Exception instance that caused the current exception.
    //
    // Returns:
    //     An object that describes the error that caused the current exception. The System.Exception.InnerException
    //     property returns the same value as was passed into the System.Exception.#ctor(System.String,System.Exception)
    //     constructor, or null if the inner exception value was not supplied to the constructor.
    //     This property is read-only.
    public string? InnerException { get; }

    //
    // Summary:
    //     Gets or sets HRESULT, a coded numerical value that is assigned to a specific
    //     exception.
    //
    // Returns:
    //     The HRESULT value.
    public int HResult { get; }

    //
    // Summary:
    //     Gets a collection of key/value pairs that provide additional user-defined information
    //     about the exception.
    //
    // Returns:
    //     An object that implements the System.Collections.IDictionary interface and contains
    //     a collection of user-defined key/value pairs. The default is an empty collection.
    public IDictionary Data { get; }

    //
    // Summary:
    //     Gets or sets a link to the help file associated with this exception.
    //
    // Returns:
    //     The Uniform Resource Name (URN) or Uniform Resource Locator (URL).
    public string? HelpLink { get; }
}