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
            path = ("db"); //задання шляху до директорії із файлами користувачів банкомату
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach(FileInfo file in dir.GetFiles()) //зчитування даних із кожного файлу у вказаній директорії
            {
                lines = File.ReadAllLines(@file.FullName, Encoding.Default);
                if (lines[1] == textBox2.Text) //перевірка на правильно введений пароль для того чи іншого користувача
                {
                    filePath = file.FullName; //
                    pin = lines[1]; //зчитування значення паролю активного користувача у стрічку для подальших операцій(зміна пароля)
                    balance = int.Parse(lines[2]); //зчитування значення балансу картки активного користувача у змінну для подальших операцій(переказ)
                    cardNumber = lines[0]; //зчитування значення номеру картки активного користувача у стрічку для подальших операцій(переказ грошей між користувачами)

                    ChooseLanguageWindow ChoseLang = new ChooseLanguageWindow();
                    // перехід до головного меню та вихід із циклу
                    ChoseLang.Show();
                    this.Hide();
                    break;
                }
            }
            // коли пароль введено не вірно(не знайдено відповідного паролю у файлах користувачів), виводиться повідомлення про помилку
            if(lines[1] != textBox2.Text)
            MessageBox.Show("Invalid passworld");
        }

        // закриття програми після закриття вікна
        private void Window_Closed(object sender, EventArgs e)
        {            
            Environment.Exit(0);
        }
    }
}
