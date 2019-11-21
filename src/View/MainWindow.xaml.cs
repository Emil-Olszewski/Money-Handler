using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace Money_App.View
{
    public partial class MainWindow : Window
    {
        public MainWindow() 
            => InitializeComponent();

        private void bAddTransaction_Click(object sender, RoutedEventArgs e)
        {
            if (VisualTreeHelper.GetChildrenCount(lbTransactions) > 0)
            {
                Border border = (Border)VisualTreeHelper.GetChild(lbTransactions, 0);
                ScrollViewer scrollViewer = (ScrollViewer)VisualTreeHelper.GetChild(border, 0);
                scrollViewer.ScrollToBottom();
            }
        }
    }
}


