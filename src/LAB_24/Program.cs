using System;

// === Завдання 1: Adapter ===

public interface INewPrinter
{
    void Print(string message);
}

public class OldPrinter
{
    public void OldPrint(string message)
    {
        Console.WriteLine($"[OldPrinter]: {message}");
    }
}

public class PrinterAdapter : INewPrinter
{
    private readonly OldPrinter _oldPrinter;

    public PrinterAdapter(OldPrinter oldPrinter)
    {
        _oldPrinter = oldPrinter;
    }

    public void Print(string message)
    {
        _oldPrinter.OldPrint(message);
    }
}

// === Завдання 2: Facade ===

public class Engine
{
    public void Start()
    {
        Console.WriteLine("Двигун запущено.");
    }
}

public class Battery
{
    public void Start()
    {
        Console.WriteLine("Акумулятор активовано.");
    }
}

public class IgnitionSystem
{
    public void Start()
    {
        Console.WriteLine("Система запалювання увімкнена.");
    }
}

public class CarFacade
{
    private readonly Engine _engine = new();
    private readonly Battery _battery = new();
    private readonly IgnitionSystem _ignition = new();

    public void StartCar()
    {
        Console.WriteLine("Початок запуску авто...");
        _battery.Start();
        _ignition.Start();
        _engine.Start();
        Console.WriteLine("Авто готове до руху!\n");
    }
}

// === Завдання 3: Decorator ===

public interface IWriter
{
    void Write(string text);
}

public class ConsoleWriter : IWriter
{
    public void Write(string text)
    {
        Console.WriteLine(text);
    }
}

public class TimestampWriter : IWriter
{
    private readonly IWriter _inner;

    public TimestampWriter(IWriter inner)
    {
        _inner = inner;
    }

    public void Write(string text)
    {
        string stamped = $"[{DateTime.Now:HH:mm:ss}] {text}";
        _inner.Write(stamped);
    }
}

// === Основна програма ===

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Adapter ===");
        INewPrinter printer = new PrinterAdapter(new OldPrinter());
        printer.Print("Привіт з нового інтерфейсу!");

        Console.WriteLine("\n=== Facade ===");
        CarFacade car = new CarFacade();
        car.StartCar();

        Console.WriteLine("=== Decorator ===");
        IWriter writer = new TimestampWriter(new ConsoleWriter());
        writer.Write("Привіт, світ!");
    }
}
