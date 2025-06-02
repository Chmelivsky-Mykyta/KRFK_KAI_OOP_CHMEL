using System;
using System.Collections.Generic;

// === Завдання 1: Strategy ===

public interface ICalculationStrategy
{
    int Calculate(int a, int b);
}

public class AddStrategy : ICalculationStrategy
{
    public int Calculate(int a, int b) => a + b;
}

public class SubtractStrategy : ICalculationStrategy
{
    public int Calculate(int a, int b) => a - b;
}

public class MultiplyStrategy : ICalculationStrategy
{
    public int Calculate(int a, int b) => a * b;
}

public class Calculator
{
    private ICalculationStrategy _strategy;

    public Calculator(ICalculationStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(ICalculationStrategy strategy)
    {
        _strategy = strategy;
    }

    public int Execute(int a, int b) => _strategy.Calculate(a, b);
}

// === Завдання 2: Command ===

public interface ICommand
{
    void Execute();
}

public class OpenFileCommand : ICommand
{
    public void Execute() => Console.WriteLine("Файл відкрито.");
}

public class SaveFileCommand : ICommand
{
    public void Execute() => Console.WriteLine("Файл збережено.");
}

public class CloseFileCommand : ICommand
{
    public void Execute() => Console.WriteLine("Файл закрито.");
}

public class Editor
{
    private readonly List<ICommand> _commands = new();

    public void AddCommand(ICommand command) => _commands.Add(command);

    public void Run()
    {
        foreach (var cmd in _commands)
            cmd.Execute();
    }
}

// === Завдання 3: Mediator ===

public class User
{
    public string Name { get; }
    private readonly ChatMediator _mediator;

    public User(string name, ChatMediator mediator)
    {
        Name = name;
        _mediator = mediator;
        _mediator.Register(this);
    }

    public void Send(string message)
    {
        Console.WriteLine($"{Name} надсилає: {message}");
        _mediator.Distribute(this, message);
    }

    public void Receive(string message)
    {
        Console.WriteLine($"{Name} отримав: {message}");
    }
}

public class ChatMediator
{
    private readonly List<User> _users = new();

    public void Register(User user) => _users.Add(user);

    public void Distribute(User sender, string message)
    {
        foreach (var user in _users)
        {
            if (user != sender)
                user.Receive(message);
        }
    }
}

// === Завдання 4: Observer ===

public interface IObserver
{
    void Update(string message);
}

public class WeatherStation
{
    private readonly List<IObserver> _observers = new();

    public void Subscribe(IObserver observer) => _observers.Add(observer);
    public void Unsubscribe(IObserver observer) => _observers.Remove(observer);

    public void SetTemperature(string weatherUpdate)
    {
        Console.WriteLine($"[WeatherStation]: {weatherUpdate}");
        foreach (var obs in _observers)
        {
            obs.Update(weatherUpdate);
        }
    }
}

public class PhoneApp : IObserver
{
    private readonly string _id;
    public PhoneApp(string id) => _id = id;
    public void Update(string message) => Console.WriteLine($"App {_id}: {message}");
}

public class Billboard : IObserver
{
    public void Update(string message) => Console.WriteLine($"[Білборд]: {message}");
}

// === Main ===

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Strategy ===");
        Calculator calc = new Calculator(new AddStrategy());
        Console.WriteLine("10 + 5 = " + calc.Execute(10, 5));
        calc.SetStrategy(new SubtractStrategy());
        Console.WriteLine("10 - 5 = " + calc.Execute(10, 5));
        calc.SetStrategy(new MultiplyStrategy());
        Console.WriteLine("10 * 5 = " + calc.Execute(10, 5));

        Console.WriteLine("\n=== Command ===");
        Editor editor = new Editor();
        editor.AddCommand(new OpenFileCommand());
        editor.AddCommand(new SaveFileCommand());
        editor.AddCommand(new CloseFileCommand());
        editor.Run();

        Console.WriteLine("\n=== Mediator ===");
        ChatMediator mediator = new ChatMediator();
        User alice = new User("Аліса", mediator);
        User bob = new User("Боб", mediator);
        User chris = new User("Кріс", mediator);
        alice.Send("Привіт усім!");
        bob.Send("Вітаю, Алісо!");

        Console.WriteLine("\n=== Observer ===");
        WeatherStation station = new WeatherStation();
        PhoneApp app1 = new PhoneApp("UA001");
        PhoneApp app2 = new PhoneApp("UA002");
        Billboard billboard = new Billboard();
        station.Subscribe(app1);
        station.Subscribe(app2);
        station.Subscribe(billboard);
        station.SetTemperature("Зміна погоди: +26°C, без опадів.");
    }
}
