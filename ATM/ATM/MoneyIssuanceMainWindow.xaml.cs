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
    /// Логика взаимодействия для MoneyIssuanceMainWindow.xaml
    /// </summary>
    public partial class MoneyIssuanceMainWindow : Window
    {
        public MoneyIssuanceMainWindow()
        {
            InitializeComponent();
        }

        // повернення до головного меню
        private void button6_Click(object sender, RoutedEventArgs e)
        {
            MainMenuWindow mmw = new MainMenuWindow();
            mmw.Show();
            this.Hide();
        }

        // закриття програми при закритті вікна
        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        // зняття 50 грошових одиниць
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow.balance -= 50;
            // якщо баланс користувача нижче 0, то виводиться повідомлення про помилку
            if (AuthorizationWindow.balance < 0)
            {
                AuthorizationWindow.balance += 50;
                MessageBox.Show("Помилка, недостатньо коштів");
            }

            // якщо дані введені корректно, то операція проводиться, і оновлені дані записуються у файл користувача
            else
            {
                AuthorizationWindow.lines[2] = AuthorizationWindow.balance.ToString();
                File.WriteAllLines(AuthorizationWindow.filePath,AuthorizationWindow.lines);
                IssuanceOperationWindow iow = new IssuanceOperationWindow();
                iow.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow.balance -= 100;
            if (AuthorizationWindow.balance < 0)
            {
                AuthorizationWindow.balance += 100;
                MessageBox.Show("Помилка, недостатньо коштів");
            }

            else
            {
                AuthorizationWindow.lines[2] = AuthorizationWindow.balance.ToString();
                File.WriteAllLines(AuthorizationWindow.filePath, AuthorizationWindow.lines);
                IssuanceOperationWindow iow = new IssuanceOperationWindow();
                iow.Show();
                this.Hide();
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow.balance -= 200;
            if (AuthorizationWindow.balance < 0)
            {
                AuthorizationWindow.balance += 200;
                MessageBox.Show("Помилка, недостатньо коштів");
            }

            else
            {
                AuthorizationWindow.lines[2] = AuthorizationWindow.balance.ToString();
                File.WriteAllLines(AuthorizationWindow.filePath, AuthorizationWindow.lines);

                IssuanceOperationWindow iow = new IssuanceOperationWindow();
                iow.Show();
                this.Hide();
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow.balance -= 500;
            if (AuthorizationWindow.balance < 0)
            {
                AuthorizationWindow.balance += 500;
                MessageBox.Show("Помилка, недостатньо коштів");
            }

            else
            {
                AuthorizationWindow.lines[2] = AuthorizationWindow.balance.ToString();
                File.WriteAllLines(AuthorizationWindow.filePath, AuthorizationWindow.lines);
                IssuanceOperationWindow iow = new IssuanceOperationWindow();
                iow.Show();
                this.Hide();
            }
        }

        // перехід до персонального введення суми видачі
        private void button5_Click(object sender, RoutedEventArgs e)
        {
            IssuanceInputSumWindow iisw = new IssuanceInputSumWindow();
            iisw.Show();
            this.Hide();
        }

        // перевірка конфігурації мови при завантаженні вікна
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainMenuWindow.language == 1)
            {
                label2.Content = "Оберіть суму";
                button5.Content = "Інша сума";
                button6.Content = "Назад";
            }

            if (MainMenuWindow.language == 2)
            {
                label2.Content = "Get your money";
                button5.Content = "Other sum";
                button6.Content = "Back";
            }
        }
    }
}
