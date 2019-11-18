using System;
using System.Windows.Input;

namespace Money_App.ViewModel.Commands
{
    public class MoveTransactionUpCommand : ICommand
    {
        private readonly Transactions transactions;
        public MoveTransactionUpCommand(Transactions t)
            => transactions = t;

        public event EventHandler CanExecuteChanged
        {
            add
                => CommandManager.RequerySuggested += value;
            remove
                => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object i)
            => (i != null && (int)i > 0 && transactions.TransactionsList.Count > 1 
            && (int)i < transactions.TransactionsList.Count);


        public void Execute(object i) 
            => transactions.TransactionsList.Move((int)i, (int)i - 1);
    }
}
