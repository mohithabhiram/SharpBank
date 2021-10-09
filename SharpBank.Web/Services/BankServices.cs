using SharpBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SharpBank.Web.Services
{
    public class BankServices : IBankServices
    {
        private readonly HttpClient httpClient;

        public BankServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Bank>> GetBanks()
        {
            return await httpClient.GetFromJsonAsync<Bank[]>("api/banks");
        }
    }
}
