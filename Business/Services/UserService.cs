using Storage.Context;
using Storage.Enums;
using Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class UserService
    {
        public List<User> GetUsers() => new PengeinstitutContext().Users.ToList();
        public User GetUser(int id) => new PengeinstitutContext().Users.Find(id);
        public void DeleteUser(int id)
        {
            using (var ctx = new PengeinstitutContext())
            {
                var user = ctx.Users.Find(id);
                ctx.Users.Remove(user);

                ctx.SaveChanges();
            }
        }
        public void AddUser(string name, string username, string password, UserRight userRight)
        {
            var user = new User(name, username, password, userRight);

            using (var ctx = new PengeinstitutContext())
            {
                ctx.Users.Add(user);
                ctx.SaveChanges();

                return;
            }
        }
    }
}
