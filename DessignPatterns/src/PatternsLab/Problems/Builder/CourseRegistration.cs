namespace PatternsLab.Problems.Builder;

public sealed class CourseRegistration
{
    public string StudentEmail { get; }
    public string CourseCode { get; }
    public string AccessMode { get; }
    public string? GroupCode { get; }
    public string? DiscountCode { get; }
    public bool SendWhatsApp { get; }
    public bool SendEmailWelcome { get; }
    public string? MentorNote { get; }
    public DateOnly? PreferredStart { get; }

    public CourseRegistration(
        string studentEmail,
        string courseCode,
        string accessMode,
        string? groupCode,
        string? discountCode,
        bool sendWhatsApp,
        bool sendEmailWelcome,
        string? mentorNote,
        DateOnly? preferredStart)
    {
        if (string.IsNullOrWhiteSpace(studentEmail)) throw new ArgumentException("email required");
        if (string.IsNullOrWhiteSpace(courseCode)) throw new ArgumentException("course required");

        if (accessMode == "LiveGroup" && string.IsNullOrWhiteSpace(groupCode))
            throw new InvalidOperationException("LiveGroup requires GroupCode");
        if (accessMode == "VideosOnly" && !string.IsNullOrWhiteSpace(groupCode))
            throw new InvalidOperationException("VideosOnly cannot have GroupCode");

        StudentEmail = studentEmail;
        CourseCode = courseCode;
        AccessMode = accessMode;
        GroupCode = groupCode;
        DiscountCode = discountCode;
        SendWhatsApp = sendWhatsApp;
        SendEmailWelcome = sendEmailWelcome;
        MentorNote = mentorNote;
        PreferredStart = preferredStart;
    }

    public override string ToString()
        => $"{StudentEmail} → {CourseCode} [{AccessMode}] group={GroupCode ?? "-"} discount={DiscountCode ?? "-"} wa={SendWhatsApp} mail={SendEmailWelcome}";
}
public class CourseRegistrationBuilder
{
    private string _studentEmail;
    private string _courseCode;
    private string _accessMode;
    private string? _groupCode;
    private string? _discountCode;
    private bool _sendWhatsApp;
    private bool _sendEmailWelcome;
    private string? _mentorNote;
    private DateOnly? _preferredStart;


    public CourseRegistrationBuilder SetGroupCode(string? groupCode)
    {
        _groupCode = groupCode;
        return this;
    }

    public CourseRegistrationBuilder SetDiscountCode(string? discountCode)
    {
        _discountCode = discountCode;
        return this;
    }

    public CourseRegistrationBuilder SendWhatsApp(bool value = true)
    {
        _sendWhatsApp = value;
        return this;
    }

    public CourseRegistrationBuilder SendEmailWelcome(bool value = true)
    {
        _sendEmailWelcome = value;
        return this;
    }

    public CourseRegistrationBuilder SetMentorNote(string? note)
    {
        _mentorNote = note;
        return this;
    }


    public CourseRegistrationBuilder SetPreferredStart(DateOnly? date)
    {
        _preferredStart = date;
        return this;

    }
    public CourseRegistrationBuilder(string email, string courseCode, string accessMode)
    {

        _studentEmail = email;
        _courseCode = courseCode;
        _accessMode = accessMode;
    }
    public CourseRegistration Build()
    {
        if (_accessMode == "LiveGroup" && string.IsNullOrWhiteSpace(_groupCode))
            throw new InvalidOperationException("LiveGroup requires GroupCode");
        if (_accessMode == "VideosOnly" && !string.IsNullOrWhiteSpace(_groupCode))
            throw new InvalidOperationException("VideosOnly cannot have GroupCode");

        return new CourseRegistration(
            _studentEmail,
            _courseCode,
            _accessMode,
            _groupCode,
            _discountCode,
            _sendWhatsApp,
            _sendEmailWelcome,
            _mentorNote,
            _preferredStart);
    }
}

    public static class RegistrationCallSites
{
    public static CourseRegistration CreateLiveStudentUgly()
    {
        return new CourseRegistrationBuilder("sara@mail.com", "SEF-101", "LiveGroup")
           .SetGroupCode("G1")
           .SetDiscountCode("EARLY10")
           .SendWhatsApp(true)
           .SendEmailWelcome(true)
           .SetMentorNote("Needs evening slot")
           .SetPreferredStart(new DateOnly(2026, 10, 1))
           .Build();
    }

    public static CourseRegistration CreateVideosOnlyUgly()
    {
        return new CourseRegistrationBuilder("ali@mail.com", "SEF-101", "VideosOnly")
     
            .SendEmailWelcome(true)
            .Build();
            
    }
}

       