using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Domain
{
    class BankAccount
    {
        private static int lastAccNumber = 1;
        public int AccountNumber;
        private decimal Balance;
        public string OwnerName;

        public BankAccount(decimal balance, string ownerName) {
            AccountNumber = lastAccNumber;
            lastAccNumber++;
            Balance = balance;
            OwnerName = ownerName;

            if (ownerName == null || ownerName.Equals("")) { 
                throw new ArgumentOutOfRangeException(nameof(ownerName), "Chybí jméno majitele účtu"); 
            }
            if (Balance < 0) { 
                throw new ArgumentOutOfRangeException(nameof(balance), "Účet lze vytvořit pouze s kladným zůstatkem "); 
            }
        }

        public void Deposit(decimal amount)
        {
            AmountCheck(amount);
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            AmountCheck(amount);
            if(Balance < amount)
            {
                throw new InvalidOperationException("Není možné vybrat/odeslat peníze protože se vybírá větší částka než je dostupná na účtu");
            }
            else
            {
                Balance -= amount;
            }
            
        }

        public void AmountCheck(decimal amount)
        {
            if(amount <= 0) {
                throw new ArgumentOutOfRangeException(nameof(amount), "Nemůžeš vybrat nebo vložit 0 nebo záporné číslo");
            }
        }

        public override string ToString()
        {
            return $"Číslo účtu: {AccountNumber}, Vlastník: {OwnerName}, Zůstatek: {Balance}";
        }
    }
}
