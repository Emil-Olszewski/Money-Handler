using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using GalaSoft.MvvmLight.Command;
using Money_App.ViewModel.Commands;

namespace Money_App.ViewModel
{
    public class Transactions : INotifyPropertyChanged
    {
        private readonly Model.Transactions model_transactions;
        public Categories Categories { get; private set; }

        public ObservableCollection<Transaction> TransactionsList { get; private set; }
            = new ObservableCollection<Transaction>();

        public class Deleted
        {
            public int Index;
            public Transaction Transaction;
            public Deleted(int index, Transaction transaction)
            {
                Index = index;
                Transaction = transaction;
            }
        }

        private readonly List<Deleted> deleted = new List<Deleted>();

        public int DeletedCount
            => deleted.Count;

        public Deleted LastDeleted
        {
            get
            {
                if (deleted.Count > 0)
                {
                    var last = deleted[deleted.Count - 1];
                    deleted.Remove(last);
                    return last;
                }
                else
                    return null;
            }
        }

        public decimal Balance
            => model_transactions.CountBalance();

        public decimal SavedMoneyPercent
            => model_transactions.CountSavedMoneyPercent();

        public ObservableCollection<string> CategoriesList
            => Categories.CategoriesList;

        public Transactions()
        {
            model_transactions = new Model.Transactions();
            Categories = new Categories(model_transactions.Categories);
            CopyFromModel();
        }

        private AddTransactionCommand addTransaction;
        public AddTransactionCommand AddTransaction
            => addTransaction ?? (addTransaction = new AddTransactionCommand(this));

        private EditTransactionCommand editTransaction;
        public EditTransactionCommand EditTransaction
            => editTransaction ?? (editTransaction = new EditTransactionCommand(this));

        private RemoveTransactionCommand removeTransaction;
        public RemoveTransactionCommand RemoveTransaction
            => removeTransaction ?? (removeTransaction = new RemoveTransactionCommand(this));

        private RestoreTransactionCommand restoreTransaction;
        public RestoreTransactionCommand RestoreTransaction
            => restoreTransaction ?? (restoreTransaction = new RestoreTransactionCommand(this));
        
        private RelayCommand load;
        public RelayCommand Load
            => load ?? (load = new RelayCommand(() => { model_transactions.Load(); }));

        private RelayCommand save;
        public RelayCommand Save 
            => save ?? (save = new RelayCommand(() => { model_transactions.Save(); }));

        private MoveTransactionUpCommand moveTransactionUp;
        public MoveTransactionUpCommand MoveTransactionUp
            => moveTransactionUp ?? (moveTransactionUp = new MoveTransactionUpCommand(this));

        private MoveTransactionDownCommand moveTransactionDown;
        public MoveTransactionDownCommand MoveTransactionDown
            => moveTransactionDown ?? (moveTransactionDown = new MoveTransactionDownCommand(this));

        public AddCategoryCommand AddCategory
            => Categories.AddCategory;

        private EditCategoryCommand editCategory;
        public EditCategoryCommand EditCategory
            => editCategory ?? (editCategory = new EditCategoryCommand(this));

        public DeleteCategoryCommand DeleteCategory
            => Categories.DeleteCategory;

        public void EditCategories(string from, string to)
        {
            foreach (var transaction in TransactionsList)
                if (transaction.Category == from)
                    transaction.EditCategory(to);
        }

        private void CopyFromModel()
        {
            TransactionsList.CollectionChanged -= SynchroWithModel;
            TransactionsList.Clear();
            foreach (var t in model_transactions)
                TransactionsList.Add(new Transaction(t));
            TransactionsList.CollectionChanged += SynchroWithModel;
        }

        public void SynchroWithModel(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    var newT = (Transaction)e.NewItems[0];
                    if (newT != null)
                        model_transactions.Add(newT.GetModel());
                    break;

                case NotifyCollectionChangedAction.Remove:
                    var oldT = (Transaction)e.OldItems[0];
                    if (oldT != null)
                    {
                        deleted.Add(new Deleted(e.OldStartingIndex, oldT));
                        model_transactions.Remove(oldT.GetModel());
                    }
                    break;

                case NotifyCollectionChangedAction.Move:
                    oldT = (Transaction)e.OldItems[0];
                    if (oldT != null)
                        model_transactions.Move(oldT.GetModel(), TransactionsList.IndexOf(oldT));
                    break;

                case NotifyCollectionChangedAction.Replace:
                    newT = (Transaction)e.NewItems[0];
                    if (newT != null)
                        model_transactions.Replace(e.NewStartingIndex, newT.GetModel());
                    break;
            }

            Update();
        }

        public void Update()
            => OnPropertyChanged("TransactionsList", "Balance", "SavedMoneyPercent");

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(params string[] names)
        {
            foreach (var name in names)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
