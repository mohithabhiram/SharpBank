using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.Models
{
    public class Bank
    {
        public string ImagePath { get; set; }
        private string bankName;
        public string BankName
        {
            get { return bankName; }
            set { bankName = value; }
        }
        private string ifsc;
        [Key]
        public string IFSC
        {
            get;
            set;
        }
        private Dictionary<string, Account> accounts;
        

        public Bank()
        {
            
        }

        public Account getAccount(string id)
        {
            return accounts[id];
        }

        public void addAccount(Account acc)
        {
            accounts.Add(acc.AccountNumber,acc);
        }

        public void setAccount(string id,Account acc) {
            accounts[id] = acc;
        }

        public void RemoveAccount(string accountNumber)
        {
            accounts.Remove(accountNumber);
        }
        public int Count { get { return accounts.Count;} }
        
    }
}
