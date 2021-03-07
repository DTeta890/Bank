using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Data
{
    public class Account
    {
        private static int Seed = 100;
        //public int Id { get; set; }
        public string Owner { get; set; }
        public string Iban { get; set; }
        public int Balance
        {
            get
            {
                var balance = 0;
                foreach (var t in Transactions)
                {
                    balance += t.Amount;
                }
                return balance;
            }
        }
        public List<Transaction> Transactions { get; set; }
        public Account(string owner)
        {
            this.Owner = owner;
            this.Iban = $"IBAN{++Seed}";
            this.Transactions = new List<Transaction>();
            var firstTransaction = new Transaction(0, DateTime.Now);
            this.Transactions.Add(firstTransaction);
        }
        public void MakeDeposit(int amount)
        {
            if (amount > 0)
            {
                var transaction = new Transaction(amount, DateTime.Now);
                Transactions.Add(transaction);
                Console.WriteLine($"\nDeposit was succesful, New Balance: ${Balance} !");
            }
            else
                Console.WriteLine("\nInvalid amount! Try again.");
        }
        public void MakeWithdraw(int amount)
        {
            if (amount > Balance || amount < 0 )
                Console.WriteLine("\nInvalid amount! Try again.");
            else
            {
                var transaction = new Transaction(-amount, DateTime.Now);
                Transactions.Add(transaction);
                Console.WriteLine($"\nWithdrawal was succesful, New Balance: ${Balance} !");
            }
        }
        public void ShowHistory()
        {
            var raport = new StringBuilder();
            raport.AppendLine("Nr\tAmount\tDate");
            var i = 0;
            foreach (var t in Transactions)
            {
                i++;
                if (i == 1)
                    raport.AppendLine($"{i}\t{t.Amount}\t{t.Date}\t Account Created!");
                else
                    raport.AppendLine($"{i}\t{t.Amount}\t{t.Date}");
            }
            Console.WriteLine(raport);
        }
    }
}
