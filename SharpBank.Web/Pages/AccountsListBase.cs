using Microsoft.AspNetCore.Components;
using SharpBank.Models;
using SharpBank.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpBank.Web.Pages
{
    public class AccountsListBase:ComponentBase
    {
        [Inject]
        public IAccountServices AccountServices { get; set; }

        public IEnumerable<Account> Accounts { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Accounts = (await AccountServices.GetAccounts()).ToList();
        }
    }
}
