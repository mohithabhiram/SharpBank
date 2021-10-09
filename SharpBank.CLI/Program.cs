using System;
using System.Collections.Generic;
using SharpBank.Services;
using SharpBank.Models;
namespace SharpBank.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
           //Create Banks
            BankManagerServices.AddBank("Acksis Bank");
            BankManagerServices.AddBank("Yaxis Bank");
            BankManagerServices.AddBank("Puxis Bank");
            BankManagerServices.AddBank("Yesu Bank");

            bool isRunning = true;
            int currentMenu = 0;
            string userIFSC = "";
            string userAccountNumber = "";
            string userPassword = "";
            while (isRunning) { 
                if (currentMenu == 0) {
                    Menu.BankMenu();
                    int bnk = Inputs.GetSelection();
                    userIFSC = bnk.ToString();
                    currentMenu++;
                    
                }
                if (currentMenu == 1) {
                    Menu.LoginMenu();
                    int sel = Inputs.GetSelection();
                    if (sel == 1) {
                        string userName = Inputs.GetName();

                        userPassword = Inputs.GetPassword();

                        userAccountNumber = BankServices.AddAccount(userIFSC, userName, userPassword);
                        Console.WriteLine("Welcome to "+ BankManager.Banks[userIFSC].BankName+ " Your account number is " + userAccountNumber + "  and bank IFSC " + userIFSC + " Dont forget it");
                    }
                    if (sel == 2) {
                        userAccountNumber = Inputs.GetAccountNumber();
                        userPassword = Inputs.GetPassword();
                
                        currentMenu++;
                    }
                    if (sel == 3) currentMenu--;
                    if (sel == 4) isRunning = false;
                }
                if (currentMenu == 2) {
                    Menu.UserMenu();
                    int sel = Inputs.GetSelection();
                    decimal amount = 0m;
                    switch (sel)
                    {
                        case 1:
                            amount = Inputs.GetAmount();
                            TransactionServices.Deposit(userIFSC, userAccountNumber, amount);
                            break;
                        case 2:
                            amount = Inputs.GetAmount();
                            TransactionServices.Withdraw(userIFSC, userAccountNumber, amount);
                            break;
                        case 3:
                            List<string> recp = Inputs.GetRecipient();
                            amount = Inputs.GetAmount();
                            TransactionServices.Transfer(userIFSC, userAccountNumber, recp[0], recp[1], amount);
                            break;
                        case 4:
                            {
                                Console.WriteLine("Your Balance is: " + AccountServices.GetBalance(userIFSC, userAccountNumber));
                                break;
                            }
                        case 5:
                            List<Transaction> hist = AccountServices.GetTransactionHistory(userIFSC, userAccountNumber);
                            foreach (Transaction t in hist) {
                                Console.WriteLine(t.ToString());
                            }
                            break;
                        case 6:
                            currentMenu = 0;
                            break;
                        default:
                            Console.WriteLine("Invalid Selection");
                            break;
                    }
                }
            }
        }
    }
}
