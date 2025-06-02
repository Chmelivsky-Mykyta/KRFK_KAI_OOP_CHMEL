namespace LAB_6;

class Program
{
    static void Main()
    {
        // 1
        Console.Write("Введіть число: ");
        int number = int.Parse(Console.ReadLine());
        if (number % 2 == 0)
            Console.WriteLine("Число парне.");
        else
            Console.WriteLine("Число непарне.");

        // 2
        Console.Write("Введіть вашу оцінку (0-100): ");
        int score = int.Parse(Console.ReadLine());
        if (score >= 90)
            Console.WriteLine("Ваша оцінка: A");
        else if (score >= 75)
            Console.WriteLine("Ваша оцінка: B");
        else if (score >= 60)
            Console.WriteLine("Ваша оцінка: C");
        else
            Console.WriteLine("Ваша оцінка: F");

        // 3
        Console.Write("Введіть число (1-7): ");
        int day = int.Parse(Console.ReadLine());
        switch (day)
        {
            case 1: Console.WriteLine("Понеділок"); break;
            case 2: Console.WriteLine("Вівторок"); break;
            case 3: Console.WriteLine("Середа"); break;
            case 4: Console.WriteLine("Четвер"); break;
            case 5: Console.WriteLine("П'ятниця"); break;
            case 6: Console.WriteLine("Субота"); break;
            case 7: Console.WriteLine("Неділя"); break;
            default: Console.WriteLine("Невідомий день"); break;
        }

        // 4
        Console.Write("Введіть марку авто: ");
        string car = Console.ReadLine();
        switch (car)
        {
            case "Toyota": Console.WriteLine("Японія"); break;
            case "BMW": Console.WriteLine("Німеччина"); break;
            case "Tesla": Console.WriteLine("США"); break;
            default: Console.WriteLine("Невідома марка"); break;
        }

        // 5
        Console.Write("Введіть температуру: ");
        int temp = int.Parse(Console.ReadLine());
        Console.WriteLine(temp >= 0 ? "Погода тепла" : "Погода холодна");

        // 6
        try
        {
            Console.Write("Введіть перше число: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введіть друге число: ");
            int b = int.Parse(Console.ReadLine());
            int result = a / b;
            Console.WriteLine($"Результат: {result}");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Помилка: поділ на нуль!");
        }
    }
}
