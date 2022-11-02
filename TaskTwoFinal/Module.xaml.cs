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
using Calcs;

namespace TaskTwoFinal
{
    /// <summary>
    /// Interaction logic for Module.xaml
    /// </summary>
    public partial class Module : Window
    {
        SqlConnection sqlConnection = new SqlConnection(@"data source=(localdb)\MSSQLLocalDB;initial catalog=TimeManager;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;");
        public string username;
        public int userID;
        public string semname;

        public Module()
        {
            InitializeComponent();            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Get this user's ID
                SqlCommand sqlCommand = new SqlCommand("Select UserID FROM users WHERE Username = @username", sqlConnection);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@username", username);
                sqlConnection.Open();
                var userId = sqlCommand.ExecuteScalar();
                sqlConnection.Close();
                userID = Convert.ToInt32(userId);

                //Get the semester id
                SqlCommand sqlCommand2 = new SqlCommand("Select SemesterID FROM semester WHERE UserID = @userid and SemesterName = @semname", sqlConnection);
                sqlCommand2.CommandType = CommandType.Text;
                sqlCommand2.Parameters.AddWithValue("@userid", userId);
                sqlCommand2.Parameters.AddWithValue("@semname", semname);
                sqlConnection.Open();
                var semID = sqlCommand2.ExecuteScalar();
                sqlConnection.Close();

                //Get weeks this semester
                SqlCommand sqlCommand3 = new SqlCommand("Select SemesterWeeks FROM semester WHERE UserID = @userid and SemesterName = @semname", sqlConnection);
                sqlCommand3.CommandType = CommandType.Text;
                sqlCommand3.Parameters.AddWithValue("@userid", userId);
                sqlCommand3.Parameters.AddWithValue("@semname", semname);
                sqlConnection.Open();
                var weeks = sqlCommand3.ExecuteScalar();
                sqlConnection.Close();

                int calcSelfStudy = Calcs.Calculations.selfStudyHoursCalc(Convert.ToInt32(tbCred.Text), Convert.ToInt32(tbHour.Text), Convert.ToInt32(weeks));

                //create the object to the ado.net model
                TimeManagerEntities tme = new TimeManagerEntities();
                module mod = new module() //object of database
                {
                    ModuleCode = tbCode.Text,
                    ModuleName = tbName.Text,
                    Credits = Convert.ToInt32(tbCred.Text),
                    ClassHours = Convert.ToInt32(tbHour.Text),
                    StudyDate = Convert.ToDateTime(dpStudyDate.Text),
                    SelfStudyHours = calcSelfStudy,
                    UserID = Convert.ToInt32(userId),
                    SemesterID = Convert.ToInt32(semID)
                };
                //pass info into database
                tme.modules.Add(mod);
                int a = tme.SaveChanges(); //save info
                if (a > 0)
                {
                    MessageBox.Show("Module added");
                    bindGrid(); // refresh
                    dg1.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("An error has occured");
                }
                int remHours = Calcs.Calculations.remainingSelfStudyHours(Convert.ToInt32(tbHour.Text), calcSelfStudy);
                lbRemain.Content = "Remaining hours for self studying for this module " + remHours;
                lbDisplay.Content = Calcs.Calculations.displaySelfStudy(Convert.ToDateTime(dpStudyDate.Text), Convert.ToInt32(tbHour.Text), calcSelfStudy, remHours, tbName.Text);
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
            var userResults = from m in tme.modules
                              where m.UserID == userID
                              select new { m.ModuleID, m.ModuleCode, m.ModuleName, m.Credits, m.ClassHours,
                                  m.StudyDate, m.SelfStudyHours, m.UserID, m.SemesterID};
            dg1.ItemsSource = userResults.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow land = new MainWindow();
            land.Show();
        }
    }
}
