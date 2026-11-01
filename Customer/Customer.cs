namespace PerfumeSystem;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }

    public Customer()
    {
        Id = 0;
        Name = "";
        Phone = "";
    }

    public Customer(int id, string name, string phone)
    {
        Id = id;
        Name = name;
        Phone = phone;
    }

    public Customer(Customer other)
    {
        Id = other.Id;
        Name = other.Name;
        Phone = other.Phone;
    }
}
