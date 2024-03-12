using System.Globalization;
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

//Start the program

Console.WriteLine();
Console.WriteLine("Welcome to Gulp Puff, your local vending machine");
Console.WriteLine();
Console.WriteLine("First of all, what is your name?");

var name = FirstCharToUpper(Console.ReadLine()) ;

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
Cart cart = new Cart();
bool adult = customer.Age >= 18;
Console.WriteLine($"{customer.Name}, {customer.Age}");
Console.WriteLine($"Perfect {customer.Name}! You start with {customer.Balance} dollars.");
printCommands();

// Run program
while (true)
{
    // Console.WriteLine("--- type MENU for options ---");
    
    var command = Console.ReadLine().ToUpper();
    
    bool commandHandled = false;
    
    if (command == "STORE" || command == "1"){
        
        printCategorys(); 
        var category = Console.ReadLine().ToUpper();
        commandHandled = true;
        
        if (category == "DRINKS" || category == "1")
        {
            int counter = 1;
            Console.WriteLine("-----");

            foreach (var drink in drinks.Products)
            {
                Console.WriteLine($"{counter}. {drink.Name}");
                counter++;
            }
        
            Console.WriteLine("-----");
            Console.WriteLine("Make your choice:");
        
            var drinkChoice = Console.ReadLine().ToLower();
        
            switch (drinkChoice)
            {
                case "coca cola":
                case "1":
                    cart.AddProducts(cocacola);
                    cartMessage(cocacola);
                    printCart();
                    printCommands();
                    continue;
                case "fanta":
                case "2":
                    cart.AddProducts(fanta);
                    cartMessage(fanta);
                    printCart();
                    printCommands();
                    continue;
                case "sprite":
                case "3":
                    cart.AddProducts(sprite);
                    cartMessage(sprite);
                    printCart();
                    printCommands();
                    continue;
                default:
                    Console.WriteLine("Invalid selection.");
                    continue; 
            } 
        }
    
        if (category == "SNACKS" || category == "2")
        {
            Console.WriteLine("-----");
            
            int counter = 1;
            foreach (var snack in snacks.Products)
            {
                Console.WriteLine($"{counter}. {snack.Name}");
                counter++;
            }
        
            Console.WriteLine("-----");
            Console.WriteLine("Make your choice:");
        
            var snackChoice = Console.ReadLine();
            
            switch (snackChoice)
            {
                case "pringles":
                case "1":
                    cart.AddProducts(pringles);
                    cartMessage(pringles);
                    printCart();
                    printCommands();
                    continue;
                case "peanuts":
                case "2":
                    cart.AddProducts(peanuts);
                    cartMessage(peanuts);
                    printCart();
                    printCommands();
                    continue;
                case "cheeze doodles":
                case "3":
                    cart.AddProducts(doodles);
                    cartMessage(doodles);
                    printCart();
                    printCommands();
                    continue;
                default:
                    Console.WriteLine("Invalid selection.");
                    continue; 
            } 
        
        }
    
        if (category == "CIGARETTES" || category == "3")
        {   
            // Check if user is old enough
            if (!adult)
            {
                Console.WriteLine("Sorry, come back when you're older");
            } 
            else
            {
                int counter = 1;
                Console.WriteLine("-----");

                foreach (var cigarette in cigarettes.Products)
                {
                    Console.WriteLine($"{counter}. {cigarette.Name}");
                    counter++;
                }
                
                Console.WriteLine("-----");
                Console.WriteLine("Make your choice:");
        
                var cigaretteChoice = Console.ReadLine().ToUpper();
                
                switch (cigaretteChoice)
                {
                    case "BLEND":
                    case "1":
                        cart.AddProducts(blend);
                        cartMessage(blend);
                        printCart();
                        printCommands();
                        continue;
                    case "CAMEL":
                    case "2":
                        cart.AddProducts(camel);
                        cartMessage(camel);
                        printCart();
                        printCommands();
                        continue;
                    case "LUCKY STRIKE":
                    case "3":
                        cart.AddProducts(luckystrike);
                        cartMessage(luckystrike);
                        printCart();
                        printCommands();
                        continue;
                    default:
                        Console.WriteLine("Invalid selection.");
                        continue; 
                } 
            }
   
        }
        
        else
        {
            Console.WriteLine("That's not a valid category, please try again:");
         
        } 
    }
    
    if (command == "CART" || command == "2")
    {
        commandHandled = true;
        
        if (cart.Products.Count > 0)
        {
            printCart();
        }
        else
        {
            Console.WriteLine("Cart is empty.");
        }
        printCommands();
    }
    
    if (command == "BALANCE" || command == "3")
    {
        Console.WriteLine($"Your balance: {customer.Balance}");
        commandHandled = true;
    }
    
    if (command == "MENU")
    {
        commandHandled = true;
        printCommands();
    }
    
    if (command == "CHECKOUT" || command == "4")
    {
        commandHandled = true;
        
        Console.WriteLine($"Are you sure you want to checkout with a balance of {customer.Balance} and a total of {cart.GetTotal()}?");
        Console.WriteLine("Type YES or NO");
        var answer = Console.ReadLine().ToUpper();
        
        // Check to see if user has enough money 
        if (answer == "YES" && cart.GetTotal() > customer.Balance)
        {
            Console.WriteLine("Not enough money!");
            printCommands();
            continue;
            
        } 
        
        if (answer == "YES" && cart.GetTotal() <= customer.Balance)
        {
            customer.Checkout(cart);
            Console.WriteLine("Success!");
        }
        
        if (answer == "NO")
        {
            Console.WriteLine("Okay, keep on shopping");
        }
        
        printCommands();
    }

    if (command == "EXIT" || command == "5")
    {
        Console.WriteLine("Exit vending machine?");
        Console.WriteLine("Type YES or NO");
        var answer = Console.ReadLine().ToUpper();

        if (answer == "NO")
        {
            Console.WriteLine("Okay, keep on shopping");
            printCommands();
        }
        
        if (answer == "YES")
        {
            Console.WriteLine("Okay, bye!");
            break;
        }
       
        Console.WriteLine("Whats that?");
        continue;
    }

    if (!commandHandled)
    {
        Console.WriteLine("Invalid command, please try again.");
        printCommands();
    }

}

void printCategorys()
{
    Console.WriteLine("Choose category:");
    Console.WriteLine("1. Drinks");
    Console.WriteLine("2. Snacks");
    Console.WriteLine("3. Cigarettes");
}

void printCommands()
{
    Console.WriteLine("1. Store");
    Console.WriteLine("2. Cart");
    Console.WriteLine("3. Balance");
    Console.WriteLine("4. Checkout");
    Console.WriteLine("5. Exit");
}

string FirstCharToUpper(string input)
{
    if (string.IsNullOrEmpty(input))
    {
        return string.Empty;
    }
    return $"{char.ToUpper(input[0])}{input.Substring(1).ToLower()}";
}

void cartMessage(Product choice)
{
    Console.WriteLine($"{choice.Name} added to cart!");
}

void printCart()
{
    Console.WriteLine("YOUR CART:");
    foreach (var product in cart.Products)
    {
        Console.WriteLine($"{product.Name}, {product.Price}");
    }
    Console.WriteLine($"TOTAL: {cart.GetTotal()}");
    Console.WriteLine($"BALANCE: {customer.Balance}");
}




