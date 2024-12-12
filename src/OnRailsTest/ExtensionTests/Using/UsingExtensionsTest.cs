namespace OnRailTest.ExtensionTests.Using;

public partial class UsingExtensionsTest {
    private class TestDisposable : IDisposable {
        public bool IsDisposed { get; private set; }
        public void Dispose() => IsDisposed = true;
    }

    private class TestError : Exception;
}