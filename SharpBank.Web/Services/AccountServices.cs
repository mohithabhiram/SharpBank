using SharpBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SharpBank.Web.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly HttpClient httpClient;

        public AccountServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return await httpClient.GetFromJsonAsync<Account[]>("api/accounts");
        }
    }
}
