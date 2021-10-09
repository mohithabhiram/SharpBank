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
            Bank b1 = new Bank { BankName = "Yaxis", IFSC = "001", ImagePath="/css/images/yaxis.jpeg" };
            Bank b2 = new Bank { BankName = "YesBI", IFSC = "002", ImagePath= "/css/images/yesbi.jpeg" };
            Bank b3 = new Bank { BankName = "FDHC", IFSC = "003" ,ImagePath= "/css/images/fdhc.jpeg" };
            Bank b4 = new Bank { BankName = "YCYCY", IFSC = "004", ImagePath = "/css/images/ycycy.jpeg"};
            Banks = new List<Bank> { b1, b2, b3, b4 };
        }
    }
}
