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
        public static void Capital()
        {
            var bankService = new BankService();
            double capital = bankService.Capital();

            Console.Clear();
            Console.WriteLine("-1) Tilbage");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"Kapital: {capital}");

            string input = Console.ReadLine();

            if (input == "-1") return;
        }
    }
}
