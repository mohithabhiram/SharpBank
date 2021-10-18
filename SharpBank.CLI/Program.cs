using System;
using System.Collections.Generic;
using SharpBank.Services;
using SharpBank.Models;
using SharpBank.CLI.Controllers;

namespace SharpBank.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            int currentMenu = 0;
            long userBankId = 0;
            long userAccountId = 0;
            Account acc=null;
            Inputs inputs = new Inputs();
            DataStore datastore = new DataStore();
            BankService bankService = new BankService(datastore);
            AccountService accountService = new AccountService(bankService);
            TransactionService transactionService = new TransactionService(accountService);

            BanksController banksController = new BanksController(bankService, inputs);
            AccountsController accountsController = new AccountsController(accountService, inputs);
            TransactionsController transactionsController = new TransactionsController(transactionService);

            banksController.CreateBank("Yaxis");
            banksController.CreateBank("YesBI");
            banksController.CreateBank("FDHC");






            while (true) { 
                if (currentMenu == 0) {
                    Menu.BankMenu(datastore);
                    int bnk = inputs.GetSelection();
                    userBankId = bnk;
                    currentMenu++;
                }
                if (currentMenu == 1) {
                    Menu.LoginMenu();
                    LoginOptions option = (LoginOptions)Enum.Parse(typeof(LoginOptions), Console.ReadLine());
                    switch(option)
                    {
                        case LoginOptions.Create:
                            userAccountId= accountsController.CreateAccount(userBankId);
                            Console.WriteLine("Your account number is " + userAccountId.ToString("D10"));
                            break;
                        case LoginOptions.Login:
                            userAccountId = inputs.GetAccountNumber();
                            string userPassword = inputs.GetPassword();
                            currentMenu++;
                            break;
                        case LoginOptions.Back:
                            currentMenu--;
                            break;
                        case LoginOptions.Exit:
                            Environment.Exit(0);
                            break;
                    }
                }
                if (currentMenu == 2) {
                    Menu.UserMenu();
                    UserOptions option = (UserOptions)Enum.Parse(typeof(UserOptions), Console.ReadLine());
                    decimal amount = 0m;
                    switch (option)
                    {
                        case UserOptions.Deposit:
                            amount = inputs.GetAmount();
                            transactionsController.Deposit(userBankId,userAccountId,amount);
                            break;
                        case UserOptions.Withdraw:
                            amount = inputs.GetAmount();
                            transactionsController.Withdraw(userBankId, userAccountId, amount);
                            break;
                        case UserOptions.Transfer:
                            List<long> recp = inputs.GetRecipient();
                            amount = inputs.GetAmount();
                            //Account recipAcc = AccountsController.GetAccount();
                            transactionsController.Transfer(userBankId, userAccountId, recp[0], recp[1], amount);
                            break;
                        case UserOptions.ShowBalance:
                            {
                                Console.WriteLine("Your Balance is: " + accountsController.GetBalance(userBankId,userAccountId));
                                break;
                            }
                        case UserOptions.TransactionHistory:
                            List<Transaction> hist = accountsController.GetTransactionHistory(userBankId, userAccountId);
                            Console.WriteLine("TransactionId | Source Bank | Source Account | Dest. Bank | Dest Account |  Amount  | Timestamp ");
                            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
                            foreach (Transaction t in hist)
                            {
                                Console.WriteLine(t.ToString());
                            }
                            break;
                        case UserOptions.Exit:
                            currentMenu = 0;
                            break;
                        default:
                            Console.WriteLine("Invalid ma");
                            break;

                    }

                }
       
            }

        }
        public enum LoginOptions
        {
            Create=1,
            Login,
            Back,
            Exit
        }
        public enum UserOptions
        {
            Deposit=1,
            Withdraw,
            Transfer,
            ShowBalance,
            TransactionHistory,
            Exit

        }
    }
}
