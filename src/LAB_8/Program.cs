using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // Завдання 1
        int[] numbers = { 12, 15, 7, 20, 33, 50, 8, 11, 90, 45 };
        var filteredNumbers = numbers.Where(n => n % 3 == 0 || n % 5 == 0);
        int sum = filteredNumbers.Sum();

        Console.WriteLine("Числа, що діляться на 3 або 5: " + string.Join(", ", filteredNumbers));
        Console.WriteLine("Сума цих чисел: " + sum);

        // Завдання 2
        string[] productNames = { "Хліб", "Молоко", "Яблука", "Сир", "Шоколад", "Кава", "Чай" };
        double[] productPrices = { 25.5, 32.0, 45.3, 120.0, 80.0, 150.0, 75.5 };

        double averagePrice = productPrices.Average();
        Console.WriteLine("Середня ціна: " + averagePrice);

        var expensiveProducts = productNames.Zip(productPrices, (name, price) => new { name, price })
                                            .Where(p => p.price > averagePrice);
        Console.WriteLine("Товари, дорожчі за середню ціну:");
        foreach (var product in expensiveProducts)
        {
            Console.WriteLine(product.name + " - " + product.price);
        }

        int minIndex = Array.IndexOf(productPrices, productPrices.Min());
        int maxIndex = Array.IndexOf(productPrices, productPrices.Max());

        Console.WriteLine("Найдешевший товар: " + productNames[minIndex] + " - " + productPrices[minIndex]);
        Console.WriteLine("Найдорожчий товар: " + productNames[maxIndex] + " - " + productPrices[maxIndex]);
    }
}


