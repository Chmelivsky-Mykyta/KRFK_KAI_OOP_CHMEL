using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    // Метод для виведення чисел від 1 до 500
    static void PrintNumbers()
    {
        for (int i = 1; i <= 500; i++)
        {
            Console.Write($"{i} ");
        }
        Console.WriteLine();
    }

    // Метод для обчислення факторіалу числа
    static long CalculateFactorial(int n)
    {
        long result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        Console.WriteLine($"Факторіал {n} = {result}");
        return result;
    }

    // Завдання 1: Виконання задач паралельно
    static void ExecuteParallelTasks()
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        // Використовуємо Parallel.Invoke для паралельного виконання двох задач
        Parallel.Invoke(
            () => PrintNumbers(),
            () => CalculateFactorial(10)
        );

        stopwatch.Stop();
        Console.WriteLine($"⏳ Час виконання: {stopwatch.ElapsedMilliseconds} мс");
    }

    // Завдання 2: Проблема гонки потоків і її вирішення

    // Варіант без потокобезпеки (Race Condition)
    static void RaceConditionExample()
    {
        int counter = 0;

        // Паралельне збільшення лічильника без потокобезпеки
        Parallel.For(0, 1000, i =>
        {
            counter++; // Гонка потоків!
        });

        Console.WriteLine($"Неправильний результат (без потокобезпеки): {counter} (очікується 1000)");
    }

    // Варіант з потокобезпекою (з lock)
    static void SafeIncrementWithLock()
    {
        int counter = 0;
        object locker = new object();

        // Паралельне збільшення лічильника з використанням lock
        Parallel.For(0, 1000, i =>
        {
            lock (locker) // Потокобезпека
            {
                counter++;
            }
        });

        Console.WriteLine($"Правильний результат (з lock): {counter}");
    }

    // Варіант з потокобезпекою (з Interlocked)
    static void SafeIncrementWithInterlocked()
    {
        int counter = 0;

        // Паралельне збільшення лічильника з використанням Interlocked
        Parallel.For(0, 1000, i =>
        {
            Interlocked.Increment(ref counter); // Безпечне збільшення
        });

        Console.WriteLine($"Правильний результат (з Interlocked): {counter}");
    }

    static void Main()
    {
        // Завдання 1
        Console.WriteLine("Завдання 1: Виконання задач паралельно");
        ExecuteParallelTasks();
        Console.WriteLine();

        // Завдання 2
        Console.WriteLine("Завдання 2: Проблема гонки потоків і її вирішення");
        RaceConditionExample();
        SafeIncrementWithLock();
        SafeIncrementWithInterlocked();
    }
}