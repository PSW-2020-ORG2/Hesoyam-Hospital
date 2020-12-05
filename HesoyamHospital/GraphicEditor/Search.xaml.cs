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
                searchEquipmentAndMedicine.Visibility = Visibility.Hidden;
            }

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
            string floor = mapLocation.Floor;


            switch (floor)
            {
                case "Ground Floor":
                    if (hospital.Equals("Hospital 1"))
                    {
                        Hospital1Window hospital1_window = new Hospital1Window();
                        hospital1_window.Content = new Hospital1GroundFloor();
                        hospital1_window.Show();
                    }
                    else
                    {
                        Hospital1Window hospital2_window = new Hospital1Window();
                        hospital2_window.Content = new Hospital2GroundFloor();
                        hospital2_window.Show();
                    }
                    break;
                case "First Floor":
                    if (hospital.Equals("Hospital 1"))
                    {
                        Hospital1Window hospital1_window = new Hospital1Window();
                        hospital1_window.Content = new Hospital1FirstFloor();
                        hospital1_window.Show();
                    }
                    else
                    {
                        Hospital2Window hospital2_window = new Hospital2Window();
                        hospital2_window.Content = new Hospital2FirstFloor();
                        hospital2_window.Show();
                    }
                    break;
                case "Second Floor":
                    if (hospital.Equals("Hospital 1"))
                    {
                        break;
                    }
                    else
                    {
                        Hospital2Window hospital2_window = new Hospital2Window();
                        hospital2_window.Content = new Hospital2SecondFloor();
                        hospital2_window.Show();
                    }
                    break;
                default:
                    break;

            }
        }
    }
}
