namespace SrpLab;

public sealed class WelcomePacketWriter
{
    public string Write(string courseCode, string studentName, bool isSeated, int waitlistPosition)
    {
        var status = isSeated ? "confirmed seat" : $"waitlist {waitlistPosition}";
        return $" Welcome to {courseCode}\nHi {studentName},\nYour status: {status}.\n" +
               $"Bring a laptop. Discord onboarding link: https://example.invalid/{courseCode.ToLowerInvariant()}\n";
    }
}