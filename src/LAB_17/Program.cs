using System;

public class Student
{
    private string name;
    private int age;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value >= 0 && value <= 120)
            {
                age = value;
            }
            else
            {
                Console.WriteLine("Некоректний вік. Вік має бути від 0 до 120.");
            }
        }
    }
}

public class Car
{
    private int speed;

    public int Speed
    {
        get { return speed; }
    }

    public void Accelerate(int amount)
    {
        speed += amount;
        Console.WriteLine($"Прискорення: +{amount}, Поточна швидкість: {speed}");
    }

    public void Brake(int amount)
    {
        if (amount < 0)
        {
            Console.WriteLine("Гальмування не може бути від’ємним.");
            return;
        }

        speed -= amount;
        if (speed < 0)
        {
            speed = 0;
        }
        Console.WriteLine($"Гальмування: -{amount}, Поточна швидкість: {speed}");
    }
}

class Program
{
    static void Main()
    {
        // Тестування класу Student
        Console.WriteLine("=== Тестування класу Student ===");
        Student student = new Student();
        student.Name = "Андрій";
        student.Age = 25;
        Console.WriteLine($"Ім'я: {student.Name}, Вік: {student.Age}");

        student.Age = -5; // Некоректне значення

        // Тестування класу Car
        Console.WriteLine("\n=== Тестування класу Car ===");
        Car car = new Car();
        car.Accelerate(50);
        car.Accelerate(30);
        car.Brake(20);
        car.Brake(70); // перевірка на швидкість нижче 0
    }
}
