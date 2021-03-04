using System;

namespace Bank.Data
{
    public class Transaction
    {
        //public int Id { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public Transaction(int amount, DateTime date)
        {
            this.Amount = amount;
            this.Date = date;
        }
    }
}
