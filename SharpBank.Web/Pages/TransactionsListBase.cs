using Microsoft.AspNetCore.Components;
using SharpBank.Models;
using SharpBank.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpBank.Web.Pages
{

    public class TransactionsListBase : ComponentBase
    {
        [Inject]
        public ITransactionServices TransactionServices { get; set; }

        public IEnumerable<Transaction> Transactions { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Transactions = (await TransactionServices.GetTransactions()).ToList();
        }
    }
}
