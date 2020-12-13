using Castle.Core.Internal;
using System;
using System.Collections.Generic;
using System.Windows;

namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        public Search()
        {
            InitializeComponent();
            DataContext = this;
            Global.SearchObjectName = "";
            if (Global.LoggedInUserType.Equals("patient"))
            {
                searchEquipment.Visibility = Visibility.Hidden;
                searchMedicine.Visibility = Visibility.Hidden;
            }

        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            String name = objectName.Text;
            SearchService searchService = new SearchService();

            if (searchType.SelectedIndex == 0)
            {
                List<MapLocation> results = searchService.FindObjectsByName(name);
                dataGridSearch.ItemsSource = results;
            }
            else if (searchType.SelectedIndex == 1)
            {

            }
            else if (searchType.SelectedIndex == 2)
            {
                // equipment
            }
            else
            {
                // medicine
            }
        }

        private void Advanced_Search_Click(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            MapLocation mapLocation = (MapLocation)dataGridSearch.SelectedItem;
            if (mapLocation == null) {
                return;
            }
            string name = mapLocation.Name;
            Global.SearchObjectName = name;
            string hospital = mapLocation.Hospital;
            string path = mapLocation.FilePath;
            string floor = mapLocation.Floor;
            string comboBoxPath = "";

            GraphicRepository graphicRepository = new GraphicRepository();
            List<FileInformation> menuInformation = graphicRepository.readFileInformation("Map_Files\\buildings.txt");
            foreach (FileInformation inf in menuInformation) 
            {
                if (inf.Name == hospital)
                    comboBoxPath = inf.FilePath;
            }

            HospitalWindow window = new HospitalWindow(hospital, comboBoxPath);
            window.Hospital.Content = new HospitalFloor(path);
            window.HospitalFloors.Text = floor;
            window.Show();
        }
    }
}
