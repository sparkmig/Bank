using Business.Services;
using Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pengeinstitut
{
    public class Login
    {
        public static Storage.Models.User user;
        static void Main(string[] args)
        {
            Console.WriteLine("Velkommen til Danske bank");
            Console.WriteLine("Loading");
            for (int i = 0; i < 20; i++)
            {
                Console.Write(".");
                Thread.Sleep(20);
            }
            Console.Clear();

            while (true)
            {
                Console.Write("Brugernavn: ");
                string username = Console.ReadLine();

                Console.Write("Adgangskode: ");
                string password = Console.ReadLine();

                user = new LoginService().Login(username, password);

                Console.Clear();
                
                if (user != null)
                {
                    Console.WriteLine($"Velkommen {Login.user.Name}");
                    Thread.Sleep(1000);
                    Console.Clear();
                }

                while (user != null)
                {
                    LandingPage.Show();
                }
            }
        }
    }
}
