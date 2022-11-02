using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TaskTwoFinal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection sqlConnection = new SqlConnection(@"data source=(localdb)\MSSQLLocalDB;initial catalog=TimeManager;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;");
        public string username;

        public MainWindow()
        {
            InitializeComponent();
            updateUI();
        }

        public void updateUI()
        {
            lblWelcome.Content = "Welcome " + username;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Module m = new Module();
            m.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Semester s = new Semester();
            s.Show();
            s.username = username;
            this.Hide();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlCommand cmd = sqlConnection.CreateCommand())
                {
                    sqlConnection.Open();
                    cmd.CommandText = "Select u.Username, s.SemesterName, s.SemesterStartDate, m.ModuleCode, m.ModuleName, m.Credits, m.StudyDate, m.SelfStudyHours " +
                    "FROM users u INNER JOIN semester s on s.UserID = u.UserID INNER JOIN modules m on m.UserID = u.UserID and m.SemesterID = s.SemesterID " +
                    "WHERE Username = @username";
                    cmd.Parameters.AddWithValue("@username", username);
                    SqlDataAdapter adap = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adap.Fill(ds);
                    dg1.ItemsSource = ds.Tables[0].DefaultView;
                    sqlConnection.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error has occured");
            }
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
