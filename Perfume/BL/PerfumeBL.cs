namespace PerfumeSystem;

public class PerfumeBL
{
    public static bool HasStock(Perfume p, int qty)
    {
        return p.Quantity >= qty;
    }

    public static int GetBill(Perfume p, int qty)
    {
        return p.Price * qty;
    }
}
