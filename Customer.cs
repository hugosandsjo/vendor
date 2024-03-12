using System.ComponentModel.Design.Serialization;

namespace Vending_machine;

class Customer
{
    public string Name { get; set; }
    public int Age { get; set; }
    
    public int Balance;

    public Customer(string name, int age)
    {
        Name = name;
        Age = age;
        Balance = 200;
    }

    public bool Checkout(Cart cart)
    {
        int totalCost = cart.GetTotal();
        if (Balance >= totalCost)
        {
            Balance -= totalCost;
            Console.WriteLine($"You have successfully checked out. Your total: {totalCost}. Remaining balance: {Balance}");
            return true;
        }
       Console.WriteLine("Sorry! Not enough money");
       return false;
    }
    
}