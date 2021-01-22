using System.Windows;
using System.Windows.Controls;

namespace GraphicEditor.View
{
    /// <summary>
    /// Interaction logic for AppointmentAnalysisDataGrid.xaml
    /// </summary>
    public partial class AppointmentAnalysisDataGrid : Window
    {
        public AppointmentAnalysisDataGrid()
        {
            InitializeComponent();
        }

        private void SearchAvailable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageWindow mw = new MessageWindow();
            mw.Title = "Schedule appointment";
            mw.message.Content = "Successfully scheduled appointment!";
            mw.ShowDialog();
        }
    }
}
