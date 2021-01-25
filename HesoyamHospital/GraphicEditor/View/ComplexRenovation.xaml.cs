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
    /// Interaction logic for ComplexRenovation.xaml
    /// </summary>
    public partial class ComplexRenovation : Window
    {
        public ComplexRenovation()
        {
            InitializeComponent();
        }

        private void ToDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                toDatePicker.IsDropDownOpen = true;
            }
        }

        private void buttonComplexRenovation_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
