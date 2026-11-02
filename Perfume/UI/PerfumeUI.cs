namespace PerfumeSystem;
public class PerfumeUI
{
    private PerfumeDL dl;
    public PerfumeUI(PerfumeDL dl)
    {
        this.dl = dl;
    }
    public static int ReadInt(string message)
    {
        int number;
        Console.Write(message);

        while (!int.TryParse(Console.ReadLine(), out number) || number < 0)
        {
            Console.Write("Wrong input! " + message);
        }
        return number;
    }
    public static string ReadText(string message)
    {
        Console.Write(message);
        string text = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(text))
        {
            Console.Write("Cannot be empty! " + message);
            text = Console.ReadLine();
        }

        return text;
    }

    public static void Pause()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    public void AddPerfume()
    {
        Console.Clear();
        string name = ReadText("Enter Perfume Name: ");
        int price = ReadInt("Enter Price: ");
        int qty = ReadInt("Enter Quantity: ");

        Perfume p = new Perfume(0, name, price, qty);
        dl.AddPerfume(p);

        Console.WriteLine("Perfume Added Successfully!");
        Pause();
    }

    public void ViewPerfumes()
    {
        Console.Clear();
        Console.WriteLine("ID\tName\t\t\tPrice\tQuantity");

        foreach (Perfume p in dl.GetAll())
        {
            Console.WriteLine(p.Id + "\t" + p.Name + "\t\t" + p.Price + "\t" + p.Quantity);
        }
        Pause();
    }

    public void SearchPerfume()
    {
        Console.Clear();
        string name = ReadText("Enter name:");
        Perfume p = dl.FindByName(name);

        if (p != null)
            Console.WriteLine("Found: " + p.Name + "  Price: " + p.Price);
        else
            Console.WriteLine("Perfume Not Found!");

        Pause();
    }
    public void Filter()
    {
        Console.Clear();
        string name = ReadText("Enter Name :");
        PerfumeSystem p = dl.FindByName(name);
        if (p = " janan")
            Console.WriteLine(" Found:" p.Name + " price " + p.Price);
        else
            Console.WriteLine("Perfume Not Found!");
        Pause();
    }
    public void UpdatePrice()
    {
        Console.Clear();
        string name = ReadText("Enter name: ");
        int newPrice = ReadInt("Enter new price: ");

        if (dl.UpdatePrice(name, newPrice))
            Console.WriteLine("Price Updated!");
        else
            Console.WriteLine("Perfume Not Found!");

        Pause();
    }

    public void DeletePerfume()
    {
        Console.Clear();
        string name = ReadText("Enter perfume name to delete: ");

        if (dl.DeletePerfume(name))
            Console.WriteLine("Perfume Deleted Successfully!");
        else
            Console.WriteLine("Perfume Not Found!");

        Pause();
    }

    public void SortPerfumes()
    {
        Console.Clear();
        dl.SortByName();
        Console.WriteLine("Perfumes Sorted Successfully!");
        Pause();
    }
}
