using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для Task2.xaml
    /// </summary>
    public partial class Task2 : Window
    {
        public Task2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task4 task4 = new Task4();
            task4.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Task3 task3 = new Task3();
            task3.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow task1 = new MainWindow();
            task1.Show();
            this.Close();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        double CalculateEnergy()
        {
            if (textbox1.Text == "" || textbox2.Text == "")
                MessageBox.Show("Fill in all the fields.\nFor they are empty");
            else
                return (int.Parse(textbox1.Text) + int.Parse(textbox2.Text)) * double.Parse(textbox2.Text);

            return 0.0;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Result.Text = CalculateEnergy().ToString();
        }
    }
}
