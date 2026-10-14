namespace SrpLab;

public sealed class GiftWrapFeePolicy
{
    private const decimal Fee = 4.99m;

    public decimal FeeFor(bool giftWrapRequested) => giftWrapRequested ? Fee : 0m;
}
