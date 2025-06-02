using System;

// Завдання 1: Узагальнений клас Container<T>
public class Container<T>
{
    public T Value { get; set; }

    public void ShowInfo()
    {
        Console.WriteLine($"Значення: {Value}, Тип: {Value.GetType().Name}");
    }
}

// Завдання 2: Узагальнений метод FindMax
public class Utility
{
    public static T FindMax<T>(T[] array) where T : IComparable<T>
    {
        if (array == null || array.Length == 0)
        {
            throw new ArgumentException("Масив порожній або null");
        }

        T max = array[0];

        foreach (T item in array)
        {
            if (item.CompareTo(max) > 0)
            {
                max = item;
            }
        }

        return max;
    }
}

// Основна програма
class Program
{
    static void Main()
    {
        // === Завдання 1 ===
        Console.WriteLine("=== Завдання 1: Узагальнений контейнер ===");

        Container<int> intBox = new Container<int> { Value = 42 };
        Container<string> strBox = new Container<string> { Value = "Hello" };

        intBox.ShowInfo();
        strBox.ShowInfo();

        // === Завдання 2 ===
        Console.WriteLine("\n=== Завдання 2: Узагальений метод FindMax ===");

        int[] intArray = { 5, 8, 2, 19, 3 };
        double[] doubleArray = { 1.1, 3.3, 2.2, 4.4 };
        string[] stringArray = { "apple", "banana", "orange" };

        Console.WriteLine($"Максимум (int): {Utility.FindMax(intArray)}");
        Console.WriteLine($"Максимум (double): {Utility.FindMax(doubleArray)}");
        Console.WriteLine($"Максимум (string): {Utility.FindMax(stringArray)}");
    }
}
