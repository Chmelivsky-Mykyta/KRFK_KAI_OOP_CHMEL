using LAB_7;

class Program
{
    static void Main()
    {
        // 1
        Console.WriteLine("Парні числа від 2 до 20:");
        for (int i = 2; i <= 20; i += 2)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine("\n");

        // 2
        int sum = 0;
        int number;

        Console.WriteLine("Введіть число (0 для завершення):");
        while ((number = Convert.ToInt32(Console.ReadLine())) != 0)
        {
            sum += number;
        }
        Console.WriteLine("Сума: " + sum);
        Console.WriteLine();

        // 3
        string password;
        const string correctPassword = "1234";

        do
        {
            Console.Write("Введіть пароль: ");
            password = Console.ReadLine();

            if (password != correctPassword)
            {
                Console.WriteLine("Неправильний пароль!\n");
            }

        } while (password != correctPassword);

        Console.WriteLine("Доступ дозволено!");
    }
}
