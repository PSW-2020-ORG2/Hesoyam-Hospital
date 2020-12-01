using System;
using System.Collections.Generic;
using System.Windows;
using Backend.Model.DoctorModel;
using Backend.Model.UserModel;

namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        private List<Manager> manager_list = new List<Manager>();
        private List<Patient> patients_list = new List<Patient>();

        public LogIn()
        {
            InitializeComponent();

            Manager manager = new Manager("upravnik", "upravnik", new DateTime(2020, 11, 12), "Pera", "Peric", "P", "12126332555555", Sex.MALE, new DateTime(1994, 11, 12), "aa", new Address("Zmaj Jovina", new Location("Srbija", "Novi Sad")), "010101", "064", "aaa@gmail.com", "bbb@gmail.com", new Hospital());
            manager_list.Add(manager);

            Doctor doctor = new Doctor("doktor", "doktor", new DateTime(2020, 11, 12), "Pera", "Peric", "P", "1412965828733", Sex.MALE, new DateTime(1994, 11, 12), "aa", new Address("Zmaj Jovina", new Location("Srbija", "Novi Sad")), "010101", "064", "aaa@gmail.com", "bbb@gmail.com", new TimeTable(), new Hospital(), new Room(9), new DoctorType());

            Patient patient = new Patient("pacijent", "pacijent", new DateTime(2020, 11, 12), "Pera", "Peric", "P", "01029336457896", Sex.MALE, new DateTime(1994, 11, 12), "aa", new Address("Zmaj Jovina", new Location("Srbija", "Novi Sad")), "010101", "064", "aaa@gmail.com", "bbb@gmail.com", doctor, "a");

            patients_list.Add(patient);

        }

        public void Button_Click_Map(object sender, RoutedEventArgs e)
        {
            bool found = false;

            found = FindManager();
            if (!found)
            {
                found = FindPatient();

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


        public Boolean FindPatient()
        {
            Boolean found = false;
            foreach (Patient _patient in patients_list)
            {
                if (Username.Text.Equals(_patient.UserName) && Password.Password.Equals(_patient.Password))
                {
                        found = true;
                        break;
                }
            }
            return found;
        }

        public Boolean FindManager()
        {
            Boolean found = false;
            foreach (Manager _manager in manager_list)
            {
                if (Username.Text.Equals(_manager.UserName) && Password.Password.Equals(_manager.Password))
                {
                        found = true;
                        break;
                }
            }
            return found;
        }

    }
}
