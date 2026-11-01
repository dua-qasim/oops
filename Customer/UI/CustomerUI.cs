namespace PerfumeSystem;

public class CustomerUI
{
    private CustomerDL dl;

    public CustomerUI(CustomerDL dl)
    {
        this.dl = dl;
    }

    public static string ReadPhone(string message)
    {
        Console.Write(message);
        string phone = Console.ReadLine();

        while (!CustomerBL.IsValidPhone(phone))
        {
            Console.Write("Phone must be 11 digits! " + message);
            phone = Console.ReadLine();
        }

        return phone;
    }

    public void AddCustomer()
    {
        Console.Clear();
        string name = PerfumeUI.ReadText("Enter Name: ");
        string phone = ReadPhone("Enter Phone: ");

        if (dl.FindByPhone(phone) != null)
        {
            Console.WriteLine("This phone is already registered!");
        }
        else
        {
            dl.AddCustomer(new Customer(0, name, phone));
            Console.WriteLine("Customer Added!");
        }
        PerfumeUI.Pause();
    }

    public void ViewCustomers()
    {
        Console.Clear();
        Console.WriteLine("ID\tName\t\tPhone");

        foreach (Customer c in dl.GetAll())
        {
            Console.WriteLine(c.Id + "\t" + c.Name + "\t\t" + c.Phone);
        }
        PerfumeUI.Pause();
    }

    public void SearchCustomer()
    {
        Console.Clear();
        string phone = ReadPhone("Enter phone: ");
        Customer c = dl.FindByPhone(phone);

        if (c != null)
            Console.WriteLine("Found: " + c.Name + "  Phone: " + c.Phone);
        else
            Console.WriteLine("Customer Not Found!");

        PerfumeUI.Pause();
    }

    public void UpdatePhone()
    {
        Console.Clear();
        string oldPhone = ReadPhone("Enter old phone: ");
        string newPhone = ReadPhone("Enter new phone: ");

        if (dl.UpdatePhone(oldPhone, newPhone))
            Console.WriteLine("Phone Updated!");
        else
            Console.WriteLine("Customer Not Found!");

        PerfumeUI.Pause();
    }

    public void DeleteCustomer()
    {
        Console.Clear();
        string phone = ReadPhone("Enter phone to delete: ");

        if (dl.DeleteCustomer(phone))
            Console.WriteLine("Customer Deleted!");
        else
            Console.WriteLine("Customer Not Found!");

        PerfumeUI.Pause();
    }

    public void SortCustomers()
    {
        Console.Clear();
        dl.SortByName();
        Console.WriteLine("Customers Sorted!");
        PerfumeUI.Pause();
    }
}
