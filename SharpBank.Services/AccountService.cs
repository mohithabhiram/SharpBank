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
        public AccountService(BankService bankService)
        {
            this.bankService = bankService;
            Account acc = new Account
            {
                Name = "",
                Gender = Gender.Male,
                AccountId = 0,
                BankId = "",
                Balance = 0m,
                Status = Status.Active,
                Transactions = new List<Transaction>()
            };
            bankService.GetBank("").Accounts.Add(acc);
        }
        public long AddAccount(String name, String password, string bankId, Gender gender)
        {
            Account account = new Account
            {
                AccountId = GenerateId(bankId),
                BankId = bankId,
                Name = name,
                Password = password,
                Balance = 0m,
                Gender = gender,
                Status = Models.Enums.Status.Active,
                Transactions = new List<Transaction>()
            };
            bankService.GetBank(bankId).Accounts.Add(account);
            return account.AccountId;
        }
        public long GenerateId(string bankId)
        {
            Random rand = new Random(321);
            Bank bank = bankService.GetBank(bankId);
            long Id;
            do
            {
                Id = rand.Next();
            }

            while (bank.Accounts.SingleOrDefault(a => a.AccountId == Id) != null);
            return Id;
        }
        //public string GenerateAccountId(string name)
        //{
        //    DateTime d = DateTime.Now;
        //    string date = DateTime.Now.ToString("ddMMyy");
        //    return name.Substring(0, 3) + date;
        //}



        public Account GetAccount(string bankId, long accountId)
        {
            return bankService.GetBank(bankId).Accounts.SingleOrDefault(a => a.AccountId == accountId);
        }

        public void UpdateBalance(string bankId, long accountId, decimal balance)
        {
            Account acc = GetAccount(bankId, accountId);
            acc.Balance = balance;

        }

    }
}