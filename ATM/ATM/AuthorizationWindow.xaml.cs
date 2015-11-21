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
using System.Reflection;

namespace ATM
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public static string cardNumber;
        public static string path;
        public static string filePath;        
        public static string pin;
        public static string[] lines;        
        public static int balance = 0;
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            //path = System.IO.Path.GetFullPath(Assembly.GetExecutingAssembly().Location);
            path = ("db");
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach(FileInfo file in dir.GetFiles())
            {
                lines = File.ReadAllLines(@file.FullName, Encoding.Default);
                if (lines[1] == textBox2.Text)
                {
                    filePath = file.FullName;
                    pin = lines[1];
                    balance = int.Parse(lines[2]);
                    label3.Content = balance;
                    cardNumber = lines[0];

                    ChooseLanguageWindow ChoseLang = new ChooseLanguageWindow();
                    // перехід до головного меню
                    ChoseLang.Show();
                    this.Hide();
                    break;
                }
            }
            if(lines[1] != textBox2.Text)
            MessageBox.Show("Invalid passworld");
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
