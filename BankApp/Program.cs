using BankApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Bank moneta = new Bank("Moneta");
                BankAccount b1 = new BankAccount(1000000, "Franta");
                BankAccount b2 = new BankAccount(1000000, "Pepa");

                moneta.AddAccount(b1);
                moneta.AddAccount(b2);
                moneta.AllAccounts();

                Transaction t1 = new Transaction(b1, b2, 40000);
                Transaction t2 = new Transaction(b2, b1, 35000);
                Transaction t3 = new Transaction(b2, b1, 200000);

                moneta.AddTransaction(t1);
                t1.Execute();

                moneta.AddTransaction(t2);
                t2.Execute();

                moneta.AddTransaction(t3);
                t3.Execute();


                moneta.AllTransactions();
                moneta.AllAccounts();
                moneta.VerifyLargeTransactions("Pepa z depa");
                moneta.DeniedTransactions();

            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.ReadKey();
        }
    }
}
