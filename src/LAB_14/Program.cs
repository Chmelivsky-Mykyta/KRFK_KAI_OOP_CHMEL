using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        // 1. Створення тестових лог-файлів
        CreateLogFiles();

        // 2. Масив імен файлів
        string[] fileNames = { "log1.txt", "log2.txt", "log3.txt" };

        // 3. Створення та запуск задач для обробки кожного файлу
        Task[] tasks = fileNames.Select(file => Task.Run(() => ProcessFile(file))).ToArray();

        // 4. Очікування завершення всіх задач
        await Task.WhenAll(tasks);

        Console.WriteLine("Обробка файлів завершена!");
    }

    static void CreateLogFiles()
    {
        Random rand = new Random();

        for (int i = 1; i <= 3; i++)
        {
            using (StreamWriter writer = new StreamWriter($"log{i}.txt"))
            {
                for (int j = 0; j < 10000; j++)
                {
                    if (rand.Next(0, 10) == 0)  // 10% шанс на "ERROR"
                        writer.WriteLine("ERROR: щось пішло не так.");
                    else
                        writer.WriteLine("INFO: все гаразд.");
                }
            }
        }

        Console.WriteLine("Файли log1.txt, log2.txt, log3.txt створені.");
    }

    static void ProcessFile(string fileName)
    {
        try
        {
            int errorCount = File.ReadLines(fileName)
                .Count(line => line.Contains("ERROR"));

            Console.WriteLine($"Файл {fileName}: знайдено {errorCount} помилок.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при обробці файлу {fileName}: {ex.Message}");
        }
    }
}