using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Money_App.ViewModel.Converters.Tests
{
    [TestClass()]
    public class SelectedTransactionConverterTests
    {
        [TestMethod()]
        public void ConvertTest()
        {
            var converter = new SelectedTransactionConverter();
            object[] values =
            {
                0,
                "1000",
                "Title",
                "Category"
            };

            var transaction = converter.Convert(values, typeof(SelectedTransaction), null, 
                System.Globalization.CultureInfo.CurrentCulture) as SelectedTransaction;

            Assert.AreEqual(transaction.Index, values[0]);
            Assert.AreEqual(transaction.Transaction.Value.ToString(), values[1]);
            Assert.AreEqual(transaction.Transaction.Title, values[2]);
            Assert.AreEqual(transaction.Transaction.Category, values[3]);
        }
    }
}