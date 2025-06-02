using System;
using System.Collections.Generic;
/*
class LAB_11
{
    static Queue<string> queue = new Queue<string>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Додати заявку");
            Console.WriteLine("2. Обробити заявку");
            Console.WriteLine("3. Подивитися першу заявку");
            Console.WriteLine("4. Показати всі заявки");
            Console.WriteLine("5. Вийти");
            Console.Write("Виберіть опцію: ");

            string option = Console.ReadLine();

            switch (option)
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
                    Console.WriteLine("Програма завершена.");
                    return;
                default:
                    Console.WriteLine("Невідома команда. Спробуйте ще раз.");
                    break;
            }
        }
    }

    static void AddRequest()
    {
        Console.Write("Введіть текст заявки: ");
        string request = Console.ReadLine();
        queue.Enqueue(request);
        Console.WriteLine("Заявку додано!");
    }

    static void ProcessRequest()
    {
        if (queue.Count > 0)
        {
            string request = queue.Dequeue();
            Console.WriteLine($"Заявка \"{request}\" оброблена!");
        }
        else
        {
            Console.WriteLine("Черга порожня.");
        }
    }

    static void PeekRequest()
    {
        if (queue.Count > 0)
        {
            Console.WriteLine($"Перша заявка в черзі: \"{queue.Peek()}\"");
        }
        else
        {
            Console.WriteLine("Черга порожня.");
        }
    }

    static void ShowAllRequests()
    {
        if (queue.Count > 0)
        {
            Console.WriteLine("Усі заявки в черзі:");
            foreach (var request in queue)
            {
                Console.WriteLine($"- {request}");
            }
        }
        else
        {
            Console.WriteLine("Черга порожня.");
        }
    }
}
*/

class LAB_11
{
    static Queue<string> queue = new Queue<string>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Додати заявку");
            Console.WriteLine("2. Обробити заявку");
            Console.WriteLine("3. Подивитися першу заявку");
            Console.WriteLine("4. Показати всі заявки");
            Console.WriteLine("5. Вийти");
            Console.Write("Виберіть опцію: ");

            string option = Console.ReadLine();

            switch (option)
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
                    Console.WriteLine("Програма завершена.");
                    return;
                default:
                    Console.WriteLine("Невідома команда. Спробуйте ще раз.");
                    break;
            }
        }
    }

    static void AddRequest()
    {
        Console.Write("Введіть текст заявки: ");
        string request = Console.ReadLine();
        queue.Enqueue(request);
        Console.WriteLine("Заявку додано!");
    }

    static void ProcessRequest()
    {
        if (queue.Count > 0)
        {
            string request = queue.Dequeue();
            Console.WriteLine($"Заявка \"{request}\" оброблена!");
        }
        else
        {
            Console.WriteLine("Черга порожня.");
        }
    }

    static void PeekRequest()
    {
        if (queue.Count > 0)
        {
            Console.WriteLine($"Перша заявка в черзі: \"{queue.Peek()}\"");
        }
        else
        {
            Console.WriteLine("Черга порожня.");
        }
    }

    static void ShowAllRequests()
    {
        if (queue.Count > 0)
        {
            Console.WriteLine("Усі заявки в черзі:");
            foreach (var request in queue)
            {
                Console.WriteLine($"- {request}");
            }
        }
        else
        {
            Console.WriteLine("Черга порожня.");
        }
    }
}