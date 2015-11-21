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
    /// Логика взаимодействия для MainMenuWindow.xaml
    /// </summary>
    public partial class MainMenuWindow : Window
    {
        public static int language;
        public MainMenuWindow()
        {
            InitializeComponent();
        }

        // перехід до режиму "баланс"
        private void button1_Click(object sender, RoutedEventArgs e)
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

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            MoneyIssuanceMainWindow mimw = new MoneyIssuanceMainWindow();
            mimw.Show();
            this.Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ChooseLanguageWindow clw = new ChooseLanguageWindow();
            if (MainMenuWindow.language == 2)
            {
                label2.Content = "Choose service";
                button1.Content = "Card balance";
                button2.Content = "Cash issuance";
                button3.Content = "Telephone";
                button4.Content = "Remittances";
                button5.Content = "Settings";
                button6.Content = "Exit";                
            }
            if (MainMenuWindow.language == 1)
            {
                label2.Content = "Оберіть послугу";
                button1.Content = "Баланс картки";
                button2.Content = "Видача коштів";
                button3.Content = "Телефон";
                button4.Content = "Перекази";
                button5.Content = "Налаштування";
                button6.Content = "Вихід";
            }

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Telephone_Window tw = new Telephone_Window();
            tw.Show();
            this.Hide();
        }
    }
}
