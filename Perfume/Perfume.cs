namespace PerfumeSystem;

public class Perfume
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }

    public Perfume()
    {
        Id = 0;
        Name = "";
        Price = 0;
        Quantity = 0;
    }

    public Perfume(int id, string name, int price, int quantity)
    {
        Id = id;
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public Perfume(Perfume other)
    {
        Id = other.Id;
        Name = other.Name;
        Price = other.Price;
        Quantity = other.Quantity;
    }
}
