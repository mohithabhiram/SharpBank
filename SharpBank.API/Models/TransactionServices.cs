using Microsoft.EntityFrameworkCore;
using SharpBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpBank.API.Models
{
    public class TransactionServices : ITransactionServices
    {
        private readonly AppDbContext appDbContext;

        public TransactionServices(AppDbContext appDbContext) {
            this.appDbContext = appDbContext;
        }

        public async Task<Transaction> AddTransaction(Transaction transaction)
        {
            var result = await appDbContext.Transactions.AddAsync(transaction);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Transaction> GetTransaction(string TransactionID)
        {
            return await appDbContext.Transactions.FirstOrDefaultAsync(e=>e.TransactionID==TransactionID);
        }

        public async Task<IEnumerable<Transaction>> GetTransactions()
        {
            return await appDbContext.Transactions.ToListAsync();
        }
    }
}
