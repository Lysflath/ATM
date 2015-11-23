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
    /// Логика взаимодействия для RemittancesWindow.xaml
    /// </summary>
    public partial class RemittancesWindow : Window
    {
        public static string filePathGetter;
        static public string otherCardNumber;
        public static string[] linesGetter;
        public RemittancesWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainMenuWindow.language == 1)
            {
                label2.Content = "Введіть номер картки";
                button3.Content = "Назад";
                button6.Content = "Прийняти";
            }

            if (MainMenuWindow.language == 2)
            {
                label2.Content = "Input card number";
                button3.Content = "Back";
                button6.Content = "Accept";
            }

        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AuthorizationWindow.path = ("db");
                DirectoryInfo dir = new DirectoryInfo(AuthorizationWindow.path);
                foreach (FileInfo file in dir.GetFiles())
                {
                    linesGetter = File.ReadAllLines(@file.FullName, Encoding.Default);
                    if (linesGetter[0] == textBox1.Text && linesGetter[0] != AuthorizationWindow.cardNumber)
                    {
                        filePathGetter = file.FullName;
                        RemmitancePaymentWindow rpw = new RemmitancePaymentWindow();
                        rpw.Show();
                        this.Hide();
                        break;
                    }
                }                
            }
            catch
            {
                if (MainMenuWindow.language == 1)
                    MessageBox.Show("Неправильно введений номер");
                if (MainMenuWindow.language == 2)
                    MessageBox.Show("Invalid number");
            }

            if (AuthorizationWindow.lines[0] == textBox1.Text)
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
