using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Models
{
    public class Transaction
    {
        public Transaction()
        {

        }
        public Transaction(int from, int to, double amount)
        {
            this.From = from;
            this.To = to;
            this.Amount = amount;
        }
        [Key]
        public int Id { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public double Amount { get; set; }
    }
}
