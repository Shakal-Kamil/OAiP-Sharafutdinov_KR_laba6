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

namespace SharafutdinovKR_laba6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        void task1(object s, RoutedEventArgs e) => new Task1().Show();
        void task2(object s, RoutedEventArgs e) => new Task2().Show();
        void task3(object s, RoutedEventArgs e) => new Task3().Show();
        void task4(object s, RoutedEventArgs e) => new Task4().Show();
        void task5(object s, RoutedEventArgs e) => new Task5().Show();
        void task6(object s, RoutedEventArgs e) => new Task6().Show();
    }
}