using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpBank.Models;
using SharpBank.Services;

namespace SharpBank.CLI
{
    static class  Menu
    {
        public static void BankMenu(DataStore datastore)
        {
            Console.WriteLine("Choose Your Bank");
            foreach (Bank bank in datastore.Banks)
            {
                Console.WriteLine(bank.BankId.ToString("D10") + " | " + bank.Name);
            }
        }
        public static void LoginMenu()
        {
            Console.WriteLine("1-> Create Account");
            Console.WriteLine("2-> Login");
            Console.WriteLine("3-> Back");
            Console.WriteLine("4-> Exit");
        }
        public static void UserMenu()
        {
            Console.WriteLine("1.Deposit");
            Console.WriteLine("2.Withdraw");
            Console.WriteLine("3.Transfer");
            Console.WriteLine("4.Show Balance");
            Console.WriteLine("5.Show Transaction History");
        }
    }
}
