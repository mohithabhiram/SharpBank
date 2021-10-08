using Microsoft.EntityFrameworkCore;
using SharpBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpBank.API.Models
{
    public class AccountServices : IAccountServices
    {
        private readonly AppDbContext appDbContext;

        public AccountServices(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Account> AddAccount(Account account)
        {
            var result = await appDbContext.Accounts.AddAsync(account);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Account> GetAccount(string AccountNumber)
        {
            return await appDbContext.Accounts.FirstOrDefaultAsync(
                a => a.AccountNumber == AccountNumber);
        }

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return await appDbContext.Accounts.ToListAsync();
        }
        public async void DeleteAccount(string accountNumber) {
            var result = await appDbContext.Accounts.FirstOrDefaultAsync(
                a => a.AccountNumber == accountNumber);
            if (result != null) 
            {
                appDbContext.Accounts.Remove(result);
                await appDbContext.SaveChangesAsync();           
            }
        }
    }
}
