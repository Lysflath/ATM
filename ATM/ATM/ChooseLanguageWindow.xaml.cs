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

        // Зміна мови на українську
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            MainMenuWindow.language = 1;
            MainMenuWindow mmw = new MainMenuWindow();
            mmw.Show();
            this.Hide();
        }

        // закриття програми після закриття вікна
        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0); 
        }

        // зміна мови на англійську
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MainMenuWindow.language = 2;
            MainMenuWindow mmw = new MainMenuWindow();
            mmw.Show();
            this.Hide();            
        }
    }
}
