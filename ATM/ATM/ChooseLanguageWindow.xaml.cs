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
    /// Логика взаимодействия для ChooseLanguageWindow.xaml
    /// </summary>
    public partial class ChooseLanguageWindow : Window
    {
        public ChooseLanguageWindow()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            MainMenuWindow mmw = new MainMenuWindow();
            mmw.Show();
            this.Hide();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MainMenuWindow mmw = new MainMenuWindow();
            mmw.Show();
            this.Hide();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            MainMenuWindow mmw = new MainMenuWindow();
            mmw.Show();
            this.Hide();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            MainMenuWindow mmw = new MainMenuWindow();
            mmw.Show();
            this.Hide();
        }

    }
}
