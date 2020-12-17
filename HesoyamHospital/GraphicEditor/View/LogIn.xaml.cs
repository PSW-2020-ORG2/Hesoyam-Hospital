using System.Collections.Generic;
using System.Windows;
using Backend.Model.UserModel;
using GraphicEditor.Service;

namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        private LogInService logInService = new LogInService();

        public LogIn()
        {
            InitializeComponent();
        }

        public void Button_Click_Map(object sender, RoutedEventArgs e)
        {
            bool found = false;

            List<Manager> managers = logInService.getAllManagers();
            List<Patient> patients = logInService.getAllPatients();
            List<Secretary> secretaries = logInService.getAllSecretaries();

            string username = Username.Text;
            string password = Password.Password;

            found = logInService.FindManager(username, password);

            Global.LoggedInUserType = "manager";

            if (!found)
            {
                found = logInService.FindPatient(username, password);
                Global.LoggedInUserType = "patient";
            }

            if (!found)
            {
                found = logInService.FindSecretary(username, password);
                Global.LoggedInUserType = "secretary";
            }

            if (!found)
            {
                found = logInService.FindDoctor(username, password);
                Global.LoggedInUserType = "doctor";
            }

            if (!found)
            {
                MessageBox.Show("Ne postoji korisnik sa unetim podacima.");
            }
            else
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();

            }

        }

    }
}