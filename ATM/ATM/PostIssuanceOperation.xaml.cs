using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ATM
{
    /// <summary>
    /// Логика взаимодействия для PostIssuanceOperation.xaml
    /// </summary>
    public partial class PostIssuanceOperation : Window
    {
        public PostIssuanceOperation()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            MainMenuWindow mmw = new MainMenuWindow();
            mmw.Show();
            this.Hide();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainMenuWindow.language == 1)
            {
                label2.Content = "Оберіть послугу";
                button3.Content = "Головне меню";
                button6.Content = "Завершити";
            }

            if (MainMenuWindow.language == 2)
            {
                label2.Content = "Choose service";
                button3.Content = "Main menu";
                button6.Content = "Exit";
            }
        }
    }
}
