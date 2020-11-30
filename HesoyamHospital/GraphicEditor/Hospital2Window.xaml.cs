using System.Windows;
using System.Windows.Controls;

namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for Hospital2Window.xaml
    /// </summary>
    public partial class Hospital2Window : Window
    {
        public Hospital2Window()
        {
            InitializeComponent();
            Hospital2.Content = new Hospital2GroundFloor();
            Hospital2_GroundFloor.IsSelected = true;
        }

        private void Hospital2_SelectionChangedFloor(object sender, SelectionChangedEventArgs e)
        {

            if (Hospital2_GroundFloor.IsSelected)
            {
                Hospital2.Content = new Hospital2GroundFloor();
            }
            else if (Hospital2_FirstFloor.IsSelected)
            {
                Hospital2.Content = new Hospital2FirstFloor();
            }
            else
            {
                Hospital2SecondFloor hospital2Second = new Hospital2SecondFloor();
                Hospital2.Content = hospital2Second;
            }
        }
    }
}
