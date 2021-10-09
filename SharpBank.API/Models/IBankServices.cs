using SharpBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpBank.API.Models
{
    public interface IBankServices
    {
        Task<IEnumerable<Bank>> GetBanks();
        Task<Bank> GetBank(string IFSC);
    }
}
