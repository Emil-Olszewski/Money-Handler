using System;
using System.Windows.Input;

using static Money_App.ViewModel.Categories;

namespace Money_App.ViewModel.Commands
{
    public class EditCategoryCommand : ICommand
    {
        private readonly Categories categories;

        public EditCategoryCommand(Categories categories)
            => this.categories = categories;

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
            int index = categories.CategoriesList.IndexOf(edited.OldName);
            categories.CategoriesList[index] = edited.NewName;
        }
    }
}
