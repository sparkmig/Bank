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
        public List<Account> GetAccounts() => new PengeinstitutContext().Accounts.ToList();
        public int AccountsCount() => new PengeinstitutContext().Accounts.Count();
        public List<Transaction> GetTransactions(int id) => new PengeinstitutContext().Transactions.Where(o => o.From == id || o.To == id).ToList();

        public void DepositMoney(int id, double amount)
        {
            Transaction transaction = new Transaction(id, -1, amount);

            using (var ctx = new PengeinstitutContext())
            {
                var account = ctx.Accounts.Find(id);
                account.Amount += amount;

                ctx.Transactions.Add(transaction);

                ctx.SaveChanges();
            }
        }
        public void WithdrawMoney(int id, double amount)
        {
            Transaction transaction = new Transaction(id, -2, amount);
            using (var ctx = new PengeinstitutContext())
            {
                var account = ctx.Accounts.Find(id);
                account.Amount -= amount;

                ctx.Transactions.Add(transaction);

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
        public void Transfer(int from, int to, double amount)
        {
            Transaction transaction = new Transaction(from, to, amount);

            using (var ctx = new PengeinstitutContext())
            {
                var fromAccount = ctx.Accounts.Find(from);
                var toAccount = ctx.Accounts.Find(to);

                fromAccount.Amount -= amount;
                toAccount.Amount += amount;

                ctx.Transactions.Add(transaction);

                ctx.SaveChanges();
            }
        }

        public bool DoesAccountExist(int id)
        {
            using (var ctx = new PengeinstitutContext())
            {
                return ctx.Accounts.Any(o => o.Id == id);
            }
        }
    }
}
