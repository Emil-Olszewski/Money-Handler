using Money_App.ViewModel.Commands;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Money_App.ViewModel
{
    public class Categories : INotifyPropertyChanged
    {
        private readonly Model.Categories model_categories = new Model.Categories();

        public ObservableCollection<string> CategoriesList { get; }
            = new ObservableCollection<string>();

        public Categories() 
            => CopyFromModel();

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(params string[] names)
        {
            foreach (var name in names)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private AddCategoryCommand addCategory;
        public AddCategoryCommand AddCategory
            => addCategory?? (addCategory = new AddCategoryCommand(this));

        private EditCategoryCommand editCategory;
        public EditCategoryCommand EditCategory
            => editCategory ?? (editCategory = new EditCategoryCommand(this));

        private DeleteCategoryCommand deleteCategory;
        public DeleteCategoryCommand DeleteCategory
            => deleteCategory ?? (deleteCategory = new DeleteCategoryCommand(this));

        private void CopyFromModel()
        {
            CategoriesList.CollectionChanged -= ModelSynchro;
            CategoriesList.Clear();
            foreach (var s in model_categories)
                CategoriesList.Add(s);
            CategoriesList.CollectionChanged += ModelSynchro;
        }

        private void ModelSynchro(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    var newC = (string)e.NewItems[0];
                    if (newC != null)
                        model_categories.Add(newC);
                    break;

                case NotifyCollectionChangedAction.Remove:
                    var oldC = (string)e.OldItems[0];
                    if (oldC != null)
                        model_categories.Remove(oldC);
                    break;
            }

            OnPropertyChanged("CategoriesList");
        }

        public class EditedCategory
        {
            public string OldName { get; private set; }
            public string NewName { get; private set; }

            public EditedCategory(string old, string @new)
            {
                OldName = old;
                NewName = @new;
            }
        }
    }
}
