﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpBank.Models;
using SharpBank.Models.Exceptions;
using SharpBank.Models.Enums;

namespace SharpBank.Services
{
    public  class TransactionService
    {
        public AccountService accountService;
        public TransactionService(AccountService accountService)
        {
            this.accountService = accountService;
        }
        public long AddTransaction(long sourceBankId, long sourceAccountId, long destinationBankId, long destinationAccountId, decimal amount)
        {
            Transaction transaction = new Transaction
            {
                TransactionId = GenerateId(sourceBankId, sourceAccountId, destinationBankId, destinationAccountId),
                SourceAccountId = sourceAccountId,
                SourceBankId = sourceBankId,
                DestinationAccountId = destinationAccountId,
                DestinationBankId = destinationBankId,
                Amount = amount,
                Type = Models.Enums.TransactionType.Credit,
                On = DateTime.Now
            };
            accountService.GetAccount(sourceBankId, sourceAccountId).Transactions.Add(transaction);
            accountService.GetAccount(destinationBankId, destinationAccountId).Transactions.Add(transaction);
            return transaction.TransactionId;
        }
        public long GenerateId(long sourceBankId, long sourceAccountId, long destinationBankId, long destinationAccountId)
        {
            Random rand = new Random(123);
            Account sourceAccount = accountService.GetAccount(sourceBankId, sourceAccountId);
            Account destinationAccount = accountService.GetAccount(destinationBankId, destinationAccountId);

            long Id;
            do
            {
                Id = rand.Next();
            }

            while ((sourceAccount.Transactions.SingleOrDefault(t => t.TransactionId == Id) != null) ||
                    (destinationAccount.Transactions.SingleOrDefault(t => t.TransactionId == Id) != null));
            return Id;
        }

        //public string GenerateTransactionId(string sourceBankId, string sourceAccountId)
        //{

        //}


        public Transaction GetTransaction(long bankId, long accountId, long TransactionId)
        {
            Account account = accountService.GetAccount(bankId, accountId);
            var transaction = account.Transactions.SingleOrDefault(t => t.TransactionId == TransactionId);
            return transaction;
        }

    }
}
