using Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pengeinstitut
{
    public static class LandingPage
    {
        public static void Show(User user)
        {
            Console.WriteLine($"Velkommen {user.Name}");
            Thread.Sleep(1000);
            while (true)
            {
                Console.Clear();

                Console.WriteLine("1) Vis kunder");
                Console.WriteLine("2) Samlet kapital");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CustomerList.Show();
                        break;
                    case "2":
                        BankInfo.Capital();
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
        }
    }
}
