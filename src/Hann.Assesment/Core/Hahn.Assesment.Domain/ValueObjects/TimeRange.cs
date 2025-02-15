namespace Hahn.Assesment.Domain.ValueObjects;

public class TimeRange
{
    public long Start { get; }
    public long End { get; }

    public TimeRange(long start, long end)
    {
        if (start >= end)
            throw new ArgumentException("Start time must be less than end time");

        Start = start;
        End = end;
    }

    public override bool Equals(object? obj)
    {
        if (obj is TimeRange other)
        {
            return Start == other.Start && End == other.End;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Start, End);
    }

    public override string ToString()
    {
        return $"Start: {Start}, End: {End}";
    }
}

