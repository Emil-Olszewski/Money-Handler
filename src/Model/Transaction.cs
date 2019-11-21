namespace Money_App.Model
{
    public class Transaction
    { 
        public decimal Value { get; private set; }
        public string Title { get; private set; }
        public string Category { get; set; }
        public Transaction(decimal value, string title, string category)
        {
            Value = value;
            Title = title;
            Category = category;
        }
    }
}
