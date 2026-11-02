namespace PerfumeSystem;

public class PerfumeDL
{
    private List<Perfume> perfumes = new List<Perfume>();
    private string filePath = "perfumes.txt";

    public void LoadData()
    {
        perfumes.Clear();

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 4)
                {
                    Perfume p = new Perfume(int.Parse(parts[0]), parts[1],
                                            int.Parse(parts[2]), int.Parse(parts[3]));
                    perfumes.Add(p);
                }
            }
        }

        if (perfumes.Count == 0)
        {
            perfumes.Add(new Perfume(1, "Prime edenrobe", 4000, 30));
            perfumes.Add(new Perfume(2, "Dior Suavage", 20000, 50));
            perfumes.Add(new Perfume(3, "Alpha Men", 4500, 10));
            perfumes.Add(new Perfume(4, "Janan by J.", 7500, 35));
            SaveData();
        }
    }

    public void SaveData()
    {
        StreamWriter writer = new StreamWriter(filePath);

        for (int i = 0; i < perfumes.Count; i++)
        {
            Perfume p = perfumes[i];
            writer.WriteLine(p.Id + "|" + p.Name + "|" + p.Price + "|" + p.Quantity);
        }

        writer.Close();
    }

    public void AddPerfume(Perfume p)
    {
        if (perfumes.Count == 0)
            p.Id = 1;
        else
            p.Id = perfumes[perfumes.Count - 1].Id + 1;

        perfumes.Add(p);
        SaveData();
    }

    public List<Perfume> GetAll()
    {
        return perfumes;
    }

    public Perfume FindByName(string name)
    {
        foreach (Perfume p in perfumes)
        {
            if (p.Name.ToLower() == name.ToLower())
                return p;
        }
        return null;
    }

    public bool UpdatePrice(string name, int newPrice)
    {
        Perfume p = FindByName(name);
        if (p == null)
            return false;

        p.Price = newPrice;
        SaveData();
        return true;
    }

    public bool UpdateQuantity(string name, int newQty)
    {
        Perfume p = FindByName(name);
        if (p == null)
            return false;

        p.Quantity = newQty;
        SaveData();
        return true;
    }

    public bool DeletePerfume(string name)
    {
        Perfume p = FindByName(name);
        if (p == null)
            return false;

        perfumes.Remove(p);
        SaveData();
        return true;
    }

    public void SortByName()
    {
        Perfume[] arr = perfumes.ToArray();

        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - i - 1; j++)
            {
                if (string.Compare(arr[j].Name, arr[j + 1].Name) > 0)
                {
                    Perfume temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }

        perfumes = new List<Perfume>(arr);
        SaveData();
    } 

}
