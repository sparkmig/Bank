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
    public static class Customer
    {
        public static void Show(int id, CustomerService service)
        {
            while (true)
            {
                Console.Clear();
                Storage.Models.Customer customer =  service.FindCustomer(id);
                Console.WriteLine("-1) Tilbage");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine($"Navn: {customer.FirstName} {customer.LastName}");
                Console.WriteLine($"CPR: {customer.CPR}");
                Console.WriteLine($"Fødselsdag: {customer.Birthday}");
                Console.WriteLine($"Telefonnr.: {customer.Phone}");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("1) Vis konti");
                Console.WriteLine("slet) Slet kunde");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AccountList.Show(customer);
                        break;
                    case "-1":
                        return;
                    case "slet":
                        service.DeleteCustomer(id: customer.Id);
                        Console.WriteLine("Slettet");
                        Thread.Sleep(1000); 
                        return;
                    default:
                        break;
                }
            }
        }

        public static void Add()
        {
            Console.Write("Fornavn: ");
            string firstName = Console.ReadLine();

            Console.Write("Efternavn: ");
            string lastName = Console.ReadLine();

            Console.Write("Fødselsdag: ");
            DateTime birthday = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Cpr: ");
            string cpr = Console.ReadLine();

            Console.Write("Telefonnr.: ");
            string phone = Console.ReadLine();

            new CustomerService().Add(firstName, lastName, cpr, "skiftmig", birthday, phone);

            Console.WriteLine("Kunde tilføjet");
        }
    }
}
