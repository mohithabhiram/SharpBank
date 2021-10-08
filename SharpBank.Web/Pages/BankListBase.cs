using Microsoft.AspNetCore.Components;
using SharpBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpBank.Web.Pages
{
    public class BankListBase:ComponentBase
    {
        public IEnumerable<Bank> Banks { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Task.Run(LoadBanks);
        }

        private void LoadBanks() 
        {
            System.Threading.Thread.Sleep(4000);
            Bank b1 = new Bank("Yaxis", "001");
            Bank b2 = new Bank("YesBI", "002");
            Bank b3 = new Bank("FDHC", "003");
            Bank b4 = new Bank("YCYCY", "004");
            Banks = new List<Bank> { b1, b2, b3, b4 };
        }
    }
}
