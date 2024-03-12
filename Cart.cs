namespace Vending_machine;

using System;
using System.Collections.Generic;
using System.Linq;

public class Cart
{
    public List<Product> Products { get; set; }

    public Cart()
    {
        Products = new List<Product>();
    }

    public void AddProducts(params Product[] products)
    {
        Products.AddRange(products);
    }

    public int GetTotal()
    {
        return Products.Sum(product => product.Price);
    }
}
