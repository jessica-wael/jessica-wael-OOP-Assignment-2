namespace SrpLab;

public sealed class AppointmentBook
{
    private readonly HashSet<DateTimeOffset> _booked = new();
    private readonly BusinessHours _hours;

    public AppointmentBook(BusinessHours hours)
    {
        _hours = hours;
    }

    public bool IsBooked(DateTimeOffset slot) => _booked.Contains(slot);

    public bool TryBook(DateTimeOffset slot)
    {
        if (!_hours.IsWithinBusinessHours(slot) || _booked.Contains(slot)) return false;
        _booked.Add(slot);
        return true;
    }
}