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
    /// Логика взаимодействия для Telephone_Window.xaml
    /// </summary>
    public partial class Telephone_Window : Window
    {
        public Telephone_Window()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainMenuWindow.language == 1)
            {
                label2.Content = "Введіть номер телефону";
                button3.Content = "Назад";
                button6.Content = "Прийняти";
            }

            if (MainMenuWindow.language == 2)
            {
                label2.Content = "Input telephone number";
                button3.Content = "Back";
                button6.Content = "Accept";
            }
            
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int number = int.Parse(textBox1.Text);
                string number_string = textBox1.Text;
                if ((number_string.Length < 6) && (MainMenuWindow.language == 1))
                {
                    MessageBox.Show("Неправильно введений номер");
                }
                if ((number_string.Length < 6) && (MainMenuWindow.language == 2))
                {
                    MessageBox.Show("Invalid number");
                }
                else 
                {
                    TelephonePaymentWindow tpw = new TelephonePaymentWindow();
                    tpw.Show();
                    this.Hide();
                }
            }
            catch 
            {
                if (MainMenuWindow.language == 1)   
                    MessageBox.Show("Неправильно введений номер");
                if (MainMenuWindow.language == 2)
                    MessageBox.Show("Invalid number");
            }                      
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            MainMenuWindow mmw = new MainMenuWindow();
            mmw.Show();
            this.Hide();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
