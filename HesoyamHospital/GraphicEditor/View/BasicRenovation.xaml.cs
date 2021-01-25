using Backend.Model.UserModel;
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

namespace GraphicEditor.View
{
    /// <summary>
    /// Interaction logic for BasicRenovation.xaml
    /// </summary>
    public partial class BasicRenovation : Window
    {
        private Room room;
        public BasicRenovation(Room r)
        {
            InitializeComponent();
            room = r;
        }

        private void startDatePicker_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                startDatePicker.IsDropDownOpen = true;
            }
        }

        private void endDatePicker_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                endDatePicker.IsDropDownOpen = true;
            }
        }
        private void ButtonScheduleBasicRenovation_Click(object sender, RoutedEventArgs e)
        {
            MessageWindow ms = new MessageWindow();
            ms.Title = " Soba id " + room.Id;
            ms.ShowDialog();
        }

        private void SearchAlternativeTerms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
