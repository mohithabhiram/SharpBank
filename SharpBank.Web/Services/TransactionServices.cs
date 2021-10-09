using SharpBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SharpBank.Web.Services
{
    public class TransactionServices : ITransactionServices
    {
        private readonly HttpClient httpClient;

        public TransactionServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Transaction>> GetTransactions()
        {
            return await httpClient.GetFromJsonAsync<Transaction[]>("api/transactions");
        }
    }
}
