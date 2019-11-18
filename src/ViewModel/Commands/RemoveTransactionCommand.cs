using System;
using System.Windows.Input;

namespace Money_App.ViewModel.Commands
{
    public class RemoveTransactionCommand : ICommand
    {
        private readonly Transactions transactions;

        public RemoveTransactionCommand(Transactions t)
            => transactions = t;

        public event EventHandler CanExecuteChanged
        {
            add
                => CommandManager.RequerySuggested += value;
            remove
                => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object i) 
            => i != null && (int)i >= 0 && transactions.TransactionsList.Count > 0
                    && transactions.TransactionsList.Count > (int)i;

        public void Execute(object i) 
            => transactions.TransactionsList.RemoveAt((int)i);
    }
}
