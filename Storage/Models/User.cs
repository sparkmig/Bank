using Storage.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Models
{
    public class User
    {
        public User()
        {

        }
        public User(string name, string username, string password, UserRight userRight)
        {
            this.Name = name;
            this.UserName = username;
            this.Password = password;
            this.UserRight = userRight;
        }
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public UserRight UserRight { get; set; }
    }
}
