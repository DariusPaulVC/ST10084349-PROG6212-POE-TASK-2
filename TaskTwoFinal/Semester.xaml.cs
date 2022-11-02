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
using System.Windows.Shapes;

namespace TaskTwoFinal
{
    /// <summary>
    /// Interaction logic for Semester.xaml
    /// </summary>
    public partial class Semester : Window
    {
        SqlConnection sqlConnection = new SqlConnection(@"data source=(localdb)\MSSQLLocalDB;initial catalog=TimeManager;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;");
        public string username;
        public int userID;

        public Semester()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Get this user's ID
            try
            {
                SqlCommand sqlCommand = new SqlCommand("Select UserID FROM users WHERE Username = @username", sqlConnection);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@username", username);
                sqlConnection.Open();
                var userId = sqlCommand.ExecuteScalar();
                sqlConnection.Close();
                userID = Convert.ToInt32(userId);

                //create the object to the ado.net model
                TimeManagerEntities tme = new TimeManagerEntities();
                semester sem = new semester() //object of database
                {
                    SemesterName = tbName.Text,
                    SemesterWeeks = Convert.ToInt32(tbWeeks.Text),
                    SemesterStartDate = Convert.ToDateTime(dpStartDate.Text),
                    UserID = Convert.ToInt32(userId)
                };

                //pass info into database
                tme.semesters.Add(sem);
                int a = tme.SaveChanges(); //save info
                if (a > 0)
                {
                    MessageBox.Show("Semester added");
                    bindGrid(); // refresh
                    dg1.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("An error has occured");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error has occured");
                throw;
            }
            
        }

        public void bindGrid()
        {
            TimeManagerEntities tme = new TimeManagerEntities();
            var userResults = from u in tme.semesters
                              where u.UserID == userID
                              select new { u.SemesterID, u.SemesterName, u.SemesterWeeks, u.SemesterStartDate, u.UserID };
            dg1.ItemsSource = userResults.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Module land = new Module();
            land.Show();
            land.username = username;
            land.semname = tbName.Text;
            this.Hide();
        }
    }
}
