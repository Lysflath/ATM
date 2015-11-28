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
    /// Логика взаимодействия для IssuanceOperationWindow.xaml
    /// </summary>
    public partial class IssuanceOperationWindow : Window
    {
        public IssuanceOperationWindow()
        {
            InitializeComponent();
        }

        // закриття програми після закриття вікна
        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0); 
        }

        // перехід до наступного вікна
        private void image1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PostIssuanceOperation pio = new PostIssuanceOperation();
            pio.Show();
            this.Hide();
        }

        // перевірка конфігурації мови при завантаженні вікна
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainMenuWindow.language == 1)
            label2.Content = "Отримайте гроші";

            if (MainMenuWindow.language == 2)
            label2.Content = "Get your money";

        }
    }
}
