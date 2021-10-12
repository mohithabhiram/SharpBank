using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpBank.Models;
using SharpBank.Models.Exceptions;

namespace SharpBank.Services
{
    public class BankService
    {
        public long GenerateId()
        {
            Random rand = new Random();
            long Id = rand.Next(); ;

            while (DataStore.Banks.FirstOrDefault(b => b.Id == Id) != null)
            {
                Id = rand.Next();
            }
            return Id;
        }

        public long AddBank(string name)
        {
            if(DataStore.Banks.Any(m=> m.Name==name))
            {
                throw new Exception("Bank Exists with this name!");
            }
            Bank bank = new Bank
            {
                Id = this.GenerateId(),
                Name = name,
                CreatedBy = "Mohith",
                CreatedOn = DateTime.Now,
                UpdatedBy = "Mohith",
                UpdatedOn = DateTime.Now,
                Accounts = new List<Account>()
            };
            DataStore.Banks.Add(bank);
            return bank.Id;
        }



    }
}