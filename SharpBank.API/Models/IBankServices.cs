using SharpBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpBank.API.Models
{
    public interface IBankServices
    {
        IEnumerable<Bank> GetBanks();
        Bank GetBank(string IFSC);
    }
}
