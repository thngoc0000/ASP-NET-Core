using Collections;

var user = new Dictionary<string, Product>();

bool isRunning = true;
while (isRunning)
{
    Console.WriteLine("1. Add new product");
    Console.WriteLine("2. Delete product");
    Console.WriteLine("3. Find product");
    Console.WriteLine("4. Show all products");
    Console.WriteLine("5. Exit");
    Console.Write("Select your options:");

    int input = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("===================================");

    if (input == 5)
    {
        isRunning = false;
        break;
    }
    else if (input == 1)
    {
        var product = new Product();
        Console.Write("Enter product name:");
        product.Name = Console.ReadLine() ?? string.Empty;
        Console.Write("Enter product description:");
        product.Description = Console.ReadLine() ?? string.Empty;
        user.Add(product.Name, product);
    }
    else if (input == 2)
    {
        Console.Write("Enter product name need to delete:");
        user.Remove(Console.ReadLine() ?? string.Empty);
    }
    else if (input == 3)
    {
        Console.Write("Enter product name need to find:");
        string productName = Console.ReadLine() ?? string.Empty;
        if (user.TryGetValue(productName, out var product))
        {
            Console.WriteLine($"Product found: {product.Name} - {product.Description}");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }
    else if (input == 4)
    {
        if (user == null || user.Count == 0)
        {
            Console.WriteLine("No products available.");
        }
        else
        {
            foreach (var kvp in user)
            {
                Console.WriteLine($"Product: {kvp.Value.Name} - {kvp.Value.Description}");
            }
        }
    }

    Console.WriteLine("===================================");
}