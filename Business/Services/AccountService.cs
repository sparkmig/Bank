using Storage.Context;
using Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class AccountService
    {
        public List<Account> GetAccounts(int id) => new PengeinstitutContext().Accounts.Where(o => o.Owner == id).ToList();
        public void AddMoneyToAccount(int id, double amount)
        {
            using (var ctx = new PengeinstitutContext())
            {
                var account = ctx.Accounts.Find(id);
                account.Amount += amount;

                ctx.SaveChanges();
            }
        }
        public void WithdrawMoney(int id, double amount)
        {
            using (var ctx = new PengeinstitutContext())
            {
                var account = ctx.Accounts.Find(id);
                account.Amount -= amount;

                ctx.SaveChanges();
            }
        }
        public Account GetAccount(int id)
        {
            using (var ctx = new PengeinstitutContext())
            {
                return ctx.Accounts.Find(id);
            }
        }

        public void Add(int customerId, string name)
        {
            var account = new Account(customerId, name);

            using (var ctx = new PengeinstitutContext())
            {
                ctx.Accounts.Add(account);
                ctx.SaveChanges();
            }
        }
        public void Delete(int customerId)
        {
            using (var ctx = new PengeinstitutContext())
            {
                var account = ctx.Accounts.Find(customerId);
                ctx.Accounts.Remove(account);

                ctx.SaveChanges();
            }
        }
    }
}
