using System;

public class WeeklyEntry : IComparable<WeeklyEntry>
{
    public WeeklyEntry(string weekday, string note)
    {
        this.Weekday = (WeekDay)Enum.Parse(typeof(WeekDay), weekday);
        this.Note = note;
    }

    public WeekDay Weekday { get; private set; }

    public string Note { get; private set; }

    public override string ToString()
    {
        return $"{this.Weekday} - {this.Note}";
    }

    public int CompareTo(WeeklyEntry other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }

        if (ReferenceEquals(null, other))
        {
            return 1;
        }

        var weekdayComparison = this.Weekday.CompareTo(other.Weekday);
        if (weekdayComparison != 0)
        {
            return weekdayComparison;
        }

        return string.Compare(this.Note, other.Note, StringComparison.Ordinal);
    }
}
