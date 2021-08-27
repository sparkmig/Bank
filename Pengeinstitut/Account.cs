using Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pengeinstitut
{
    public static class Account
    {
        public static void Show(Storage.Models.Customer customer, int id)
        {
            var accountService = new AccountService();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("-1) Tilbage");
                Console.WriteLine("---------------------------------------");

                var account = accountService.GetAccount(id);

                Console.WriteLine($"{customer.FirstName} {customer.LastName} - {account.Name}");
                Console.WriteLine($"Penge: {account.Amount}");
                Console.WriteLine($"Kontonr.: {account.Id}");
                Console.WriteLine("--------------------");
                Console.WriteLine("1) Indsæt penge på konto");
                Console.WriteLine("2) Hæv penge fra konto");
                Console.WriteLine("3) Overfør Penge");
                Console.WriteLine("slet) Slet konto");

                string input = Console.ReadLine();

                if (input == "-1") return;

                switch (input)
                {
                    case "1":
                        Deposit(account, accountService);
                        break;
                    case "2":
                        Withdraw(account, accountService);
                        break;
                    case "3":
                        Transfer(id, account.Amount, accountService);
                        break;
                    case "slet":
                        Delete(id, accountService);
                        return;
                    default:
                        break;
                }
            }
        }

        public static void Add(int customerId)
        {
            Console.WriteLine("Navn på konto: ");
            string name = Console.ReadLine();

            new AccountService().Add(customerId, name);
        }
        private static void Delete(int accountId, AccountService accountService)
        {
            Console.WriteLine("Sletter....");
            accountService.Delete(accountId);
            Console.WriteLine("Slettet!");
            Thread.Sleep(1000);
        }
        private static void Transfer(int accountId, double balance, AccountService accountService)
        {
            Console.WriteLine("-1) Tilbage");
            Console.WriteLine("---------------------------------------");
            Console.Write("Indtast kontonummer du vile overføre til: ");

            _ = int.TryParse(Console.ReadLine(), out int to);
            if (to == -1) return;

            while (!accountService.DoesAccountExist(to))
            {
                Console.Write("Kontonummer udgyldigt, prøv igen:");
                _ = int.TryParse(Console.ReadLine(), out to);
                if (to == -1) return;
            }

            Console.Write($"Beløb (Max {balance}): ");
            _ = double.TryParse(Console.ReadLine(), out double amount);

            while (amount > balance || amount <= 0)
            {
                if (amount == -1) return;

                Console.WriteLine("Beløb ikke gyldigt, prøv igen");

                Console.Write($"Beløb (Max {balance}): ");
                _ = double.TryParse(Console.ReadLine(), out amount);

            }

            accountService.Transfer(accountId, to, amount);
        }

        private static void Withdraw(Storage.Models.Account account, AccountService accountService)
        {
            Console.WriteLine("Hvor mange penge ville du hæve?");
            
            double amount;
            _ = double.TryParse(Console.ReadLine(), out amount);

            while (amount > account.Amount || amount <= 0)
            {
                if (amount == -1) return;

                Console.WriteLine("Ugyldigt beløb, prøv igen!");
                _ = double.TryParse(Console.ReadLine(), out amount);
            }

            accountService.WithdrawMoney(account.Id, amount);
            Console.WriteLine("Penge hævet");
            Thread.Sleep(1000);
        }
        private static void Deposit(Storage.Models.Account account, AccountService accountService)
        {

            Console.WriteLine("Hvor mange penge ville du indsætte?");

            double amount;
            _ = double.TryParse(Console.ReadLine(), out amount);
            
            while (amount <= 0)
            {
                if (amount == -1) return;

                Console.WriteLine("Ugyldigt beløb, prøv igen!");
                double.TryParse(Console.ReadLine(), out amount);
            }

            accountService.AddMoneyToAccount(account.Id, amount);
            Console.WriteLine("Pengene blev indsat!");
            Thread.Sleep(1000);
        }
    }
}
