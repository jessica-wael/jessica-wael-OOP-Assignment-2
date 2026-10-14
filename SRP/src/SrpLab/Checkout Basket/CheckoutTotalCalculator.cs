namespace SrpLab;

public sealed class CheckoutTotalCalculator
{
    public decimal Calculate(decimal subTotal, decimal discount, decimal giftWrapFee) =>
        Math.Max(0m, subTotal - discount + giftWrapFee);
}