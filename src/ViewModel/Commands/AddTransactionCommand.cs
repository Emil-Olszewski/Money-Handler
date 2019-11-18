using System;
using System.Windows.Input;

namespace Money_App.ViewModel.Commands
{
    public class AddTransactionCommand : ICommand
    {
        private readonly Transactions transactions;

        public AddTransactionCommand(Transactions t) 
            => transactions = t;

        public event EventHandler CanExecuteChanged
        {
            add
                => CommandManager.RequerySuggested += value;
            remove
                => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object t)
            => Transaction.Verify(t as Transaction);

        public void Execute(object t)
            => transactions.TransactionsList.Add(t as Transaction);
    }
}
