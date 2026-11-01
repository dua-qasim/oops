namespace PerfumeSystem;

public class SaleBL
{
    public static int GetTotalIncome(List<Sale> sales)
    {
        int total = 0;
        for (int i = 0; i < sales.Count; i++)
        {
            total = total + sales[i].Bill;
        }
        return total;
    }
}
