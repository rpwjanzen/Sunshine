using System.Windows;
using System.Windows.Controls;

namespace LoggingTest
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            new Frobber();
        }
    }
}
