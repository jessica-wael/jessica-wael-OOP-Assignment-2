namespace SrpLab;

public sealed class VatPolicy
{
    private const decimal Rate = 0.14m;

    public decimal VatFor(decimal amount) => Math.Round(amount * Rate, 2);
}