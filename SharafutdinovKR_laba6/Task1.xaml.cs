using System;
using System.Windows;
using System.Windows.Controls;

namespace SharafutdinovKR_laba6
{
    public partial class Task1 : Window
    {
        public Task1 ()
        {
            InitializeComponent();
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!double.TryParse(XTextBox.Text, out double x))
                    throw new ArgumentException("Ошибка: Координата X введена некорректно");

                if (!double.TryParse(YTextBox.Text, out double y))
                    throw new ArgumentException("Ошибка: Координата Y введена некорректно");

                bool isInside = (x * x + y * y) <= 1;

                string result = isInside
                    ? $"Точка ({x:F2}, {y:F2}) принадлежит заштрихованной области"
                    : $"Точка ({x:F2}, {y:F2}) НЕ принадлежит заштрихованной области";

                ResultTextBlock.Text = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}