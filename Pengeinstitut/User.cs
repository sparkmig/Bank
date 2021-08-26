using Business.Services;
using Storage.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pengeinstitut
{
    public static class User
    {
        public static void Show(int id, UserService userService)
        {
            while (true)
            {
                var user = userService.GetUser(id);

                Console.Clear();
                Console.WriteLine("-1) Tilbage");
                Console.WriteLine("---------------------------------");
                Console.WriteLine($"Navn: {user.Name}");
                Console.WriteLine($"Brugernavn: {user.UserName}");
                Console.WriteLine($"Rettigheder: {user.UserRight}");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("slet) Slet Bruger");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "slet":
                        userService.DeleteUser(id);
                        return;
                    case "-1":
                        return;
                    default:
                        break;
                }

            }
        }

        public static void Add(UserService userService)
        {
            while (true)
            {
                Console.Write("Navn: ");
                string name = Console.ReadLine();

                Console.Write("Brugernavn: ");
                string username = Console.ReadLine();

                Console.Write("Password: ");
                string password = Console.ReadLine();

                Console.Write("Brugerrettighed (0 = normal, 1 = admin): ");
                UserRight userRight = (UserRight)int.Parse(Console.ReadLine());

                userService.AddUser(name, username, password, userRight);

                Console.WriteLine("Bruger tilføjet!");
                Thread.Sleep(1000);
                return;
            }
        }
    }
}
