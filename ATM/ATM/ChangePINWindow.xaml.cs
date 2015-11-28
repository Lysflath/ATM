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
    /// Логика взаимодействия для ChangePINWindow.xaml
    /// </summary>
    public partial class ChangePINWindow : Window
    {
        public string changedString; 
        public ChangePINWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //перевірка конфігурації мови при завантаженні вікна
            if (MainMenuWindow.language == 1)
            {
                label2.Content = "Введіть новий PIN";
                button3.Content = "Головне меню";
                button6.Content = "Прийняти";
            }

            if (MainMenuWindow.language == 2)
            {
                label2.Content = "Input new PIN";
                button3.Content = "Main menu";
                button6.Content = "Accept";
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            //прийняття нового PIN-коду і перехід до головного меню
            MainMenuWindow mmw = new MainMenuWindow();
            mmw.Show();
            this.Hide();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            // перевірка того, чи правильні дані вводить користувач 
            try
            {
                changedString = textBox1.Text;
                // помилка при введенні нового паролю
                if (changedString.Length != 4)
                {
                    MessageBox.Show("Дані введені не коректно");
                }

                else
                {
                    // пароль успішно змінено
                    AuthorizationWindow.lines[1] = changedString;
                    File.WriteAllLines(AuthorizationWindow.filePath, AuthorizationWindow.lines);
                    MessageBox.Show("PIN успішно змінено");
                    MainMenuWindow mwm = new MainMenuWindow();
                    mwm.Show();
                    this.Hide();
                }
            }
            catch
            {
                //вивід повідомлення при некоректному введенні паролю
                MessageBox.Show("Дані введені не коректно");
            }
        }

        // закриття програми після закриття вікна
        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
