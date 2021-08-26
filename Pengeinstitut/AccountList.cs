using Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pengeinstitut
{
    public static class AccountList
    {
        public static void Show(Storage.Models.Customer customer)
        {
            var accountService = new AccountService();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-1) Tilbage");
                Console.WriteLine("---------------------------------------");
                var accounts = accountService.GetAccounts(customer.Id);

                for (int i = 0; i < accounts.Count; i++)
                {
                    var account = accounts[i];
                    Console.WriteLine($"{i}) {account.Name} {account.Amount}");
                }
                Console.WriteLine($"{accounts.Count}) Tilføj Konto");

                int input = int.Parse(Console.ReadLine());

                if (input == -1) 
                    return;
                else if 
                    (input == accounts.Count) Account.Add(customer.Id);
                else 
                    Account.Show(customer, accounts[input].Id);

            }

        }
    }
}
