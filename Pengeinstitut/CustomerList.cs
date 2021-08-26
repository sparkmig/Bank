using Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pengeinstitut
{
    public static class CustomerList
    {
        public static void Show()
        {
            var customerService = new CustomerService();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("-1) Tilbage");
                Console.WriteLine("---------------------------------------");

                var customers = customerService.GetCustomers();

                for (int i = 0; i < customers.Count; i++)
                {
                    var customer = customers[i];
                    Console.WriteLine($"{i}) {customer.FirstName} {customer.LastName} - {customer.CPR}");
                }

                Console.WriteLine($"{customers.Count}) Tilføj Konto");

                int input = int.Parse(Console.ReadLine());

                if (input == -1)
                    return;
                else if (input == customers.Count)
                    Customer.Add();
                else
                    Customer.Show(customers[input].Id, customerService);
            }
        }
    }
}
