using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SharafutdinovKR_laba6
{
    public partial class Task3 : Window
    {
        private int[] originalArray;
        private int[] processedArray;

        public Task3()
        {
            InitializeComponent();
        }

        private void CreateArrayButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = InputTextBox.Text.Trim();
                if (string.IsNullOrEmpty(input))
                    throw new ArgumentException("Введите элементы массива");

                string[] parts = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                originalArray = new int[parts.Length];

                for (int i = 0; i < parts.Length; i++)
                {
                    if (!int.TryParse(parts[i], out int number))
                        throw new ArgumentException($"'{parts[i]}' не является целым числом");
                    originalArray[i] = number;
                }

                DisplayArray(originalArray, OriginalArrayItems);
                InfoTextBlock.Text = $"Создан массив из {originalArray.Length} элементов";
                ProcessButton.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ProcessButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (originalArray == null)
                    throw new InvalidOperationException("Сначала создайте массив");

                processedArray = new int[originalArray.Length];
                Array.Copy(originalArray, processedArray, originalArray.Length);

                for (int i = 0; i < processedArray.Length; i++)
                {
                    if (i % 2 == 0) 
                    {
                        processedArray[i] = processedArray[i] * processedArray[i]; 
                    }
                    else 
                    {
                        processedArray[i] = processedArray[i] * processedArray[i] * processedArray[i]; 
                    }
                }

                DisplayArray(processedArray, ProcessedArrayItems);

                string info = "Результат:\n";
                for (int i = 0; i < originalArray.Length; i++)
                {
                    if (i % 2 == 0)
                        info += $"[{i}] {originalArray[i]} → {originalArray[i]}² = {processedArray[i]}\n";
                    else
                        info += $"[{i}] {originalArray[i]} → {originalArray[i]}³ = {processedArray[i]}\n";
                }

                InfoTextBlock.Text = info;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            InputTextBox.Clear();
            originalArray = null;
            processedArray = null;
            OriginalArrayItems.ItemsSource = null;
            ProcessedArrayItems.ItemsSource = null;
            InfoTextBlock.Text = "Введите элементы массива";
            ProcessButton.IsEnabled = false;
        }

        private void DisplayArray(int[] array, ItemsControl itemsControl)
        {
            var items = new List<int>(array);
            itemsControl.ItemsSource = items;
        }
    }
}