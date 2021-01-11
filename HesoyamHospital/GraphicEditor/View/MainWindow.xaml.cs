using Backend.Model.UserModel;
using GraphicEditor.View;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Global.SearchObjectName = "";
            InitializeComponent();

            User loggedIn = Backend.AppResources.getInstance().loggedInUser;


            if (loggedIn.GetUserType() != UserType.SECRETARY)
            {
                searchAvailable.Visibility = Visibility.Hidden;
                searchEmergency.Visibility = Visibility.Hidden;
            }
            else
            {
                searchEquipment.Visibility = Visibility.Hidden;
            }
           

            DrawingShapesService drawingShapes = new DrawingShapesService();
            GraphicRepository graphicRepository = new GraphicRepository();
            List<FileInformation> menuInformation = graphicRepository.readFileInformation("Map_Files\\buildings.txt");

       
            foreach (FileInformation inf in menuInformation) 
            {
                MenuItem item = new MenuItem();
                item.Header = inf.Name;
                Image icon = new Image();
                string relativePath = "/XAMLResources/icons/logohospital.png";
                Uri resourceUri = new Uri(relativePath, UriKind.Relative);
                icon.Source = new BitmapImage(resourceUri);
                icon.Width = 25;
                icon.Height = 25;
                item.Icon = icon;
                item.Click += (sender2, e2) => DisplayHospital(sender2, e2, inf.FilePath, inf.Name);
                ChooseAHospital.Items.Add(item);
            }

            List<GraphicalObject> list = graphicRepository.ReadFromFile("Map_Files\\hospitalmap.txt");

            foreach (GraphicalObject graphicalObject in list)
            {
                Shape shape = drawingShapes.DrawShapes(graphicalObject);
                canvas1.Children.Add(shape);
            }

        }

        public void DisplayHospital(object sender, RoutedEventArgs e, string path, string name)
        {
            HospitalWindow hospital1 = new HospitalWindow(name, path);
            hospital1.Show();
        }
       

        public void Display_Search_Window(object sender, RoutedEventArgs e)
        {
            Search search = new Search();
            search.Show();
        }

        public void Search_Available_Terms(object sender, RoutedEventArgs e)
        {
            SearchAvailableAppointmentWindow searchAvailableAppointment = new SearchAvailableAppointmentWindow();
            searchAvailableAppointment.Show();
        }

        public void Search_Emergency_Terms(object sender, RoutedEventArgs e)
        {
            EmergencyExamination emergencyExamination = new EmergencyExamination();
            emergencyExamination.Show();
        }
        public void Search_Equipment_Relocation(object sender, RoutedEventArgs e)
        {
            EquipmentRelocation equipmentRelocation = new EquipmentRelocation();
            equipmentRelocation.Show();
        }
    }
}
