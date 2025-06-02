
using System;
using System.Collections.Generic;

class LAB_10
{
    static Queue<(decimal P, decimal r, int n)> mortgageQueue = new Queue<(decimal, decimal, int)>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Додати заявку на розрахунок іпотеки");
            Console.WriteLine("2. Обробити першу заявку");
            Console.WriteLine("3. Переглянути першу заявку");
            Console.WriteLine("4. Переглянути всі заявки");
            Console.WriteLine("5. Вийти");
            Console.Write("Оберіть дію: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddRequest();
                    break;
                case "2":
                    ProcessRequest();
                    break;
                case "3":
                    PeekRequest();
                    break;
                case "4":
                    ShowAllRequests();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Некоректний вибір, спробуйте ще раз.");
                    break;
            }
        }
    }

    static void AddRequest()
    {
        Console.Write("Введіть суму кредиту (P): ");
        decimal P = decimal.Parse(Console.ReadLine());

        Console.Write("Введіть річну відсоткову ставку (%): ");
        decimal annualRate = decimal.Parse(Console.ReadLine());
        decimal r = annualRate / 12 / 100;

        Console.Write("Введіть термін кредиту (роки): ");
        int years = int.Parse(Console.ReadLine());
        int n = years * 12;

        mortgageQueue.Enqueue((P, r, n));
        Console.WriteLine("Заявка додана до черги.");
    }

    static void ProcessRequest()
    {
        if (mortgageQueue.Count == 0)
        {
            Console.WriteLine("Черга порожня.");
            return;
        }

        var (P, r, n) = mortgageQueue.Dequeue();
        decimal M = P * (r * (decimal)Math.Pow((double)(1 + r), n)) / ((decimal)Math.Pow((double)(1 + r), n) - 1);
        M = Math.Round(M, 2);

        Console.WriteLine($"Щомісячний платіж: {M} грн");
    }

    static void PeekRequest()
    {
        if (mortgageQueue.Count == 0)
        {
            Console.WriteLine("Черга порожня.");
            return;
        }

        var (P, r, n) = mortgageQueue.Peek();
        Console.WriteLine($"Перша заявка: Сума кредиту {P} грн, річна ставка {r * 12 * 100}%, термін {n / 12} років.");
    }

    static void ShowAllRequests()
    {
        if (mortgageQueue.Count == 0)
        {
            Console.WriteLine("Черга порожня.");
            return;
        }

        Console.WriteLine("Список усіх заявок:");
        foreach (var (P, r, n) in mortgageQueue)
        {
            Console.WriteLine($"Сума: {P} грн, Ставка: {r * 12 * 100}%, Термін: {n / 12} років");
        }
    }
}

