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
using System.IO;

namespace ATM
{
    /// <summary>
    /// Логика взаимодействия для TelephonePaymentWindow.xaml
    /// </summary>
    public partial class TelephonePaymentWindow : Window
    {
        public TelephonePaymentWindow()
        {
            InitializeComponent();
        }

        // перевіока конфігурації мови при завантаженні вікна
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainMenuWindow.language == 1)
            {
                label2.Content = "Введіть cуму";
                button3.Content = "Головне меню";
                button6.Content = "Прийняти";
            }

            if (MainMenuWindow.language == 2)
            {
                label2.Content = "Input sum";
                button3.Content = "Main menu";
                button6.Content = "Accept";
            }
        }

        // перехід до попереднього меню
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Telephone_Window tw = new Telephone_Window();
            tw.Show();
            this.Hide();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            // перевірка того, чи правильні дані вводить користувач 
            try
            {
                AuthorizationWindow.balance -= int.Parse(textBox1.Text);
                if (AuthorizationWindow.balance < 0)
                {
                    AuthorizationWindow.balance += int.Parse(textBox1.Text);
                    MessageBox.Show("Помилка, недостатньо коштів");
                }

                else
                {
                    // коли гроші знято успішно, оновлені дані записуються у файл користувача
                    AuthorizationWindow.lines[2] = AuthorizationWindow.balance.ToString();
                    File.WriteAllLines(AuthorizationWindow.filePath, AuthorizationWindow.lines);
                    MainMenuWindow mwm = new MainMenuWindow();
                    mwm.Show();
                    this.Hide();
                }
            }
            catch
            {
                MessageBox.Show("Дані введені не коректно");
            }            
        }

        // вихід із програми при закритті вікна
        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
