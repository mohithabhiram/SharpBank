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
        private DataStore dataStore;
        public BankService(DataStore datastore)
        {
            this.dataStore = datastore;
            datastore.Banks.Add(new Bank { BankId = "", Name = "", Accounts = new List<Account> { } });
        }
        //public long GenerateId()
        //{
        //    Random rand = new Random();
        //    long Id = rand.Next(); ;

        //    while (dataStore.Banks.FirstOrDefault(b => b.BankId == Id) != null)
        //    {
        //        Id = rand.Next();
        //    }
        //    return Id;
        //}

        public string GenerateBankId(string name)
        {
            DateTime d = DateTime.Now;
            string date = DateTime.Now.ToString("ddMMyy");
            return name.Substring(0, 3) + date;
        }

        public string AddBank(string name)
        {
            if(dataStore.Banks.Any(m=> m.Name==name))
            {
                throw new Exception("Bank Exists with this name!");
            }
            Bank bank = new Bank
            {
                BankId = this.GenerateBankId(name),
                Name = name,
                CreatedBy = "Mohith",
                CreatedOn = DateTime.Now,
                UpdatedBy = "Mohith",
                UpdatedOn = DateTime.Now,
                Accounts = new List<Account>()
            };
            dataStore.Banks.Add(bank);
            return bank.BankId;
        }
        public Bank GetBank(string bankId)
        {

            return dataStore.Banks.SingleOrDefault(b => b.BankId == bankId);
        }



    }
}