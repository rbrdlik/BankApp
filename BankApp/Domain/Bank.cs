using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Domain
{
    class Bank
    {
        public string Name;
        public List<BankAccount> Accounts;
        public List<Transaction> Transactions;

        public Bank(string name)
        {
            Name = name;
            Accounts = new List<BankAccount>();
            Transactions = new List<Transaction>(); 
        }

        public void AddAccount(BankAccount account)
        {
            Accounts.Add(account);
        }

        public void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
        }
        
        public void AllAccounts()
        {
            Console.WriteLine($"- Veškeré účty banky {Name.ToUpper()} -");
            foreach (var account in Accounts)
            {
                Console.WriteLine(account);
            }
        }

        public void AllTransactions()
        {
            Console.WriteLine($"- Veškeré transakce banky {Name.ToUpper()} -");
            foreach (var transaction in Transactions)
            {
                Console.WriteLine($"Z účtu {transaction.FromAccount.AccountNumber} (Vlastník: {transaction.FromAccount.OwnerName}), Odeslaná částka {transaction.Amount}, na účet {transaction.ToAccount.AccountNumber} (Vlastník: {transaction.ToAccount.OwnerName})");
            }
        }

        public void VerifyLargeTransactions(string verifier)
        {
            Random rand = new Random();
            foreach (var transaction in Transactions)
            {
                if (transaction.HumanVerificationNeeded() && transaction.Verification == null)
                {
                    VerificationResult verify = (VerificationResult)rand.Next(0, 4);
                    transaction.Verification = new Verification(verifier, verify, "Information");

                    Console.WriteLine($"Transakce s částkou {transaction.Amount} byla ověřena od {verifier} a její status je {verify}");
                }
            }
        }

        public void DeniedTransactions()
        {
            Console.WriteLine("- Zamítnuté transakce - ");
            foreach (var transaction in Transactions)
            {
                if(transaction.HumanVerificationNeeded() && transaction.Verification != null && transaction.Verification.verificationResult == VerificationResult.Denied)
                {
                    Console.WriteLine($"Číslo účtu ze kterého byly peníze odeslány: {transaction.FromAccount.AccountNumber} (Vlastník: {transaction.FromAccount.OwnerName})");
                    Console.WriteLine($"Číslo účtu na kteý byly peníze odeslány: {transaction.ToAccount.AccountNumber} (Vlastník: {transaction.ToAccount.OwnerName})");
                    Console.WriteLine($"Odesílaná částka: {transaction.Amount}");
                    Console.WriteLine($"Dodatečné informace:  {transaction.Verification.FurtherInfo}");
                    Console.WriteLine($"Schváleno od: {transaction.Verification.Verifier}");
                }
            }
        }
    }
}
