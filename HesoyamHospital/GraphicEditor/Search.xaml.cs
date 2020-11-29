using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
           
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            String name = object_name.Text;
            SearchService search_service = new SearchService();
            List<MapLocation> results = search_service.Find_objects_by_name(name);
            _search.ItemsSource = results;

        }
    }
}
