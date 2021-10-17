using SharpBank.Models;
using SharpBank.Services;
using SharpBank.Models.Exceptions;
using SharpBank.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.CLI.Controllers
{
    static class AccountsController
    {
        public static AccountService accountService;
        public static long CreateAccount(long bankId)
        {
            long id = 0;
            try
            {
                string name = Inputs.GetName();
                string password = Inputs.GetPassword();
                Gender gender = Inputs.GetGender();
                id = accountService.AddAccount(name, password, bankId, gender);
            }
            catch (AccountNumberException e)
            {

                Console.WriteLine("Account Number already exists.");
            }
            catch(Exception e)
            {
                Console.WriteLine("Internal Error");
            }
            return id;
        }
        public static Account GetAccount(long bankId, long accountId)
        {

            try
            {
                Account acc=accountService.GetAccount(bankId,accountId);
                if(acc==null)
                {
                    throw new AccountNumberException();
                }
                return acc;
            }
            catch (AccountNumberException e)
            {

                Console.WriteLine("Account  doesnot  exist.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Internal Error");
            }
            return null;
        }
        public static decimal GetBalance(long bankId, long accountId)
        {
            try
            {
                Account acc = accountService.GetAccount(bankId, accountId);
                if (acc == null)
                {
                    throw new AccountNumberException();
                }
                return acc.Balance;
            }
            catch (AccountNumberException e)
            {

                Console.WriteLine("Account  doesnot  exist.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Internal Error");
            }
            return -1m;
        }
        public static List<Transaction> GetTransactionHistory(long bankId, long accountId)
        {
            List<Transaction> transactions = new List<Transaction>();
            try
            {
                transactions = accountService.GetAccount(bankId, accountId).Transactions.ToList();
                return transactions;
            }
            catch (Exception)
            {
                Console.WriteLine("Internal Error");
            }
            return null;
        }
    }
}
