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
        Balance = 100;
    }
}