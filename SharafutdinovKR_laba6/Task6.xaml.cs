using System;
using System.Windows;

namespace SharafutdinovKR_laba6
{
    public partial class Task6 : Window
    {
        public Task6()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!int.TryParse(FirstTextBox.Text, out int first))
                    throw new ArgumentException("Ошибка: Номинал купюры введен некорректно");

                int[] validNominals = { 1, 2, 5, 10, 50, 100, 500, 1000, 5000 };
                if (Array.IndexOf(validNominals, first) == -1)
                    throw new ArgumentException($"Ошибка: Номинал должен быть одним из значений: 1, 2, 5, 10, 50, 100, 500, 1000, 5000");

                if (!int.TryParse(SecondTextBox.Text, out int second))
                    throw new ArgumentException("Ошибка: Количество купюр введено некорректно");

                if (second <= 0)
                    throw new ArgumentException("Ошибка: Количество купюр должно быть положительным числом");

                Banknote banknote = new Banknote(first, second);
                long totalSum = banknote.Summa();

                ResultTextBlock.Text = $"Сумма: {totalSum} руб.\n" +
                                      $"({first} руб. * {second} шт. = {totalSum} руб.)";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    public class Banknote
    {
        private int first; 
        private int second; 


        public Banknote(int first, int second)
        {
            int[] validNominals = { 1, 2, 5, 10, 50, 100, 500, 1000, 5000 };
            if (Array.IndexOf(validNominals, first) == -1)
                throw new ArgumentException("Недопустимый номинал купюры");

            if (second <= 0)
                throw new ArgumentException("Количество купюр должно быть положительным числом");

            this.first = first;
            this.second = second;
        }

        public int First
        {
            get { return first; }
            set
            {
                int[] validNominals = { 1, 2, 5, 10, 50, 100, 500, 1000, 5000 };
                if (Array.IndexOf(validNominals, value) == -1)
                    throw new ArgumentException("Недопустимый номинал купюры");
                first = value;
            }
        }

        public int Second
        {
            get { return second; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Количество купюр должно быть положительным числом");
                second = value;
            }
        }

        public long Summa()
        {
            return (long)first * second;
        }

        public override string ToString()
        {
            return $"Купюра номиналом {first} руб. в количестве {second} шт.";
        }
    }
}
