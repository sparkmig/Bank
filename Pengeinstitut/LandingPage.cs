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
        public static void Show()
        {
            Console.WriteLine("0) Log ud");
            Console.WriteLine("---------------------------------------");

            Console.WriteLine("1) Vis kunder");
            Console.WriteLine("2) Info om banken");
            Console.WriteLine("3) Vis Brugere");

            string input = Console.ReadLine();

            switch (input)
            {
                case "0":
                    Login.user = null;
                    break;
                case "1":
                    CustomerList.Show();
                    break;
                case "2":
                    BankInfo.Show();
                    break;
                case "3":
                    UserList.Show();
                    break;
                default:
                    break;
            }
            Console.Clear();
        }
    }
}
