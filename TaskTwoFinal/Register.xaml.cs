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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tbName.Text.Equals("") || tbEmail.Text.Equals("") || pswdBox.Password.Equals("") || pswdBox2.Equals(""))
            {
                MessageBox.Show("Please fill in all available fields");
            }

            if (pswdBox.Password.Equals(pswdBox2.Password))
            {
                //create the object to the ado.net model
                TimeManagerEntities tme = new TimeManagerEntities();
                user u = new user() //object of database
                {
                    Username = tbName.Text,
                    Email = tbEmail.Text,
                    HashedPassword = Encrypt(pswdBox.Password)
                };
                //pass info into database
                tme.users.Add(u);
                tme.SaveChanges(); //save info

                MessageBox.Show("Thank you for creating an account");
                Login land = new Login();
                land.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Passwords do not match");
            }
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Login land = new Login();
            land.Show();
            this.Close();
        }
    }
}
