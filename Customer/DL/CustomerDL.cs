namespace PerfumeSystem;

public class CustomerDL
{
    private List<Customer> customers = new List<Customer>();
    private string filePath = "customers.txt";

    public void LoadData()
    {
        customers.Clear();

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    customers.Add(new Customer(int.Parse(parts[0]), parts[1], parts[2]));
                }
            }
        }
    }

    public void SaveData()
    {
        StreamWriter writer = new StreamWriter(filePath);

        for (int i = 0; i < customers.Count; i++)
        {
            Customer c = customers[i];
            writer.WriteLine(c.Id + "|" + c.Name + "|" + c.Phone);
        }

        writer.Close();
    }

    public void AddCustomer(Customer c)
    {
        if (customers.Count == 0)
            c.Id = 1;
        else
            c.Id = customers[customers.Count - 1].Id + 1;

        customers.Add(c);
        SaveData();
    }

    public List<Customer> GetAll()
    {
        return customers;
    }

    public Customer FindByPhone(string phone)
    {
        foreach (Customer c in customers)
        {
            if (c.Phone == phone)
                return c;
        }
        return null;
    }

    public bool UpdatePhone(string oldPhone, string newPhone)
    {
        Customer c = FindByPhone(oldPhone);
        if (c == null)
            return false;

        c.Phone = newPhone;
        SaveData();
        return true;
    }

    public bool DeleteCustomer(string phone)
    {
        Customer c = FindByPhone(phone);
        if (c == null)
            return false;

        customers.Remove(c);
        SaveData();
        return true;
    }

    public void SortByName()
    {
        Customer[] arr = customers.ToArray();

        for (int i = 0; i < arr.Length - 1; i++)
        {
            int min = i;
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (string.Compare(arr[j].Name, arr[min].Name) < 0)
                    min = j;
            }

            Customer temp = arr[i];
            arr[i] = arr[min];
            arr[min] = temp;
        }

        customers = new List<Customer>(arr);
        SaveData();
    }
}
