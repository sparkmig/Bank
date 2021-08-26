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
                Console.WriteLine("--------------------");
                Console.WriteLine("1) Indsæt penge på konto");
                Console.WriteLine("2) Hæv penge fra konto");
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
    }
}
