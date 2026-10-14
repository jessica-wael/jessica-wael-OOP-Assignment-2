namespace SrpLab;

public sealed class ShoppingBasket
{
    private readonly List<(string Sku, decimal Price, int Qty)> _lines = new();

    public string? CouponText { get; private set; }
    public bool GiftWrapRequested { get; private set; }

    public int LineCount => _lines.Count;
    public IEnumerable<string> Skus => _lines.Select(l => l.Sku);

    public void AddLine(string sku, decimal price, int qty)
    {
        if (qty <= 0) throw new ArgumentOutOfRangeException(nameof(qty));
        _lines.Add((sku, price, qty));
    }
    
    public void ApplyCouponText(string? couponText) => CouponText = couponText;
    public void EnableGiftWrap() => GiftWrapRequested = true;

    public decimal SubTotal() => _lines.Sum(l => l.Price * l.Qty);
}