using System;
using System.Windows.Input;

namespace Money_App.ViewModel.Commands
{
    public class EditTransactionCommand : ICommand
    {
        private readonly Transactions transactions;

        public EditTransactionCommand(Transactions t)
            => transactions = t;

        public event EventHandler CanExecuteChanged
        {
            add
                => CommandManager.RequerySuggested += value;
            remove
                => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object transaction)
        {
            var selected = transaction as SelectedTransaction;
            return (selected != null && selected.Index >= 0 && selected.Index < transactions.TransactionsList.Count);
        }

        public void Execute(object transaction)
        {
            var selected = transaction as SelectedTransaction;
            transactions.TransactionsList[selected.Index] = selected.Transaction;
        }
    }
}
