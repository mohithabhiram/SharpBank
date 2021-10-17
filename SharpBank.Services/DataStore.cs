using SharpBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.Services
{
    static class  DataStore
    {
        public static List<Bank> Banks { get; set; }
        public static List<Account> Accounts { get; set; }
        public static List<Transaction> Transactions { get; set; }
        
    }
}
