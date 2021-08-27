using Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pengeinstitut
{
    public static class TransactionList
    {
        public static void Show(int accountId, AccountService accountService)
        {
            while (true)
            {
                Console.Clear();
                var transactions = accountService.GetTransactions(accountId).OrderByDescending(o => o.Id);
                Console.WriteLine("-1) Tilbage");
                Console.WriteLine("---------------------------------------");

                foreach (var transaction in transactions)
                {
                    if (transaction.To == -1)
                    {
                        Console.WriteLine("Fra: Hæveautomat");
                        Console.Write($"Beløb: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(transaction.Amount);

                    }
                    else if (transaction.To == -2)
                    {

                        Console.WriteLine("Til: Hæveautomat");
                        Console.Write($"Beløb: -");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(transaction.Amount);

                    }
                    else if (transaction.From == accountId)
                    {
                        Console.WriteLine($"Til: {transaction.To}");
                        Console.Write($"Beløb: -");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(transaction.Amount);

                    }
                    else
                    {
                        Console.WriteLine($"Fra: {transaction.From}");
                        Console.Write($"Beløb: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(transaction.Amount);
                    }
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("\n------------------");
                }


                string input = Console.ReadLine();
                if (input == "-1") return;
            }
        }
    }
}
