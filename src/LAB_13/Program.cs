using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Завдання 1: Фільтрація парних чисел ===");
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        Predicate<int> isEven = n => n % 2 == 0;
        int[] evenNumbers = Filter(numbers, isEven);

        Console.WriteLine("Парні числа:");
        foreach (var n in evenNumbers)
            Console.WriteLine(n);

        Console.WriteLine("\n=== Завдання 2: Подія при зміні статусу замовлення ===");

        Order order = new Order();
        order.OrderStatusChanged += OnStatusChanged;

        order.Status = "Замовлення отримано";
        order.Status = "Обробляється";
        order.Status = "Відправлено";
        order.Status = "Доставлено";
    }

    static int[] Filter(int[] array, Predicate<int> predicate)
    {
        List<int> result = new List<int>();
        foreach (var item in array)
        {
            if (predicate(item))
                result.Add(item);
        }
        return result.ToArray();
    }

    static void OnStatusChanged(object sender, string status)
    {
        Console.WriteLine($"Статус замовлення змінено на: {status}");
    }
}

class Order
{
    public event EventHandler<string> OrderStatusChanged;

    private string status;

    public string Status
    {
        get => status;
        set
        {
            if (status != value)
            {
                status = value;
                OnOrderStatusChanged(status);
            }
        }
    }

    protected virtual void OnOrderStatusChanged(string newStatus)
    {
        OrderStatusChanged?.Invoke(this, newStatus);
    }
}