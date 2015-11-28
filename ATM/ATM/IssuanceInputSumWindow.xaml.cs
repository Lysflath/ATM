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
    /// Логика взаимодействия для IssuanceInputSumWindow.xaml
    /// </summary>
    public partial class IssuanceInputSumWindow : Window
    {
        public IssuanceInputSumWindow()
        {
            InitializeComponent();
        }

        // повернення до головного меню грошових переказів
        private void button6_Click(object sender, RoutedEventArgs e)
        {
            MoneyIssuanceMainWindow mimw = new MoneyIssuanceMainWindow();
            mimw.Show();
            this.Hide();
        }

        // відправлення переказу
        private void button3_Click(object sender, RoutedEventArgs e)
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
                    IssuanceOperationWindow iow = new IssuanceOperationWindow();
                    iow.Show();
                    this.Hide();
                }
            }
            catch 
            {
                // при введенні недопустимих значень виводиться повідомлення про помилку
                MessageBox.Show("Дані введені не коректно");
            }
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
                label2.Content = "Введіть суму";
                button3.Content = "Прийняти";
                button6.Content = "Назад";
            }

            if (MainMenuWindow.language == 2)
            {
                label2.Content = "Input sum";
                button3.Content = "Accept";
                button6.Content = "Back";
            }
        }
    }
}
