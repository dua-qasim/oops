namespace PerfumeSystem;

public class Sale
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string PerfumeName { get; set; }
    public int Quantity { get; set; }
    public int Bill { get; set; }

    public Sale()
    {
        Id = 0;
        CustomerName = "";
        PerfumeName = "";
        Quantity = 0;
        Bill = 0;
    }

    public Sale(int id, string customerName, string perfumeName, int quantity, int bill)
    {
        Id = id;
        CustomerName = customerName;
        PerfumeName = perfumeName;
        Quantity = quantity;
        Bill = bill;
    }

    public Sale(Sale other)
    {
        Id = other.Id;
        CustomerName = other.CustomerName;
        PerfumeName = other.PerfumeName;
        Quantity = other.Quantity;
        Bill = other.Bill;
    }
}
