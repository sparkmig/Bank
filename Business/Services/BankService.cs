using Storage.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class BankService
    {
        public double Capital()
        {
            using (var ctx = new PengeinstitutContext())
            {
                return ctx.Accounts.ToList().Select(acc => acc.Amount).Sum();
            }
        }
    }
}
