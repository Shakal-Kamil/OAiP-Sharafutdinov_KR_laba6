using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace SharafutdinovKR_laba6
{
    public partial class Task4 : Window
    {
        private double[,] originalMatrix;
        private double[,] resultMatrix;
        private const int MatrixSize = 12;

        public Task4()
        {
            InitializeComponent();
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Random rand = new Random();
                originalMatrix = new double[MatrixSize, MatrixSize];
                for (int i = 0; i < MatrixSize; i++)
                {
                    for (int j = 0; j < MatrixSize; j++)
                    {
                        originalMatrix[i, j] = Math.Round(rand.NextDouble() * 100, 2);
                    }
                }

                DisplayMatrix(originalMatrix, OriginalMatrixGrid);
                InfoTextBlock.Text = $"Сгенерирована матрица {MatrixSize}×{MatrixSize}";
                ProcessButton.IsEnabled = true;
                ResultMatrixGrid.ItemsSource = null;
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
                if (originalMatrix == null)
                    throw new InvalidOperationException("Сначала сгенерируйте матрицу");

                resultMatrix = (double[,])originalMatrix.Clone();

                for (int i = 0; i < MatrixSize; i++)
                {
                    for (int j = 0; j < MatrixSize; j++)
                    {
                        if (i == j)
                        {
                            resultMatrix[i, j] = 0;
                        }
                        else if (j > i)
                        {
                            resultMatrix[i, j] = 1;
                        }
                    }
                }

                DisplayMatrix(resultMatrix, ResultMatrixGrid);
                InfoTextBlock.Text = "Матрица обработана: диагональ обнулена, элементы выше диагонали заменены на 1";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DisplayMatrix(double[,] matrix, DataGrid dataGrid)
        {
            var rowsCollection = new ObservableCollection<MatrixRow>();

            for (int i = 0; i < MatrixSize; i++)
            {
                var row = new MatrixRow { RowNumber = i + 1 };
                for (int j = 0; j < MatrixSize; j++)
                {
                    row.ColumnValues.Add(matrix[i, j]);
                }
                rowsCollection.Add(row);
            }

            dataGrid.ItemsSource = rowsCollection;
        }
    }

    public class MatrixRow
    {
        public int RowNumber { get; set; }
        public ObservableCollection<double> ColumnValues { get; set; } = new ObservableCollection<double>();
    }
}