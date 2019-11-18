using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Money_App.ViewModel.Commands
{
    public class RestoreTransactionCommand : ICommand
    {
        private readonly Transactions transactions;

        public RestoreTransactionCommand(Transactions t)
            => transactions = t;

        public event EventHandler CanExecuteChanged
        {
            add
                => CommandManager.RequerySuggested += value;
            remove
                => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
            => transactions.DeletedCount > 0;

        public void Execute(object parameter)
        {
            var deleted = transactions.LastDeleted;
            transactions.TransactionsList.Add(deleted.Transaction);
            transactions.TransactionsList.Move(transactions.TransactionsList.Count - 1, deleted.Index);
        }
    }
}
