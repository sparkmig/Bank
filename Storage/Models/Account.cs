using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Models
{
    public class Account
    {
        public Account()
        {

        }
        public Account(int customerId, string name)
        {
            this.Owner = customerId;
            this.Name = name;
        }
        [Key]
        public int Id { get; set; }
        public int Owner { get; set; }
        public double Amount { get; set; }
        public string Name { get; set; }
    }
}
