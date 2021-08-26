using Storage.Context;
using Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class LoginService
    {
        public User Login(string username, string password)
        {
            using (var ctx = new PengeinstitutContext())
            {
                return ctx.Users.FirstOrDefault(o => o.UserName == username && o.Password == password);
            }
        }
    }
}
