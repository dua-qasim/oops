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
    public static int Getmaxtomin(List<Sale>sales)
    {
        int max = 0;
        int min = 0;
        int ans = 0;
        if (sales> max)
        {
            sales = max;
        }
        if (sales< min)
        {
            sales = min;
        }
        for (int i = 0; i < sales; i++)
        {
            ans = sales > max && sales < min;
        }
        return ans;

   }
}
