﻿using System;
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
using Backend.Model.UserModel;

namespace GraphicEditor.View
{
    /// <summary>
    /// Interaction logic for ChooseActionWindow.xaml
    /// </summary>
    public partial class ChooseActionWindow : Window
    {
        private Room room;
        public ChooseActionWindow(Room room1)
        {
            room = room1;
            InitializeComponent();
        }

        private void OverviewEquipment_Click(object sender, RoutedEventArgs e)
        {
            OverviewEquipmentAndMedicine overviewEquipmentandMedicine = new OverviewEquipmentAndMedicine();
            overviewEquipmentandMedicine.Show();
        }

        private void showRoomSchedule_Click(object sender, RoutedEventArgs e)
        {
            ShowSchedule showSchedule = new ShowSchedule(room);
            showSchedule.Show();
        }

        private void ScheduleComplexRenovation_Click(object sender, RoutedEventArgs e)
        {
            ComplexRenovation complexRenovation = new ComplexRenovation();
            complexRenovation.Show();
        }

        private void ScheduleBasicRenovation_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
