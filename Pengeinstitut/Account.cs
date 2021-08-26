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

                double amount;

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
                        Console.WriteLine("Hvor mange penge ville du indsætte?");
                        amount = double.Parse(Console.ReadLine());
                        accountService.AddMoneyToAccount(account.Id, amount);
                        Console.WriteLine("Pengene blev indsat!");
                        Thread.Sleep(1000);
                        break;
                    case "2":
                        Console.WriteLine("Hvor mange penge ville du hæve?");
                        amount = double.Parse(Console.ReadLine());
                        accountService.WithdrawMoney(account.Id, amount);
                        Console.WriteLine("Penge hævet");
                        Thread.Sleep(1000);
                        break;
                    case "3":
                        Transfer(id, account.Amount, accountService);
                        break;
                    case "slet":
                        Console.WriteLine("sletter....");
                        accountService.Delete(id);
                        Console.WriteLine("Slettet!");
                        Thread.Sleep(1000);
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

        public static void Transfer(int accountId, double balance, AccountService accountService)
        {
            Console.WriteLine("-1) Tilbage");
            Console.WriteLine("---------------------------------------");
            Console.Write("Indtast kontonummer du vile overføre til: ");

            int to = int.Parse(Console.ReadLine());

            if (to == -1) return;

            while (!accountService.DoesAccountExist(to))
            {
                Console.Write("Kontonummer udgyldigt, prøv igen:");
                to = int.Parse(Console.ReadLine());
                if (to == -1) return;
            }

            Console.Write($"Beløb (Max {balance}): ");
            double amount = double.Parse(Console.ReadLine());

            while (amount > balance && amount > 0)
            {
                Console.WriteLine("Beløb ikke gyldigt, prøv igen");

                Console.Write($"Beløb (Max {balance}): ");
                amount = double.Parse(Console.ReadLine());

                if (amount == -1) return;
            }

            new AccountService().Transfer(accountId, to, amount);
        }
    }
}
