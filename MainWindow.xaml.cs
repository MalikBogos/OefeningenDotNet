using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TextBox tb = new TextBox();
            tb.Visibility = Visibility.Visible;
            tb.Height = 30;
            tb.Width = 200;
            tb.Margin = new Thickness(0, 100, 0, 0);
            tb.HorizontalAlignment = HorizontalAlignment.Left;
            MainGrid.Children.Add(tb);
            Label1.Visibility = Visibility.Visible;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Button1.Content = "Danku voor het klikken!";
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Button2.Content = "Armand is Armand";
        }

        private void LabelTekstVerandering(object sender, MouseButtonEventArgs e)
        {
            if (Label1.Content.ToString() == "Oude Tekst")
            {
                Label1.Content = "Nieuwe Tekst";
            }
            else
            {
                Label1.Content = "Oude Tekst";
            }
        }
    }
}