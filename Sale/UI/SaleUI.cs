namespace PerfumeSystem;

public class SaleUI
{
    private SaleDL saleDL;

    public SaleUI(SaleDL saleDL)
    {
        this.saleDL = saleDL;
    }

    public static void PrintReceipt(string customer, string perfume, int qty, int bill)
    {
        Console.WriteLine("\n------ RECEIPT ------");
        Console.WriteLine("Customer : " + customer);
        Console.WriteLine("Perfume  : " + perfume);
        Console.WriteLine("Quantity : " + qty);
        Console.WriteLine("Total    : " + bill);
        Console.WriteLine("---------------------");
    }

    public void BuyPerfume(PerfumeDL perfumeDL, CustomerDL customerDL)
    {
        Console.Clear();

        string customerName = PerfumeUI.ReadText("Enter Your Name: ");
        string phone = CustomerUI.ReadPhone("Enter Your Phone: ");

        Customer c = customerDL.FindByPhone(phone);
        if (c == null)
        {
            c = new Customer(0, customerName, phone);
            customerDL.AddCustomer(c);
        }

        string perfumeName = PerfumeUI.ReadText("Enter Perfume Name: ");
        Perfume p = perfumeDL.FindByName(perfumeName);

        if (p == null)
        {
            Console.WriteLine("Perfume Not Found!");
            PerfumeUI.Pause();
            return;
        }

        int qty = PerfumeUI.ReadInt("Enter Quantity: ");

        if (!PerfumeBL.HasStock(p, qty))
        {
            Console.WriteLine("Not enough stock!");
            PerfumeUI.Pause();
            return;
        }

        int bill = PerfumeBL.GetBill(p, qty);

        perfumeDL.UpdateQuantity(p.Name, p.Quantity - qty);

        Sale s = new Sale(0, c.Name, p.Name, qty, bill);
        saleDL.AddSale(s);

        PrintReceipt(c.Name, p.Name, qty, bill);
        PerfumeUI.Pause();
    }

    public void ViewSales()
    {
        Console.Clear();
        Console.WriteLine("ID\tCustomer\tPerfume\t\tQty\tBill");

        foreach (Sale s in saleDL.GetAll())
        {
            Console.WriteLine(s.Id + "\t" + s.CustomerName + "\t\t" + s.PerfumeName + "\t" + s.Quantity + "\t" + s.Bill);
        }

        Console.WriteLine("\nTotal Income: " + SaleBL.GetTotalIncome(saleDL.GetAll()));
        PerfumeUI.Pause();
    }

    public void UpdateSale()
    {
        Console.Clear();
        int id = PerfumeUI.ReadInt("Enter Sale ID: ");
        string newName = PerfumeUI.ReadText("Enter new customer name: ");

        if (saleDL.UpdateCustomerName(id, newName))
            Console.WriteLine("Sale Updated!");
        else
            Console.WriteLine("Sale Not Found!");

        PerfumeUI.Pause();
    }

    public void DeleteSale()
    {
        Console.Clear();
        int id = PerfumeUI.ReadInt("Enter Sale ID to delete: ");

        if (saleDL.DeleteSale(id))
            Console.WriteLine("Sale Deleted!");
        else
            Console.WriteLine("Sale Not Found!");

        PerfumeUI.Pause();
    }
}
