using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Money_App.ViewModel.Converters.Tests
{
    [TestClass()]
    public class DotValueToCommaValueConverterTests
    {
        [TestMethod()]
        public void ConvertTest()
        {
            var converter = new DotValueToCommaValueConverter();

            var obj = converter.Convert(100.5M, typeof(string), null, 
                System.Globalization.CultureInfo.CurrentCulture) as string;

            Assert.IsTrue(obj.Contains(","));
            Assert.IsTrue(!obj.Contains("."));
        }
    }
}