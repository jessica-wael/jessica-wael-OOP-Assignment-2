namespace SrpLab;

public sealed class TuitionInvoiceLineWriter
{
    private readonly VatPolicy _vat;

    public TuitionInvoiceLineWriter(VatPolicy vat)
    {
        _vat = vat;
    }

    public string Write(string courseCode, decimal tuition, bool isSeated)
    {
        if (!isSeated) return $"{courseCode},WAITLIST,0.00";
        var vat = _vat.VatFor(tuition);
        return $"{courseCode},TUITION,{tuition:0.00},VAT,{vat:0.00},TOTAL,{(tuition + vat):0.00}";
    }
}