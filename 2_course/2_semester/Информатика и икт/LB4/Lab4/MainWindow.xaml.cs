using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Random random;

        const int n = 15;

        public MainWindow()
        {
            InitializeComponent();

            random = new Random();
        }

        public DataTable ToDataTable<T>(T[,] matrix)
        {
            var res = new DataTable();

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                res.Columns.Add("col" + i, typeof(T));
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var row = res.NewRow();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    row[j] = matrix[i, j];
                }

                res.Rows.Add(row);
            }

            return res;
        }

        private void BulidArr(DataGrid dataGrid)
        {
            var array = new int[n, n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    array[i, j] = random.Next(1, 20);
                    //array[i, j] = random.Next(-5, 20);
                    //array[i, j] = random.Next(2, 20);

            int min = array[0, 0];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (array[i, j] <= min)
                        min = array[i, j];
                }
            }

            array[0, 14] = min;

            //использование
            dataGrid1.ItemsSource = ToDataTable(array).DefaultView;
        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BulidArr(dataGrid1);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Task2 task2 = new Task2();
            task2.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Task3 task3 = new Task3();
            task3.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Task4 task4 = new Task4();
            task4.Show();
            this.Close();
        }
    }
}
