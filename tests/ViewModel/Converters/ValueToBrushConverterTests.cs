using Microsoft.VisualStudio.TestTools.UnitTesting;
using Money_App.ViewModel.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Money_App.ViewModel.Converters.Tests
{
    [TestClass()]
    public class ValueToBrushConverterTests
    {
        [TestMethod()]
        public void ConvertTest()
        {
            var converter = new ValueToBrushConverter();
            var realRed = new SolidColorBrush(Color.FromRgb(255, 180, 180));

            var red = converter.Convert(-10M, typeof(SolidColorBrush), null,
                System.Globalization.CultureInfo.CurrentCulture) as SolidColorBrush;

            Assert.AreEqual(red.ToString(), realRed.ToString());
        }
    }
}