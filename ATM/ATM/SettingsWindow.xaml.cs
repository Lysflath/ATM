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
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        // перевірка конфігурації мови, при завантаженні вікна
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainMenuWindow.language == 1)
            {
                label2.Content = "Оберіть послугу";
                button1.Content = "Змінити мову";
                button3.Content = "Змінити PIN";
                button6.Content = "Назад";
            }

            if (MainMenuWindow.language == 2)
            {
                label2.Content = "Choose service";
                button1.Content = "Change language";
                button3.Content = "Change PIN";
                button6.Content = "Back";
            }

        }

        //  перехід у головне вікно
        private void button6_Click(object sender, RoutedEventArgs e)
        {
            MainMenuWindow mmw = new MainMenuWindow();
            mmw.Show();
            this.Hide();
        }
        
        // перехід у меню зміни паролю
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            ChangePINWindow cpw = new ChangePINWindow();
            cpw.Show();
            this.Hide();
        }

        // вихід із приграми при закритті вікна
        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        // зміна мови
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (MainMenuWindow.language == 1)
            {
                MainMenuWindow.language = 2;
                MessageBox.Show("Language succesfully changed");
                MainMenuWindow mmw = new MainMenuWindow();
                mmw.Show();
                this.Hide();
            }
            else
            {
                MainMenuWindow.language = 1;
                MessageBox.Show("Мову успішно змінено");
                MainMenuWindow mmw = new MainMenuWindow();
                mmw.Show();
                this.Hide();
            }

        }
    }
}
