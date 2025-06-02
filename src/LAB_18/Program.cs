using System;
using System.Collections.Generic;

// Завдання 1: Інтерфейс IAnimal та класи Dog, Cat
public interface IAnimal
{
    void Speak();
    void Eat();
}

public class Dog : IAnimal
{
    public void Speak()
    {
        Console.WriteLine("Собака каже: Гав-гав!");
    }

    public void Eat()
    {
        Console.WriteLine("Собака їсть м'ясо.");
    }
}

public class Cat : IAnimal
{
    public void Speak()
    {
        Console.WriteLine("Кішка каже: Няв-няв!");
    }

    public void Eat()
    {
        Console.WriteLine("Кішка їсть рибу.");
    }
}

// Завдання 2: Інтерфейс IPaymentMethod та класи оплат
public interface IPaymentMethod
{
    void Pay(decimal amount);
}

public class CreditCard : IPaymentMethod
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Оплата кредитною карткою: {amount} грн");
    }
}

public class PayPal : IPaymentMethod
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Оплата через PayPal: {amount} грн");
    }
}

public class ApplePay : IPaymentMethod
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Оплата через ApplePay: {amount} грн");
    }
}

public class Order
{
    public IPaymentMethod PaymentMethod { get; set; }

    public Order(IPaymentMethod paymentMethod)
    {
        PaymentMethod = paymentMethod;
    }

    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine("Обробка платежу...");
        PaymentMethod.Pay(amount);
        Console.WriteLine("Платіж завершено.\n");
    }
}

// Головний клас
class Program
{
    static void Main()
    {
        // === Завдання 1 ===
        Console.WriteLine("=== Завдання 1: Тварини ===");
        List<IAnimal> animals = new List<IAnimal>
        {
            new Dog(),
            new Cat()
        };

        foreach (IAnimal animal in animals)
        {
            animal.Speak();
            animal.Eat();
            Console.WriteLine();
        }

        // === Завдання 2 ===
        Console.WriteLine("=== Завдання 2: Платіжна система ===");
        Order order1 = new Order(new CreditCard());
        order1.ProcessPayment(500);

        Order order2 = new Order(new PayPal());
        order2.ProcessPayment(250);

        Order order3 = new Order(new ApplePay());
        order3.ProcessPayment(300);
    }
}
