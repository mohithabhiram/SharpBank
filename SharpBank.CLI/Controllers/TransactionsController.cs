using SharpBank.Models;
using SharpBank.Models.Exceptions;
using SharpBank.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpBank.Models.Enums;

namespace SharpBank.CLI.Controllers
{
    class TransactionsController
    {
        private TransactionService transactionService;
        private AccountService accountService;

        public TransactionsController(TransactionService transactionService, AccountService accountService)
        {
            this.transactionService = transactionService;
            this.accountService = accountService;
        }
        public long Withdraw(string bankId, string accountId, decimal amount)
        {
            long id = 0;
            try
            {
                id = transactionService.AddTransaction(bankId, accountId, "", "", amount,TransactionType.Debit);
            }
            catch (BalanceException)
            {
                Console.WriteLine("Insufficient Balance");
            }
            catch (Exception)
            {
                Console.WriteLine("Internal Error");

            }
            return id;
        }
        public long Deposit(string bankId, string accountId, decimal amount)
        {

            long id = 0;
            try
            {
                id = transactionService.AddTransaction("", "", bankId, accountId, amount, TransactionType.Credit);
            }
            catch (BalanceException)
            {
                Console.WriteLine("Insufficient Balance");
            }
            catch (Exception)
            {
                Console.WriteLine("Internal Error");

            }
            return id;
        }
        public long Transfer(string sourceBankId, string sourceAccountId, string destinationBankId, string destinationAccountId, decimal amount)
        {
            long id = 0;
            try
            {
                id = transactionService.AddTransaction(sourceBankId, sourceAccountId, destinationBankId, destinationAccountId, amount,TransactionType.Transfer);
            }
            catch (BalanceException)
            {
                Console.WriteLine("Insufficient Balance");
            }
            catch (Exception)
            {
                Console.WriteLine("Internal Error");

            }
            return id;
        }
    }
}
