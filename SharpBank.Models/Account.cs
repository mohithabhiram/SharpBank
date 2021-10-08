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
        private string accountNumber;
        [Key]
        public string AccountNumber 
        {
            get;
            set;
        }
        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private decimal balance;
        public decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public Account()
        {
        }
    }
}
