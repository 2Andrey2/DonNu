using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для Task3.xaml
    /// </summary>
    public partial class Task3 : Window
    {
        public Task3()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow task1 = new MainWindow();
            task1.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Task2 task2 = new Task2();
            task2.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Task4 task4 = new Task4();
            task4.Show();
            this.Close();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,-]+");

            e.Handled = regex.IsMatch(e.Text);
        }

        void CalcEquation()
        {

            int result = textbox1.Text.ToString().Sum(c => c - '0');

            if (textbox1.Text == "")
                MessageBox.Show("X is empty");
            else
            {
                Formula.Text = result % 2 == 0 ? $"{int.Parse(textbox1.Text) * 2}" : $"{int.Parse(textbox1.Text) / 2}";
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            CalcEquation(); 
        }
    }
}
