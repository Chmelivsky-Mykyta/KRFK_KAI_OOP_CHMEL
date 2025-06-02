using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DIConsoleApp
{
    // 1. Інтерфейс IGreetingService
    public interface IGreetingService
    {
        void Greet(string name);
    }

    // 2. Реалізація GreetingService
    public class GreetingService : IGreetingService
    {
        public void Greet(string name)
        {
            Console.WriteLine($"Привіт, {name}!");
        }
    }

    // 3. Клас App, який залежить від IGreetingService
    public class App
    {
        private readonly IGreetingService _greeting;

        public App(IGreetingService greeting)
        {
            _greeting = greeting;
        }

        public void Run()
        {
            Console.Write("Введіть ім’я: ");
            string name = Console.ReadLine();
            _greeting.Greet(name);
        }
    }

    // 4. Program.cs з DI через Host
    class Program
    {
        static void Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddTransient<IGreetingService, GreetingService>();
                    services.AddTransient<App>();
                })
                .Build();

            var app = host.Services.GetRequiredService<App>();
            app.Run();
        }
    }
}
