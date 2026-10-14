namespace SrpLab;

public sealed class SlotFinder
{
    private readonly BusinessHours _hours;
    private readonly AppointmentBook _book;

    public SlotFinder(BusinessHours hours, AppointmentBook book)
    {
        _hours = hours;
        _book = book;
    }

    public DateTimeOffset? FindNextSlot(DateTimeOffset from, int searchHours)
    {
        var cursor = Align(from);
        var end = from.AddHours(searchHours);
        while (cursor < end)
        {
            if (_hours.IsWithinBusinessHours(cursor) && !_book.IsBooked(cursor))
                return cursor;
            cursor = cursor.AddMinutes(_hours.SlotMinutes);
        }
        return null;
    }

    private DateTimeOffset Align(DateTimeOffset from)
    {
        var minutes = from.Minute - (from.Minute % _hours.SlotMinutes);
        return new DateTimeOffset(from.Year, from.Month, from.Day, from.Hour, minutes, 0, from.Offset);
    }
}