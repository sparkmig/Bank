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
        static User user;
        static void Main(string[] args)
        {
            Console.WriteLine("Velkommen til Danske bank");
            Thread.Sleep(1000);
            Console.Clear();

            while (true)
            {
                Console.Write("Brugernavn: ");
                string username = Console.ReadLine();

                Console.Write("Adgangskode: ");
                string password = Console.ReadLine();

                user = new LoginService().Login(username, password);

                if(user != null)
                {
                    LandingPage.Show(user);
                }
            }
        }
    }
}
