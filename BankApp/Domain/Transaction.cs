using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Domain
{
    class Transaction
    {
        public BankAccount FromAccount;
        public BankAccount ToAccount;
        public DateTime DateTime;
        public int Amount;
        public Verification Verification = null;

        public Transaction(BankAccount fromAccount, BankAccount toAccount, int amount)
        {
            FromAccount = fromAccount;
            ToAccount = toAccount;
            DateTime = DateTime.Now;
            Amount = amount;
        }
        public bool HumanVerificationNeeded()
        {
            return Amount > 100000;
        }
        public void Execute()
        {
            FromAccount.Withdraw(Amount);
            ToAccount.Deposit(Amount);
        }
    }
}
