namespace OnRails.Models;

public record RangeData {
    public long Start { get; }
    public long End { get; }
    public long Total { get; }

    public RangeData(long start, long end, long total) {
        if (start < 0 || end < 0 || total < 0) {
            throw new ArgumentException("Start, End, and Total must be non-negative.");
        }

        if (start > end) {
            throw new ArgumentException("Start cannot be greater than End.");
        }

        Start = start;
        End = end;
        Total = total;
    }

    public override string ToString() =>
        $"Range: {Start}-{End} of {Total} bytes";
}