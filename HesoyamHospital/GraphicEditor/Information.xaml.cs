using System.Windows;
using System.Windows.Controls;

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
