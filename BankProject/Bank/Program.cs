using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            Customer y = new Customer(040196388, "Yehuda", 0545207871);
            Customer s = new Customer(039705074, "Sivan", 0528716154);
            Customer l = new Customer(345007512, "Lior", 0);
            bank.AddNewCustomer(y);
            bank.AddNewCustomer(s);
            bank.AddNewCustomer(l);   
            Account a1 = new Account(y, 10000);
            Account a2 = new Account(s, 20000);
            Account a3 = new Account(l, 30000);
            Account a4 = new Account(y, 40000);
            bank.OpenNewAccount(a1, y);
            bank.OpenNewAccount(a2, s);
            bank.OpenNewAccount(a3, l);
            bank.OpenNewAccount(a4, y);
            Console.WriteLine(bank.GetCustomerById(040196388));
            Console.WriteLine(bank.GetCustomerByNumber(1));
            Console.WriteLine(bank.GetAccountNumber(0));              
            foreach (Account a in bank.GetAccountByCustomer(s))
            {
                Console.WriteLine(a);
            }
            Customer o = new Customer(454, "nati", 893);
            //bank.AddNewCustomer(y);
            bank.Deposit(a1, 8000);
            Console.WriteLine(y);
            Console.WriteLine(bank.GetCustomerTotalBalance(y));
            bank.WithDraw(a4, 30000);
            Console.WriteLine(bank.GetCustomerTotalBalance(y));
            Console.WriteLine(a4.Balance);
            bank.CloseAccount(a1, y);
            bank.ChargeAnnualCommossion(3);
            Console.WriteLine(bank.GetCustomerTotalBalance(s));
            bank.CloseAccount(a3,l);
            bank.WithDraw(a3, 29100);
            bank.CloseAccount(a3,l);
            Console.WriteLine(a3.Balance);
            bank.JoinAccounts(a1, a4);
            foreach (Account a in bank.GetAccountByCustomer(y))
            {
                Console.WriteLine(a);
            }
            

            


            

        }
    }
}
