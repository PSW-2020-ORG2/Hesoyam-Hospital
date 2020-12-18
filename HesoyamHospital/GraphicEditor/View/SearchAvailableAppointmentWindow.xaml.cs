using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Backend.Model.UserModel;
using Backend.Repository.MySQLRepository.UsersRepository;

namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for SearchAvailableAppointmentWindow.xaml
    /// </summary>
    public partial class SearchAvailableAppointmentWindow : Window
    {
        private List<Doctor> doctors = new List<Doctor>();
        private DoctorRepository doctorRepository;

        public SearchAvailableAppointmentWindow()
        {
            InitializeComponent();
            this.doctorRepository = Backend.AppResources.getInstance().doctorRepository;

            doctors = getAllDoctors();

            foreach (Doctor doctor in doctors)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Tag = doctor;
                item.Content = doctor.FullName;
                searchDoctor.Items.Add(item);
            }

        }

        public List<Doctor> getAllDoctors()
        {
            if (doctorRepository.GetAll() == null)
            {
                return null;
            }
            doctors = doctorRepository.GetAll().ToList();
            return doctors;
        }

        private void FromtDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                fromDatePicker.IsDropDownOpen = true;
                fromDatePicker.DisplayDateStart = DateTime.Today;
            }
        }

        private void ToDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                toDatePicker.IsDropDownOpen = true;
            }
        }
    }
}
