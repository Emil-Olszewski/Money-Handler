using System;
using System.Windows.Input;

using static Money_App.ViewModel.Categories;

namespace Money_App.ViewModel.Commands
{
    public class EditCategoryCommand : ICommand
    {
        private readonly Transactions transactions;

        public EditCategoryCommand(Transactions transactions)
            => this.transactions = transactions;

        public event EventHandler CanExecuteChanged
        {
            add
                => CommandManager.RequerySuggested += value;
            remove
                => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            var edited = parameter as EditedCategory;
            return edited != null && !string.IsNullOrWhiteSpace(edited.NewName);
        }

        public void Execute(object parameter)
        {
            var edited = parameter as EditedCategory;
            int index = transactions.CategoriesList.IndexOf(edited.OldName);
            transactions.CategoriesList[index] = edited.NewName;
            transactions.EditCategories(edited.OldName, edited.NewName);
        }
    }
}
