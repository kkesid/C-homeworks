
var detergent = new HouseholdChemicals
{
    ID = 1,
    Name = "Dish Soap",
    Price = 2.99,
    Quantity = 100,
    HazardousMaterial = "No"
};

var apple = new FoodProduct
{
    ID = 2,
    Name = "Apple",
    Price = 0.50,
    Quantity = 200,
    ExpirationDate = DateTime.Now.AddDays(7)
};

var incomingFlow = new IncomingProduct
{
    Product = detergent,
    Date = DateTime.Now,
    Quantity = 50
};

incomingFlow.ProcessFlow(); 

var soldFlow = new SoldProduct
{
    Product = apple,
    Date = DateTime.Now,
    Quantity = 10
};

soldFlow.ProcessFlow();

Console.WriteLine();

detergent.DisplayInfo();
apple.DisplayInfo();
   

public abstract class Product
{
    public int ID { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public abstract void DisplayInfo();
}
public class HouseholdChemicals: Product
{
    public string HazardousMaterial { get; set; }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Household Chemical - ID: {ID}, Name: {Name}, Price: {Price}, Quantity: {Quantity}, Hazardous Material: {HazardousMaterial}");
    }
}

public class FoodProduct : Product
{
    public DateTime ExpirationDate { get; set; } 

    public override void DisplayInfo()
    {
        Console.WriteLine($"Food Product - ID: {ID}, Name: {Name}, Price: {Price}, Quantity: {Quantity}, Expiration Date: {ExpirationDate.ToShortDateString()}");
    }
}
public abstract class ProductFlow
{
    public Product Product { get; set; }
    public DateTime Date { get; set; }
    public int Quantity { get; set; }

    public abstract void ProcessFlow();
}
public class IncomingProduct : ProductFlow
{
    public override void ProcessFlow()
    {
        Console.WriteLine($"Incoming Product: {Product.Name}, Quantity: {Quantity} on {Date}");
        Product.Quantity += Quantity;
    }
}
public class SoldProduct : ProductFlow
{
    public override void ProcessFlow()
    {
        Console.WriteLine($"Sold Product: {Product.Name}, Quantity: {Quantity} on {Date}");
        Product.Quantity -= Quantity;
    }
}
public class WrittenOffProduct : ProductFlow
{
    public override void ProcessFlow()
    {
        Console.WriteLine($"Written Off Product: {Product.Name}, Quantity: {Quantity} on {Date}");
        Product.Quantity -= Quantity;
    }
}
public class TransferredProduct : ProductFlow
{
    public string Destination { get; set; }

    public override void ProcessFlow()
    {
        Console.WriteLine($"Transferred Product: {Product.Name}, Quantity: {Quantity} to {Destination} on {Date}");
        Product.Quantity -= Quantity;
    }
}