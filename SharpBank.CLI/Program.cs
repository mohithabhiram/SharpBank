using System;
using System.Collections.Generic;
using SharpBank.Services;
using SharpBank.Models;
using SharpBank.CLI.Controllers;
using SharpBank.Models.Enums;

namespace SharpBank.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            int currentMenu = 0;
            string userBankId = "";
            long userAccountId = 0;

            Inputs inputs = new Inputs();
            DataStore datastore = new DataStore();

            BankService bankService = new BankService(datastore);
            AccountService accountService = new AccountService(bankService);
            TransactionService transactionService = new TransactionService(accountService);

            BanksController banksController = new BanksController(bankService, inputs);
            AccountsController accountsController = new AccountsController(accountService, inputs);
            TransactionsController transactionsController = new TransactionsController(transactionService,accountService);

            Utilities.CreateBank.CustomBanks(banksController);
           
            while (true) { 
                if (currentMenu == (int)Menus.BankMenu) {
                    Menu.BankMenu(datastore);
                    string b = inputs.GetBankId();
                    userBankId = b;
                    currentMenu++;
                }
                if (currentMenu == (int)Menus.LoginMenu) {
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
                if (currentMenu == (int)Menus.UserMenu) {
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
                            List<string> recp = inputs.GetRecipient();
                            amount = inputs.GetAmount();
                            //Account recipAcc = AccountsController.GetAccount();
                            transactionsController.Transfer(userBankId, userAccountId, recp[0], Convert.ToInt64(recp[1]), amount);
                            break;
                        case UserOptions.ShowBalance:
                            {
                                Console.WriteLine("Your Balance is: " + accountsController.GetBalance(userBankId,userAccountId));
                                break;
                            }
                        case UserOptions.TransactionHistory:
                            List<Transaction> tHist = accountsController.GetTransactionHistory(userBankId, userAccountId);
                            Console.WriteLine("TransactionId | Source Bank | Source Account | Dest. Bank | Dest Account |  Amount  | Timestamp ");
                            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
                            foreach (Transaction t in tHist)
                            {
                                Console.WriteLine($" {t.TransactionId.ToString("D10")} | {t.SourceBankId}  |   {t.SourceAccountId.ToString("D10")}   |   {t.DestinationBankId}  |  {t.DestinationAccountId.ToString("D10")}   | {t.Amount.ToString("C3")} | {t.On}");
                            }
                            break;
                        case UserOptions.Exit:
                            currentMenu = 0;
                            break;
                        default:
                            Console.WriteLine("Invalid");
                            break;

                    }

                }
       
            }

        }
    }
}
