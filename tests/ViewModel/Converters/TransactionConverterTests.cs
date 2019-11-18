using Microsoft.VisualStudio.TestTools.UnitTesting;
using Money_App.ViewModel.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money_App.ViewModel.Converters.Tests
{
    [TestClass()]
    public class TransactionConverterTests
    {
        [TestMethod()]
        public void ConvertTest()
        {
            var converter = new TransactionConverter();
            string[] values =
            {
                "1000",
                "Title",
                "Category"
            };

            var transation = converter.Convert(values, typeof(Transaction), null,
                System.Globalization.CultureInfo.CurrentCulture) as Transaction;

            Assert.AreEqual(transation.Value.ToString(), values[0]);
            Assert.AreEqual(transation.Title, values[1]);
            Assert.AreEqual(transation.Category, values[2]);
        }
    }
}