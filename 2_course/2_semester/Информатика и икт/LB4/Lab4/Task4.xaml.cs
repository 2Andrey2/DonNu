using System;
using System.Collections.Generic;
using System.Text;
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
    /// Логика взаимодействия для Task4.xaml
    /// </summary>
    public partial class Task4 : Window
    {
        public Task4()
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
            Task3 task3 = new Task3();
            task3.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            const double procent = 0.2;

            int year = 1990;
            double veight = 20;

            while (veight >= 5)
            {
                veight -= veight * procent;
                year += 2;
            }
            
            Farengate.Text = $"В {year} году урожай составит {Math.Round(veight, 3)} тонн.";
        }
    }
}
