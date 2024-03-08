using System;

// Завдання 1
class ATriangle
{
    // Поля
    protected int a;
    protected int b;
    protected int c;

    // Конструктор
    public ATriangle(int a, int b, int c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    // Методи
    public void PrintSides()
    {
        Console.WriteLine($"Сторони трикутника: {a}, {b}, {c}");
    }

    public int Perimeter()
    {
        return a + b + c;
    }

    public double Area()
    {
        double p = Perimeter() / 2.0;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    public bool IsIsosceles()
    {
        return a == b || a == c || b == c;
    }

    // Властивості
    public int SideA
    {
        get { return a; }
        set { a = value; }
    }

    public int SideB
    {
        get { return b; }
        set { b = value; }
    }

    public int SideC
    {
        get { return c; }
        set { c = value; }
    }

    public int Color { get; } // Колір трикутника (тільки для читання)
}

// Завдання 2
class Product
{
    public string Name { get; set; }
    public double Price { get; set; }

    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public virtual void Show()
    {
        Console.WriteLine($"Name: {Name}, Price: {Price}");
    }
}

class Toy : Product
{
    public string AgeCategory { get; set; }

    public Toy(string name, double price, string ageCategory) : base(name, price)
    {
        AgeCategory = ageCategory;
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Age Category: {AgeCategory}");
    }
}

class DairyProduct : Product
{
    public DateTime ExpirationDate { get; set; }

    public DairyProduct(string name, double price, DateTime expirationDate) : base(name, price)
    {
        ExpirationDate = expirationDate;
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Expiration Date: {ExpirationDate}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Завдання 1
        ATriangle[] triangles = new ATriangle[]
        {
            new ATriangle(3, 4, 5),
            new ATriangle(5, 5, 8),
            new ATriangle(6, 6, 6)
        };

        int isoscelesCount = 0;

        foreach (var triangle in triangles)
        {
            triangle.PrintSides();
            Console.WriteLine($"Периметр: {triangle.Perimeter()}");
            Console.WriteLine($"Площа: {triangle.Area()}");
            if (triangle.IsIsosceles())
            {
                Console.WriteLine("Цей трикутник - рівнобедрений");
                isoscelesCount++;
            }
            Console.WriteLine();
        }

        Console.WriteLine($"Загальна кількість рівнобедрених трикутників: {isoscelesCount}");

        // Завдання 2
        Product[] products = new Product[3];
        products[0] = new Toy("Teddy Bear", 15.99, "0-3 years");
        products[1] = new DairyProduct("Milk", 1.99, DateTime.Now.AddDays(7));
        products[2] = new Toy("LEGO Set", 29.99, "4-8 years");

        foreach (var product in products)
        {
            product.Show();
            Console.WriteLine();
        }
    }
}
