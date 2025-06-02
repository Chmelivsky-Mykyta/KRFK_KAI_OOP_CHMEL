using System;
using System.Threading;
using System.Threading.Tasks;

class BankAccount
{
    private int _balance = 0;
    private readonly object _lock = new object();

    public async Task DepositAsync(int amount)
    {
        await Task.Delay(500); // Імітація затримки
        lock (_lock)
        {
            _balance += amount;
            Console.WriteLine($"Поповнення +{amount}");
        }
    }

    public async Task WithdrawAsync(int amount)
    {
        await Task.Delay(500); // Імітація затримки
        lock (_lock)
        {
            if (_balance >= amount)
            {
                _balance -= amount;
                Console.WriteLine($"Зняття -{amount}");
            }
            else
            {
                Console.WriteLine($"Зняття -{amount} (недостатньо коштів)");
            }
        }
    }

    public int GetBalance()
    {
        lock (_lock)
        {
            return _balance;
        }
    }
}

class Program
{
    static async Task Main()
    {
        BankAccount account = new BankAccount();

        Task t1 = account.DepositAsync(200);
        Task t2 = account.WithdrawAsync(100);
        Task t3 = account.DepositAsync(300);
        Task t4 = account.WithdrawAsync(50);

        await Task.WhenAll(t1, t2, t3, t4);

        Console.WriteLine($"Фінальний баланс: {account.GetBalance()}");
    }
}
