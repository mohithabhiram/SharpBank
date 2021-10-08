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

        public Bank GetBank(string IFSC)
        {
            return appDbContext.Banks.FirstOrDefault(b=> b.IFSC == IFSC);
        }

        public IEnumerable<Bank> GetBanks()
        {
            throw new NotImplementedException();
        }
    }
}
