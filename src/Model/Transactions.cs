using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Money_App.Model
{
    public class Transactions : IEnumerable<Transaction>, IDisposable
    {
        private List<Transaction> transactions = new List<Transaction>();
        public Categories Categories = new Categories();

        public Transactions() 
            => Load();

        public void Dispose()
            => Save();

        public void Add(Transaction t)
        {
            if (t != null)
                transactions.Add(t);
        }

        public void Remove(Transaction t)
        {
            if (t != null)
                transactions.Remove(t);
        }

        public void Move(Transaction what, int where)
        {
            if (!(what is null))
            {
                int whatIndex = transactions.FindIndex(x => x == what);
                if (whatIndex >= 0 && whatIndex < transactions.Count)
                {
                    var temp = transactions[where];
                    transactions[where] = what;
                    transactions[whatIndex] = temp;
                }
            } 
        }

        public void Replace(int index, Transaction transaction)
            => transactions[index] = transaction;

        public int Count()
            => transactions.Count();

        public decimal CountBalance()
        {
            decimal balance = 0;
            foreach (var t in transactions)
                balance += t.Value;
            return balance;
        }

        public decimal CountSavedMoneyPercent()
        {
            decimal profit = 0;
            foreach (var t in transactions)
                if (t.Value > 0)
                    profit += t.Value;

            if (profit > 0)
                return (CountBalance() / profit) * 100;
            else
                return 0;
        }

        public Transaction this[int index]
            => transactions[index];

        public IEnumerator<Transaction> GetEnumerator()
            => transactions.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public void Save() 
            => SaveManager.SaveTransactions(transactions, "save.dat");

        public void Load()
            => transactions = SaveManager.LoadTransactions("save.dat") ?? transactions;       
    }
}
