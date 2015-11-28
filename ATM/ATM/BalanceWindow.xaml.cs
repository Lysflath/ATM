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
    /// Логика взаимодействия для BalanceWindow.xaml
    /// </summary>
    public partial class BalanceWindow : Window
    {
        public BalanceWindow()
        {
            InitializeComponent();           
        }

        // повернення до попереднього меню
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            MainMenuWindow mmw = new MainMenuWindow();
            mmw.Show();
            this.Hide();
        }

        // закриття програми після закриття вікна
        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0); 
        }

        // виведення поточного балансу
        private void button1_Click(object sender, RoutedEventArgs e)
        {         
            CurrentBalanceWindow cbw = new CurrentBalanceWindow();
            cbw.label3.Content = AuthorizationWindow.balance.ToString() + " UAH";
            cbw.Show();
            this.Hide();
        }

        // виведення поточного балансу у долларах
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            CurrentBalanceWindow cbw = new CurrentBalanceWindow();
            cbw.label3.Content = (AuthorizationWindow.balance / 25).ToString() + " USD";
            cbw.Show();
            this.Hide();
        }

        //виведення поточного балансу у євро
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            CurrentBalanceWindow cbw = new CurrentBalanceWindow();
            cbw.label3.Content = (AuthorizationWindow.balance / 27).ToString() + " EUR";
            cbw.Show();
            this.Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //перевірка конфігурації мови при завантаженні вікна
            if (MainMenuWindow.language == 1)
            {
                label2.Content = "Оберіть валюту";
                button4.Content = "Назад";
            }

            if (MainMenuWindow.language == 2)
            {
                label2.Content = "Choose currency";
                button4.Content = "Back";
            }
        }                

    }
}
