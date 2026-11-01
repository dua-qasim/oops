namespace PerfumeSystem;

public class SaleDL
{
    private List<Sale> sales = new List<Sale>();
    private string filePath = "sales.txt";

    public void LoadData()
    {
        sales.Clear();

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 5)
                {
                    Sale s = new Sale(int.Parse(parts[0]), parts[1], parts[2],
                                      int.Parse(parts[3]), int.Parse(parts[4]));
                    sales.Add(s);
                }
            }
        }
    }

    public void SaveData()
    {
        StreamWriter writer = new StreamWriter(filePath);

        for (int i = 0; i < sales.Count; i++)
        {
            Sale s = sales[i];
            writer.WriteLine(s.Id + "|" + s.CustomerName + "|" + s.PerfumeName + "|" + s.Quantity + "|" + s.Bill);
        }

        writer.Close();
    }

    public void AddSale(Sale s)
    {
        if (sales.Count == 0)
            s.Id = 1;
        else
            s.Id = sales[sales.Count - 1].Id + 1;

        sales.Add(s);
        SaveData();
    }

    public List<Sale> GetAll()
    {
        return sales;
    }

    public Sale FindById(int id)
    {
        foreach (Sale s in sales)
        {
            if (s.Id == id)
                return s;
        }
        return null;
    }

    public bool UpdateCustomerName(int id, string newName)
    {
        Sale s = FindById(id);
        if (s == null)
            return false;

        s.CustomerName = newName;
        SaveData();
        return true;
    }

    public bool DeleteSale(int id)
    {
        Sale s = FindById(id);
        if (s == null)
            return false;

        sales.Remove(s);
        SaveData();
        return true;
    }
}
