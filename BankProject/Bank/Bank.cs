using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Bank : IBank
    {
        List<Account> accounts = new List<Account>();
        List<Customer> customers = new List<Customer>();
        Dictionary<int, Customer> CustomerId = new Dictionary<int, Customer>();
        Dictionary<int, Customer> CustomerNum = new Dictionary<int, Customer>();
        Dictionary<int, Account> AccountNum = new Dictionary<int, Account>();
        Dictionary<Customer, List<Account>> CustomerAcc = new Dictionary<Customer, List<Account>>();
        //List<Account> accList = new List<Account>();
        int totalMoneyInBank;
        int profits;        
        public string Name { get; }
        public string Adress { get; }
        public int costumerAcount { get; }
        internal Customer GetCustomerById(int id)
        {
            if (CustomerId.TryGetValue(id, out Customer c))
            {
                return c;
            }            
                throw new CustomerNotFoundException("Customer Not Found");            
        }
        internal Customer GetCustomerByNumber(int num)
        {
            if (CustomerNum.TryGetValue(num, out Customer c))
            {
                return c;
            }
            throw new CustomerNotFoundException("Customer Not exist");
        }
        internal Account GetAccountNumber(int num)
        {
            if (AccountNum.TryGetValue(num, out Account a))
            {
                return a;
            }
            throw new AccountNotFoundException("Account Not exist");
        }
        internal List<Account> GetAccountByCustomer(Customer c)
        {            
            if (CustomerAcc.TryGetValue(c, out List<Account> accList))
                return accList;
            throw new CustomerNotFoundException();
        }
        internal void AddNewCustomer(Customer c)
        {
            if (customers.Contains(c))
            {
                throw new CustomerAlreadyExistException("Customer exist");
            }
            customers.Add(c);
            CustomerId.Add(c.CustomerId, c);
            CustomerNum.Add(c.CustomerNumber, c);           
            
        }       
        internal void OpenNewAccount(Account a, Customer c)
        {
            if (accounts.Contains(a))
            {
                throw new AccountAlreadyExistException("Account exist");
            }
            accounts.Add(a);
            AccountNum.Add(a.AccountNumber, a);
            if (CustomerAcc.TryGetValue(c, out List<Account> list))
            {
                CustomerAcc[c].Add(a);
            }
            else
            {
                List<Account> list1 = new List<Account>();
                list1.Add(a);
                CustomerAcc.Add(c, list1);
            }                   
        }
        internal void Deposit(Account a, int amount)
        {
            if (!accounts.Contains(a))
            {
                throw new AccountNotFoundException("Account Not exist");
            }
            a.Add(a, amount);
            totalMoneyInBank = totalMoneyInBank + amount;
        }
        internal void WithDraw(Account a, int amount)
        {
            if (!accounts.Contains(a))
            {                
                throw new AccountNotFoundException("Account Not exist");
            }
            a.Subtract(a, amount);
            totalMoneyInBank = totalMoneyInBank - amount;
        }
        internal int GetCustomerTotalBalance(Customer c)
        {
            if (!customers.Contains(c))
            {
                throw new CustomerNotFoundException("Customer Not exist");
            }
            int totalbalance = 0;
            foreach (Account a in accounts)
            {
                if (a.AccountOwner == c)
                {
                    totalbalance = a.Balance + totalbalance;
                }
            }
            return totalbalance;
        }
        internal void CloseAccount(Account a, Customer c)
        {
            if (a.AccountOwner != c)
            {
                throw new AccountNotFoundException("Account Not exist");
            }
            else if (a.Balance > 0)
            {
                Console.WriteLine($"the balance in your account is {a.Balance} you need to make a Draw");
            }
            else if (a.Balance < 0)
            {
                Console.WriteLine($"the balance in your account is {a.Balance} you need to make a Deposit");
            }
            else
            {
                accounts.Remove(a);
                AccountNum.Remove(a.AccountNumber);
                CustomerAcc[c].Remove(a);
            }            
        }
        internal void ChargeAnnualCommossion(int comm)
        {
            foreach (Account a in accounts)
            {
                int commossion = comm * a.Balance/100;
                a.Add(a, -commossion);
                totalMoneyInBank = totalMoneyInBank - comm;
            }
        }
        internal void JoinAccounts(Account a, Account b)
        {
            if (a.AccountOwner != b.AccountOwner)
            {
                throw new NotSameCustomerException("Not The Same Customer");
            }
            Account c = a + b;
            CloseAccount(a,a.AccountOwner);
            CloseAccount(b,b.AccountOwner);            
            accounts.RemoveAt(a.AccountNumber);
            AccountNum.Remove(a.AccountNumber);
            AccountNum.Remove(b.AccountNumber);
            AccountNum.Add(c.AccountNumber,c);
            CustomerAcc[a.AccountOwner].Remove(a);
            CustomerAcc[b.AccountOwner].Remove(b);
            CustomerAcc[c.AccountOwner].Add(c);
        }

        public Bank()
        {
        }
        
    }
}
