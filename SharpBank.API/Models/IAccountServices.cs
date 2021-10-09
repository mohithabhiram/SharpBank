using SharpBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpBank.API.Models
{
    public interface IAccountServices
    {
        Task<IEnumerable<Account>> GetAccounts();
        Task<Account> GetAccount(string AccountNumber);
        Task<Account> AddAccount(Account account);
        void DeleteAccount(string accountNumber);
    }
}
