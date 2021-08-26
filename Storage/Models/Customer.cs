using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Models
{
    public class Customer
    {
        public Customer()
        {

        }
        public Customer(string firstname, string lastName, string cpr, string password, DateTime birthday, string phone)
        {
            this.FirstName = firstname;
            this.LastName = lastName;
            this.CPR = cpr;
            this.Password = password;
            this.Birthday = birthday;
            this.Phone = phone;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Password { get; set; }
        public string CPR { get; set; }
        public string Phone { get; set; }
    }
}
