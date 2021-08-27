using Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pengeinstitut
{
    public static class BankInfo
    {
        public static void Show()
        {
            while (true)
            {
                var bankService = new BankService();
                var accountService = new AccountService();
                var customerService = new CustomerService();

                int customerCount = customerService.CustomerCount();
                int accountCount = accountService.AccountsCount();
                double capital = bankService.Capital();

                Console.Clear();
                Console.WriteLine("-1) Tilbage");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine($"Navn: Danske Bank");
                Console.WriteLine($"Kapital: {capital}");
                Console.WriteLine($"Antal Kunder: {customerCount}");
                Console.WriteLine($"Antal Konti: {accountCount}");

                string input = Console.ReadLine();

                if (input == "-1") return;
            }
           
        }
    }
}
