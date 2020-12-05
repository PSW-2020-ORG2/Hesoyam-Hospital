using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;

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
           
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            String name = object_name.Text;
            SearchService search_service = new SearchService();
            List<MapLocation> results = search_service.Find_objects_by_name(name);
            _search.ItemsSource = results;

        }

        private void Advanced_Search_Click(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            MapLocation mapLocation = (MapLocation)_search.SelectedItem;
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
            List<FileInformation> menuInformation = graphicRepository.readFileInformation("buildings.txt");
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
