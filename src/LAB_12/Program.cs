using System;

struct Point
{
    public double X { get; }
    public double Y { get; }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    public double DistanceTo(Point other)
    {
        return Math.Sqrt(Math.Pow(other.X - X, 2) + Math.Pow(other.Y - Y, 2));
    }
}

class Car
{
    public string Brand { get; }
    public string Model { get; }
    public int Year { get; }
    public string Color { get; }

    public Car(string brand, string model)
    {
        Brand = brand;
        Model = model;
    }

    public Car(string brand, string model, int year)
        : this(brand, model)
    {
        Year = year;
    }

    public Car(string brand, string model, int year, string color)
        : this(brand, model, year)
    {
        Color = color;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Авто: {Brand} {Model}, Рік: {Year}, Колір: {Color}");
    }
}

class Program
{
    static void Main()
    {
        // Перевірка структури Point
        Point p1 = new Point(3, 4);
        Point p2 = new Point(0, 0);
        Console.WriteLine($"Відстань між точками: {p1.DistanceTo(p2)}");

        // Перевірка класу Car
        Car car1 = new Car("Toyota", "Corolla");
        Car car2 = new Car("Honda", "Civic", 2020);
        Car car3 = new Car("Ford", "Mustang", 2022, "Червоний");

        car1.ShowInfo();
        car2.ShowInfo();
        car3.ShowInfo();
    }
}