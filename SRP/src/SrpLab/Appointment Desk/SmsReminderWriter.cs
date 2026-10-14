namespace SrpLab;

public sealed class SmsReminderWriter
{
    public string Write(DateTimeOffset slot, string clinicPhone)
    {
        return $"Reminder: appointment {slot:MMM dd HH:mm}. Call {clinicPhone} to reschedule.";
    }
}