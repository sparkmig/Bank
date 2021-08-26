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
    public static class UserList
    {
        public static void Show()
        {
            while (true)
            {
                Console.Clear();
                if (Login.user.UserRight < UserRight.Admin)
                {
                    Console.WriteLine("Du har ikke adgang...");
                    Thread.Sleep(2000);
                    return;
                }

                var userService = new UserService();

                var users = userService.GetUsers();

                for (int i = 0; i < users.Count; i++)
                {
                    Console.WriteLine($"{i}) {users[i].Name} ({users[i].UserName})");
                }
                Console.WriteLine("--------------------------");
                Console.WriteLine($"{users.Count}) Tilføj bruger");
                int input = int.Parse(Console.ReadLine());

                if (input == -1) return;
                else if (input == users.Count) User.Add(userService);
                else User.Show(users[input].Id, userService);

            }
        }
    }
}
