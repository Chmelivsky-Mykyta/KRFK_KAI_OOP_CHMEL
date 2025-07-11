﻿using System;

// === Завдання 1: Singleton ===
public class Logger
{
    private static Logger _instance;
    private static readonly object _lock = new();

    private Logger() { }

    public static Logger Instance
    {
        get
        {
            lock (_lock)
            {
                return _instance ??= new Logger();
            }
        }
    }

    public void Log(string msg)
    {
        Console.WriteLine($"[{DateTime.Now}] {msg}");
    }
}

// === Завдання 2: Factory Method ===
public interface INotification
{
    void Send(string message);
}

public class EmailNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"Email: {message}");
}

public class SMSNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"SMS: {message}");
}

public class PushNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"Push: {message}");
}

public class NotificationFactory
{
    public static INotification Create(string type)
    {
        return type.ToLower() switch
        {
            "email" => new EmailNotification(),
            "sms" => new SMSNotification(),
            "push" => new PushNotification(),
            _ => throw new ArgumentException("Невідомий тип повідомлення.")
        };
    }
}

// === Завдання 3: Builder ===
public class Computer
{
    public string CPU { get; set; }
    public string GPU { get; set; }
    public int RAM { get; set; }
    public int SSD { get; set; }

    public override string ToString()
    {
        return $"Computer: CPU={CPU}, GPU={GPU}, RAM={RAM}GB, SSD={SSD}GB";
    }
}

public class ComputerBuilder
{
    private readonly Computer _computer = new();

    public ComputerBuilder SetCPU(string cpu)
    {
        _computer.CPU = cpu;
        return this;
    }

    public ComputerBuilder SetGPU(string gpu)
    {
        _computer.GPU = gpu;
        return this;
    }

    public ComputerBuilder SetRAM(int ram)
    {
        _computer.RAM = ram;
        return this;
    }

    public ComputerBuilder SetSSD(int ssd)
    {
        _computer.SSD = ssd;
        return this;
    }

    public Computer Build()
    {
        return _computer;
    }
}

// === Головна програма ===
class Program
{
    static void Main()
    {
        Console.WriteLine("=== Singleton ===");
        var logger1 = Logger.Instance;
        var logger2 = Logger.Instance;

        logger1.Log("Це перше повідомлення.");
        logger2.Log("Це друге повідомлення.");
        Console.WriteLine($"logger1 і logger2 — це один екземпляр: {ReferenceEquals(logger1, logger2)}\n");

        Console.WriteLine("=== Factory Method ===");
        Console.Write("Тип повідомлення (email/sms/push): ");
        string type = Console.ReadLine();
        try
        {
            INotification notification = NotificationFactory.Create(type);
            notification.Send("Привіт, користувачу!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }

        Console.WriteLine("\n=== Builder ===");
        var gamingPC = new ComputerBuilder()
            .SetCPU("Intel i9")
            .SetGPU("NVIDIA RTX 4090")
            .SetRAM(32)
            .SetSSD(1000)
            .Build();

        var officePC = new ComputerBuilder()
            .SetCPU("Intel i5")
            .SetRAM(16)
            .SetSSD(512)
            .Build();

        Console.WriteLine(gamingPC);
        Console.WriteLine(officePC);
    }
}
