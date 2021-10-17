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
            while (true) { 
                if (currentMenu == 0) {
                    Menu.BankMenu();
                    int bnk = Inputs.GetSelection();
                    userBankId = bnk;
                    currentMenu++;
                }
                if (currentMenu == 1) {
                    Menu.LoginMenu();
                    LoginOptions option = (LoginOptions)Enum.Parse(typeof(LoginOptions), Console.ReadLine());
                    switch(option)
                    {
                        case LoginOptions.Create:
                            userAccountId= AccountsController.CreateAccount(userBankId);
                            Console.WriteLine("Your account number is " + userAccountId.ToString("D10"));
                            break;
                        case LoginOptions.Login:
                            userAccountId = Inputs.GetAccountNumber();
                            string userPassword = Inputs.GetPassword();
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
                            amount = Inputs.GetAmount();
                            TransactionsController.Deposit(acc,amount);
                            break;
                        case UserOptions.Withdraw:
                            amount = Inputs.GetAmount();
                            TransactionsController.Withdraw(acc , amount);
                            break;
                        case UserOptions.Transfer:
                            List<long> recp = Inputs.GetRecipient();
                            amount = Inputs.GetAmount();
                            //Account recipAcc = AccountsController.GetAccount();
                            //TransactionsController.Transfer(acc,  recipAcc,amount);
                            break;
                        case UserOptions.ShowBalance:
                            {
                                Console.WriteLine("Your Balance is: " + AccountsController.GetBalance(userBankId,userAccountId));
                                break;
                            }
                        case UserOptions.TransactionHistory:
                            List<Transaction> hist = TransactionsController.GetTransactionHistory(acc);
                            foreach (Transaction t in hist)
                            {
                                Console.WriteLine(Utilities.PrintReciept(t));
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
