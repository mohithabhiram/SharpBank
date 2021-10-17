using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpBank.Models;
using SharpBank.Models.Enums;
using SharpBank.Models.Exceptions;

namespace SharpBank.Services
{
    public class AccountService
    {
        public BankService bankService;
        public long AddAccount(String name, String password, long BankId, Gender gender)
        {
            Account account = new Account
            {
                AccountId = GenerateId(BankId),
                Name = name,
                Password = name,
                Balance = 0m,
                Gender = gender,
                Status = Models.Enums.Status.Active,
                Transactions = new List<Transaction>()
            };
            Bank bank = DataStore.Banks.FirstOrDefault(b => b.BankId == BankId);
            bank.Accounts.Add(account);
            return account.AccountId;
        }
        public long GenerateId(long BankId)
        {
            Random rand = new Random();
            long Id = rand.Next(); ;
            Bank bank = DataStore.Banks.FirstOrDefault(b => b.BankId == BankId);
            while (bank.Accounts.SingleOrDefault(acc => acc.AccountId == Id) != null)
            {
                Id = rand.Next();
            }

            return Id;
        }
        public Account GetAccount(long bankId, long accountId)
        {
            return bankService.GetBank(bankId).Accounts.SingleOrDefault(a => a.AccountId == accountId);
        }

        public void UpdateBalance(long BankId, long AccountId, decimal Balance)
        {
            Bank bank = DataStore.Banks.FirstOrDefault(b => b.BankId == BankId);
            Account acc = bank.Accounts.SingleOrDefault(acc => acc.AccountId == AccountId);
            acc.Balance = Balance;

        }

    }
}