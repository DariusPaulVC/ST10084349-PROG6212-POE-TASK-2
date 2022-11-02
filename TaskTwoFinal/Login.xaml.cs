using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TaskTwoFinal
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        static string Encrypt(string value)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                //hash data
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }

        public bool Validate(string userName, string password)
        {
            TimeManagerEntities tme = new TimeManagerEntities();
            var userResults = from u in tme.users
                              where u.Username == userName && u.HashedPassword == password
                              select u;
            return Enumerable.Count(userResults) > 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = tbUser.Text;
            string hashpass = Encrypt(pswd.Password);
            var result = Validate(username, hashpass);
            if (result == true)
            {
                MainWindow land = new MainWindow();
                land.Show();
                land.username = tbUser.Text;
                this.Hide();
            }
            else
            {
                MessageBox.Show("Details entered are incorect. Please use your correct details");
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Register land = new Register();
            land.Show();
            this.Close();
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Register land = new Register();
            land.Show();
            this.Close();
        }
    }
}
