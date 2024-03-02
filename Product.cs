namespace Vending_machine;

public class Product
{
    public string Name { get; set; }
    public int Price { get; set; }
    public Category Category { get; set; }
    
    public Product(string name, int price, Category category)
    {
        Name = name;
        Price = price;
        Category = category;
    }
}
