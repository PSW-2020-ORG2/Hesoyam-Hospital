using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for Hospital1Window.xaml
    /// </summary>
    public partial class HospitalWindow : Window
    {
        public HospitalWindow(string name, string path)
        {
            InitializeComponent();
            caption.Content = name;
           
            GraphicRepository graphicRepository = new GraphicRepository();
            List<FileInformation> comboBoxItems = graphicRepository.readFileInformation(path);
            foreach (FileInformation inf in comboBoxItems) 
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Tag = inf.FilePath;
                item.Content = inf.Name;
                HospitalFloors.Items.Add(item);
            }
            HospitalFloors.SelectedIndex = 0;
            ComboBoxItem selectedItem = (ComboBoxItem)HospitalFloors.SelectedItem;
            string file = selectedItem.Tag.ToString();
            Hospital.Content = new HospitalFloor(file);
        }

        private void HospitalSelectionChangedFloor(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)HospitalFloors.SelectedItem;
            string file = selectedItem.Tag.ToString();
            Hospital.Content = new HospitalFloor(file);
        }
    }
}
