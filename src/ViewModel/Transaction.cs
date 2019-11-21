namespace Money_App.ViewModel
{
    public class Transaction
    {
        private Model.Transaction model_transaction;

        public decimal Value
            => model_transaction.Value;

        public string Title
            => model_transaction.Title;

        public string Category
            => model_transaction.Category;

        public Transaction(Model.Transaction t)
            => model_transaction = t;

        public Transaction(decimal value, string title, string category)
            => model_transaction = new Model.Transaction(value, title, category);

        public Model.Transaction GetModel()
            => model_transaction;

        public void EditCategory(string newCategory)
            => model_transaction.Category = newCategory;

        public static bool Verify(Transaction t)
            => t != null && t.Value != 0 && !string.IsNullOrWhiteSpace(t.Title) 
            && !string.IsNullOrWhiteSpace(t.Category);
    }

    public class SelectedTransaction
    {
        public int Index;
        public Transaction Transaction;
        
        public SelectedTransaction(int index, Transaction transaction)
        {
            Index = index;
            Transaction = transaction;
        }
    }
}
