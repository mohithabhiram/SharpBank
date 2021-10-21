using SharpBank.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.Models
{
    public class Account
    {
        public long AccountId { get; set; }
        public string BankId { get; set; }
        public decimal Balance { get; set; }
        public AccountHolder User { get; set; }
        public Status Status { get; set; }
        public List<Transaction> Transactions { get; set; }

    }
}