using Money_App.ViewModel.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Money_App.ViewModel
{
    public class Categories : INotifyPropertyChanged
    {
        private readonly Model.Categories model_categories;

        public ObservableCollection<string> CategoriesList { get; }
            = new ObservableCollection<string>();

        public Categories(Model.Categories categories)
        {
            model_categories = categories;
            CopyFromModel();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(params string[] names)
        {
            foreach (var name in names)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private AddCategoryCommand addCategory;
        public AddCategoryCommand AddCategory
            => addCategory?? (addCategory = new AddCategoryCommand(this));
    
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

        public class ValuableCategory
        {
            public decimal Value { get; private set; }
            public string Name { get; private set; }
            public decimal PercentOfWhole
                => Value / TotalValue * 100;

            public static decimal TotalValue { get; set; } = 0;

            public ValuableCategory(decimal value, string name)
            {
                Value = value;
                Name = name;
            }

            public static void SortDescending(ObservableCollection<ValuableCategory> categories)
            {
                bool change;
                do
                {
                    change = false;
                    for(int i=1; i<categories.Count; i++)
                    {
                        if(categories[i].Value == 0)
                        {
                            categories.RemoveAt(i);
                            continue;
                        }

                        if(categories[i].Value < categories[i-1].Value)
                        {
                            var temp = categories[i];
                            categories[i] = categories[i - 1];
                            categories[i - 1] = temp;
                            change = true;
                        }
                    }

                } while (change == true);
            }
        }
    }
}
