using System;
using System.Windows.Input;

namespace Money_App.ViewModel.Commands
{
    public class DeleteCategoryCommand : ICommand
    {
        private readonly Categories categories;

        public DeleteCategoryCommand(Categories categories)
            => this.categories = categories;

        public event EventHandler CanExecuteChanged
        {
            add
                => CommandManager.RequerySuggested += value;
            remove
                => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object name)
            => !string.IsNullOrWhiteSpace((string)name);

        public void Execute(object name)
            => categories.CategoriesList.Remove((string)name);
    }
}
