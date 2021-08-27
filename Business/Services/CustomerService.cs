using Storage.Context;
using Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class CustomerService
    {
        public List<Customer> GetCustomers() => new PengeinstitutContext().Customers.ToList();

        public void DeleteCustomer(int id)
        {
            using (var ctx = new PengeinstitutContext())
            {
                var account = ctx.Customers.Find(id);
                ctx.Customers.Remove(account);
                ctx.SaveChanges();
            }
        }

        public int CustomerCount() => new PengeinstitutContext().Customers.Count();

        public Customer FindCustomer(int id)
        {
            using (var ctx = new PengeinstitutContext())
            {
                return ctx.Customers.Find(id);
            }
        }
        public void Add(string firstname, string lastName,  string cpr, string password, DateTime birthday, string phone)
        {
            var customer = new Customer(firstname, lastName, cpr, password, birthday, phone);

            using (var ctx = new PengeinstitutContext())
            {
                ctx.Customers.Add(customer);

                ctx.SaveChanges();
            }
        }
    }
}
