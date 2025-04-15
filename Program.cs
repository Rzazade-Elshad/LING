namespace lingexss;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
}

public class Program
{
    static void Main(string[] args)
    {
        List<Product> products = new List<Product>{
            new Product { Id = 6, Name = "Notebook", Category = "Stationery", Price = 70, Stock = 25 },
            new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1200, Stock = 5 },
            new Product { Id = 2, Name = "Phone", Category = "Electronics", Price = 800, Stock = 10 },
            new Product { Id = 3, Name = "Book", Category = "Stationery", Price = 30, Stock = 50 },
            new Product { Id = 4, Name = "Pen", Category = "Stationery", Price = 5, Stock = 100 },
            new Product { Id = 5, Name = "TV", Category = "Electronics", Price = 1500, Stock = 2 }
        };
        Baha50(products);
        AdVeQiymet(products);
        Gruplar(products);
        Sort(products);
        mostEx(products);
        CheckStok(products);
        TotalPrice(products);
    }
    /*Butun qiymeti 50 manatdan yuxari olan mehsullari filterleyin.
Ekranda ancaq mehsullarin adini ve qiymetini gosterin
Mehsullari kategoriyasina gore qruplashdirin ve her kategoriyada nece mehsul var gosterin
Mehsullari qiymeti azalan sira ile duzun
En bahali mehsulu tapin
Butun mehsullarin stockunun 0-dan yuxari olub olmadigini yoxlayin.
Butun mehsullarin total qiymetini tapin.*/

    static void Baha50(List<Product> products)
    {
        var filtr = products.Where(p => p.Price > 50);
        Console.WriteLine("50 den baha :");
        foreach (var p in filtr)
            Console.WriteLine($"{p.Name} - {p.Price} AZN");
    }
    static void AdVeQiymet(List<Product> products)
    {
        var namesAndPrices = products.Select(p => new { p.Name, p.Price });

        Console.WriteLine("AD Qiymet:");
        foreach (var p in namesAndPrices)
            Console.WriteLine($"{p.Name} - {p.Price} AZN");
    }
    static void Gruplar(List<Product> products)
    {
        var grouped = products.GroupBy(p => p.Category);

        Console.WriteLine("Qruplar:");
        foreach (var group in grouped)
        {
            Console.WriteLine($"{group.Key}: {group.Count()} product(s)");
        }
    }
    static void Sort(List<Product> products)
    {
        var sorted = products.OrderByDescending(p => p.Price);
        Console.WriteLine("qiymet coxdan aza :");
        foreach (var p in sorted)
            Console.WriteLine($"{p.Name} - {p.Price} AZN");
    }
    static void mostEx(List<Product> products)
    {
        var mostEx = products.OrderByDescending(p => p.Price).FirstOrDefault();

        Console.WriteLine("en bahali mehsul:");
        if (mostEx != null)
            Console.WriteLine($"{mostEx.Name} - {mostEx.Price} AZN");
    }
    static void CheckStok(List<Product> products)
    {
        bool flaq = products.All(p => p.Stock > 0);

        Console.WriteLine($"butun mehsullar varmi ? : {flaq}");
    }
    static void TotalPrice(List<Product> products)
    {
        double total = products.Sum(p => p.Price);

        Console.WriteLine($"{total} AZN");
    }
}
