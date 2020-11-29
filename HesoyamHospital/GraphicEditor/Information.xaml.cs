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
    /// Interaction logic for Information.xaml
    /// </summary>
    public partial class Information : Window
    {
        public Information()
        {
            InitializeComponent();
        }
        public void Display_Additional_Info_Window(object sender, RoutedEventArgs e)
        {
            InformationPage informationPage = new InformationPage();
            _window.Children.Clear();
            Frame.Navigate(informationPage);
            Frame.Refresh();
        }
    }
}
