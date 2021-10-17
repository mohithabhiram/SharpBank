using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpBank.Models.Enums;

namespace SharpBank.CLI
{
    public static class Inputs
    {
        public static long GetAccountNumber()
        {
            Console.WriteLine("Please Enter Your Account Number :");
            return Convert.ToInt64(Console.ReadLine());
        }
        public static string GetPassword()
        {
            Console.WriteLine("Please Enter Your Password :");
            return Console.ReadLine();
        }
        public static string GetName()
        {
            Console.WriteLine("Please Enter Your Name :");
            return Console.ReadLine();
        }
        public static Gender GetGender()
        {
            Console.WriteLine("Please Enter Your Gender (Male/Female/Other) :");
            Enum.TryParse(Console.ReadLine(), out Gender gender);
            return gender;
        }
        public static int GetSelection()
        {
            try
            {
                Console.WriteLine("Please Enter Your Selection :");

                return Convert.ToInt32(Console.ReadLine());
            }
            catch(FormatException e)
            {
                Console.WriteLine("Invalid Selection");
            }
            //Goback
            return -1;
        }
        public static decimal GetAmount()
        {
            Console.WriteLine("Please Enter The Amount :");
            return Convert.ToDecimal(Console.ReadLine());
        }
        public static List<long> GetRecipient()
        {
            List<long> res = new List<long>();
            Console.WriteLine("Please Enter Recipient BankId");
            res.Add(Convert.ToInt64(Console.ReadLine()));
            Console.WriteLine("Please Enter Recipient Account number");
            res.Add(Convert.ToInt64(Console.ReadLine()));
            return res;
        }
    }
}
