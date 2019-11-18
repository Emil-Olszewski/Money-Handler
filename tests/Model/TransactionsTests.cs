using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Money_App.Model.Tests
{
    [TestClass()]
    public class TransactionsTests
    {
        [TestMethod()]
        public void MoveTest()
        {
            Transactions transactions = new Transactions();
            Transaction first = new Transaction(100, "first", "category");
            Transaction second = new Transaction(150, "second", "category");

            transactions.Add(first);
            transactions.Add(second);
            transactions.Move(first, 1);

            Assert.AreEqual(transactions[0], second);
            Assert.AreEqual(transactions[1], first);
        }

        [TestMethod()]
        public void CountBalanceTest()
        {
            Transactions transactions = new Transactions();
            transactions.Add(new Transaction(200, "title", "category"));
            transactions.Add(new Transaction(400, "title", "category"));
            transactions.Add(new Transaction(-100, "title", "category"));

            decimal balance = transactions.CountBalance();

            Assert.AreEqual(balance, 500);
        }

        [TestMethod()]
        public void CountSavedMoneyPercentTest()
        {
            Transactions transactions = new Transactions();
            transactions.Add(new Transaction(800, "title", "category"));
            transactions.Add(new Transaction(200, "title", "category"));
            transactions.Add(new Transaction(-100, "title", "category"));

            decimal savedMoneyPercent = transactions.CountSavedMoneyPercent();

            Assert.AreEqual(savedMoneyPercent, 90M);
        }
    }
}