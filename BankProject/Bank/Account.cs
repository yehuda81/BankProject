using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Account
    {
        static int numberOfAcc;
        readonly int accountNumber;
        readonly Customer accountOwner;
        int maxMinusAllowed;

        public int AccountNumber
        {
            get
            {
                return accountNumber;
            }
        }                 
        public int Balance { get;private set; }
        public Customer AccountOwner
        {
            get
            {
                return accountOwner;
            }
        }
        public int MaxMinusAllowed { get; }

        public Account(Customer accountOwner,  int mounthlyincome)
        {
            accountNumber = numberOfAcc++;
            this.accountOwner = accountOwner;
            MaxMinusAllowed = mounthlyincome * 3;
            Balance = Balance + mounthlyincome;            
        }      
        public void Add(Account a, int amount)
        {
            a.Balance = a.Balance + amount;
        }
        public void Subtract(Account a, int amount)
        {
            a.Balance = a.Balance - amount;
        }

        public override bool Equals(object obj)
        {
            Account a = obj as Account;
            return this == a;
        }

        public override int GetHashCode()
        {
            return this.accountNumber;
        }

        public static bool operator == (Account a, Account b)
        {
            return a.accountNumber == b.accountNumber;
        }
        public static bool operator !=(Account a, Account b)
        {
            return a.accountNumber != b.accountNumber;
        }
        public static Account operator + (Account a, Account b)
        {
            Account c = new Account(a.accountOwner, a.MaxMinusAllowed / 3);
            c.Balance = a.Balance + a.Balance;
            c.maxMinusAllowed = a.maxMinusAllowed;
            return c;
           
        }
        public static Account operator -(Account a, Account b)
        {
            Account c = new Account(a.accountOwner, a.MaxMinusAllowed / 3);
            c.Balance = a.Balance - a.Balance;
            c.maxMinusAllowed = a.maxMinusAllowed;
            return c;
        }       

        public override string ToString()
        {
            return $"Account number: {AccountNumber} Owner: {AccountOwner} Balance {Balance}";
        }
    }
}
