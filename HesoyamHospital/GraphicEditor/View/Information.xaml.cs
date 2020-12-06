using System.Windows;

namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for Information.xaml
    /// </summary>
    public partial class Information : Window
    {
        public Information()
        {
            InitializeComponent();
            Global.SearchObjectName = "";
            if (Global.LoggedInUserType == "patient")
            {
                change.Visibility = Visibility.Hidden;
            }

        }
        private void ChangeInformationClick(object sender, RoutedEventArgs e)
        {
            visiting.IsEnabled = true;
            working.IsEnabled = true;
            doctor.IsEnabled = true;
            change.Visibility = Visibility.Hidden;
            save.Visibility = Visibility.Visible;
        }

        private void saveChangedInformation(object sender, RoutedEventArgs e)
        {
            InformationObject informationObject = new InformationObject();
            informationObject.VisitingHours = visiting.Text;
            informationObject.WorkingHours = working.Text;
            informationObject.Doctor = doctor.Text;
            Global.AdditionalInformation = informationObject;
            Close();
        }

    }
}
