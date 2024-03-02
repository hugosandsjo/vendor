using Vending_machine;

var drinks = new Category("Drinks");
var snacks = new Category("Snacks");
var cigarettes = new Category("Cigarettes");

var cocacola = new Product("Coca cola", 26, drinks);
var fanta = new Product("Fanta", 25, drinks);
var sprite = new Product("Sprite", 24, drinks);

var pringles = new Product("Pringles", 35, snacks);
var peanuts = new Product("Peanuts", 12, snacks);
var doodles = new Product("Cheeze doodles", 23, snacks);

var blend = new Product("Blend", 50, cigarettes);
var camel = new Product("Camel", 55, cigarettes);
var luckystrike = new Product("Lucky strike", 58, cigarettes);

drinks.AddProduct(cocacola, fanta, sprite);
snacks.AddProduct( pringles, peanuts, doodles);
cigarettes.AddProduct(blend, camel, luckystrike);

Console.WriteLine();
Console.WriteLine("Welcome to Vendor 3000, your local vending machine");
Console.WriteLine();
Console.WriteLine("First of all, what is your name?");
var name = Console.ReadLine();

int age;
bool validAge = false;

Console.WriteLine($"Hello {name}, what's your age?");
do
{
    var ageInput = Console.ReadLine();
    
    if (int.TryParse(ageInput, out age))
    {
        validAge = true;
    }
    else
    {
        Console.WriteLine("That's not a valid age, please try again");
    }
} while (!validAge);

Customer customer = new Customer(name, age);
Cart myCart = new Cart();
Console.WriteLine($"{customer.Name}, {customer.Age}");
Console.WriteLine($"Perfect {customer.Name}! You start with {customer.Balance} dollars");
Console.WriteLine("What would you like to order today? We have three categories:");
Console.WriteLine("1. Drinks");
Console.WriteLine("2. Snacks");
Console.WriteLine("3. Cigarettes");

while (true)
{
var category = Console.ReadLine().ToUpper();

    while (true){
        Console.WriteLine("Would you like some more?");
    if (category == "DRINKS" || category == "1")
    {
        Console.WriteLine("-----");

        foreach (var drink in drinks.Products)
        {
            Console.WriteLine(drink.Name);
        }
        
        Console.WriteLine("-----");
        Console.WriteLine("Make your choice:");
        var drinkChoice = Console.ReadLine().ToLower();
        
        Console.WriteLine($"{drinkChoice} added to basket");
        if (drinkChoice == "coca cola")
        {
            myCart.AddProducts(cocacola);
           
        }
        
        Console.WriteLine("Would you like something else?");
        Console.WriteLine("Type help for instructions");
        break;
    }
    
    if (category == "SNACKS" || category == "2")
    {
        Console.WriteLine("-----");

        foreach (var snack in snacks.Products)
        {
            Console.WriteLine(snack.Name);
        }
        
        Console.WriteLine("-----");
        Console.WriteLine("Make your choice:");
        var snackChoice = Console.ReadLine();
        
        Console.WriteLine($"{snackChoice} added to basket");
        break;
    }
    
    if (category == "CIGARETTES" || category == "3")
    {   
        Console.WriteLine("Are you 18 or older?");
        var validAgee = Console.ReadLine();
        
        if (validAgee == "yes")
        {
            Console.WriteLine("You are eligible to buy cigarettes!");
            Console.WriteLine("-----");
            
            foreach (var brand in cigarettes.Products)
            {
                Console.WriteLine(brand.Name);
            }
            
            Console.WriteLine("-----");    
            Console.WriteLine("Make your choice:");
            var choice = Console.ReadLine();
            
            if (cigarettes.Products.Any(product => product.Name == choice))
            {
                Console.WriteLine($"{choice} added to basket.");
            }
            
            Console.WriteLine("Sorry, we dont have that brand of cigarettes at the moment");
            
        } 
        
        if (validAgee == "no")
        {
            Console.WriteLine("Sorry, come back when you're older");
            break;
        }
   
    }
    
    else
    {
        Console.Write("That's not a valid category, please try again:");
        Console.WriteLine();
    }
}
    
}