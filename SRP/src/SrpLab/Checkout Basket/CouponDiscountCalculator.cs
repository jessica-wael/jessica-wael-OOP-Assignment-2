namespace SrpLab;

public sealed class CouponDiscountCalculator
{
    public decimal Calculate(string? couponText, decimal subTotal)
    {
        if (string.IsNullOrWhiteSpace(couponText)) return 0m;
        var t = couponText.Trim().ToUpperInvariant();
        if (t.StartsWith("SAVE") && int.TryParse(t[4..], out var pct) && pct is > 0 and <= 50)
            return Math.Round(subTotal * pct / 100m, 2);
        if (t.Contains("FREESHIP")) return 0m;
        if (t == "WELCOME10") return Math.Min(10m, subTotal);
        return 0m;
    }
}