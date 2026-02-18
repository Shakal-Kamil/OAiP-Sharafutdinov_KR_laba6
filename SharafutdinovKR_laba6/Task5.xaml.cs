using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SharafutdinovKR_laba6
{
    public partial class Task5 : Window
    {
        private double[,] originalMatrix;
        private double[,] rotatedMatrix;
        private int rows, cols;

        public Task5()
        {
            InitializeComponent();
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!int.TryParse(RowsTextBox.Text, out rows) || rows <= 0)
                    throw new ArgumentException("Количество строк должно быть положительным целым числом");
                if (!int.TryParse(ColsTextBox.Text, out cols) || cols <= 0)
                    throw new ArgumentException("Количество столбцов должно быть положительным целым числом");

                Random rand = new Random();
                originalMatrix = new double[rows, cols];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        originalMatrix[i, j] = Math.Round(rand.NextDouble() * 10, 2);
                    }
                }

                DisplayMatrix(originalMatrix, rows, cols, OriginalMatrixGrid);
                InfoTextBlock.Text = $"Сгенерирована матрица {rows}×{cols}";
                RotateButton.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RotateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (originalMatrix == null)
                    throw new InvalidOperationException("Сначала сгенерируйте матрицу");

                rotatedMatrix = new double[cols, rows];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        rotatedMatrix[j, rows - 1 - i] = originalMatrix[i, j];
                    }
                }

                DisplayMatrix(rotatedMatrix, cols, rows, RotatedMatrixGrid);
                InfoTextBlock.Text = $"Матрица повернута на 90°. Новая размерность: {cols}×{rows}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DisplayMatrix(double[,] matrix, int displayRows, int displayCols, DataGrid dataGrid)
        {
            dataGrid.Columns.Clear();

            var indexColumn = new DataGridTextColumn
            {
                Header = "№",
                Binding = new Binding("Index"),
                Width = 50
            };
            dataGrid.Columns.Add(indexColumn);

            for (int j = 0; j < displayCols; j++)
            {
                var column = new DataGridTextColumn
                {
                    Header = $"[,{j + 1}]",
                    Binding = new Binding($"Values[{j}]"),
                    Width = 70
                };
                dataGrid.Columns.Add(column);
            }

            var rowsCollection = new ObservableCollection<MatrixRows>();
            for (int i = 0; i < displayRows; i++)
            {
                var row = new MatrixRows { Index = i + 1 };
                for (int j = 0; j < displayCols; j++)
                {
                    row.Values.Add(matrix[i, j]);
                }
                rowsCollection.Add(row);
            }

            dataGrid.ItemsSource = rowsCollection;
        }
    }

    public class MatrixRows
    {
        public int Index { get; set; }
        public ObservableCollection<double> Values { get; set; } = new ObservableCollection<double>();
    }
}
