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
    /// Логика взаимодействия для BalanceUAHWindow.xaml
    /// </summary>
    public partial class CurrentBalanceWindow: Window
    {
        public CurrentBalanceWindow()
        {
            InitializeComponent();
        }

        // повернення до попереднього меню
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            BalanceWindow bw = new BalanceWindow();
            bw.Show();
            this.Hide();
        }
        
        // закриття програми після закриття вікна
        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0); 
        }

        // перевірка конфігурації мови при завантаженні вікна
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainMenuWindow.language == 1)
            {
                label2.Content = "Поточний баланс";
                button4.Content = "Назад";
            }

            if (MainMenuWindow.language == 2)
            {
                label2.Content = "Current balance";
                button4.Content = "Back";
            }

        }
    }
}
