using Backend.Model.ManagerModel;
using Backend.Model.UserModel;
using Backend.Service.HospitalManagementService;
using Backend.Service.UsersService;
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
    /// Interaction logic for EmergencyExamination.xaml
    /// </summary>
    public partial class EmergencyExamination : Window
    {
        private readonly InventoryService inventoryService;

        public EmergencyExamination()
        {
            InitializeComponent();
            inventoryService = Backend.AppResources.getInstance().inventoryService;
            List<InventoryItem> inventories = (List<InventoryItem>)inventoryService.GetInventoryItems();
           
            foreach (InventoryItem inventoryItem in inventories)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Tag = inventoryItem;
                item.Content = inventoryItem.Name;
                chooseEquipment.Items.Add(item);
            }
        }

        private void buttonScheduleEmergencyAppointment_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
