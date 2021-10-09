using Microsoft.EntityFrameworkCore;
using SharpBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpBank.API.Models
{
    public class BankServices:IBankServices
    {
        private readonly AppDbContext appDbContext;

        public BankServices(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Bank> GetBank(string IFSC)
        {
            return await appDbContext.Banks.FirstOrDefaultAsync(b=> b.IFSC == IFSC);
        }

        public async Task<IEnumerable<Bank>> GetBanks()
        {
            return await appDbContext.Banks.ToListAsync();
        }
    }
}
