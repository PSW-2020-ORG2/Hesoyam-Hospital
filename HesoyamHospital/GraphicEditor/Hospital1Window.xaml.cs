using System.Windows;
using System.Windows.Controls;

namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for Hospital1Window.xaml
    /// </summary>
    public partial class Hospital1Window : Window
    {
        public Hospital1Window()
        {
            InitializeComponent();
            Hospital1.Content = new Hospital1GroundFloor();
            Hospital1_GroundFloor.IsSelected = true;
        }

        private void Hospital1_SelectionChangedFloor(object sender, SelectionChangedEventArgs e)
        {

            if (Hospital1_GroundFloor.IsSelected)
            {
                Hospital1.Content = new Hospital1GroundFloor();
            }
            else
            {
                Hospital1.Content = new Hospital1FirstFloor();
            }

        }
    }
}
