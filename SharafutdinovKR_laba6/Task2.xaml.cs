using System;
using System.Text;
using System.Windows;

namespace SharafutdinovKR_laba6
{
    public partial class Task2 : Window
    {
        public Task2()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int number = int.Parse(InputTextBox.Text);

                if (number < 0)
                {
                    MessageBox.Show("Введите неотрицательное число!", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                StringBuilder details = new StringBuilder();
                details.AppendLine("Детали вычислений:");
                details.AppendLine($"Исходное число: {number}");

                int count = 0;
                int temp = number;

                if (temp == 0)
                {
                    count = 1;
                    details.AppendLine("Число равно 0 -> количество цифр: 1");
                }
                else
                {
                    details.AppendLine("Выполняем целочисленное деление на 10:");

                    while (temp > 0)
                    {
                        count++;
                        details.AppendLine($"Шаг {count}: {temp} / 10 = {temp / 10}");
                        temp /= 10; 
                    }
                }

                ResultTextBlock.Text = $"Количество цифр в числе {number}: {count}";
                DetailsTextBlock.Text = details.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите корректное целое число!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}