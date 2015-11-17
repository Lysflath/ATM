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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ATM
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int balance = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void image1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // формування випадкового числа, яке буде становити кошти користувача
            Random rand = new Random();
            balance = rand.Next(20000);

            ChooseLanguageWindow ChoseLang = new ChooseLanguageWindow();

            // перехід до головного меню
            ChoseLang.Show();
            this.Hide();
        }

        //закриття програми після закриття вікна
        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
