using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Backend.Model.ManagerModel;
using Backend.Service.HospitalManagementService;
using GraphicEditor.DTOs;

namespace GraphicEditor.View
{
    /// <summary>
    /// Interaction logic for EquipmentForSpecialistAppointment.xaml
    /// </summary>
    public partial class EquipmentForSpecialistAppointment : Window
    {
        private InventoryService inventoryService;
        private List<InventoryItem> inventoryItems;
        private List<CheckBoxDTO> checkBoxDTOs;

        public EquipmentForSpecialistAppointment()
        {
            InitializeComponent();
            inventoryService = Backend.AppResources.getInstance().inventoryService;
            inventoryItems = (List<InventoryItem>)inventoryService.GetInventoryItems();
            List<CheckBox> checkBoxList = new List<CheckBox>();
            

            CheckBox checkBox = new CheckBox();
            
            
            foreach (InventoryItem inventoryItem in inventoryItems)
            {
                checkBox.Tag = inventoryItem;
                checkBox.Content = inventoryItem.Name;
                checkBox.IsChecked = false;
                checkBoxList.Add(checkBox);
            }
            equipmentDataGrid.ItemsSource = checkBoxList;
        }
        private List<CheckBoxDTO> ConvertFromCheckBoxToDTO(List<CheckBox> checkBoxes)
        {
            List<CheckBoxDTO> result = new List<CheckBoxDTO>();

            foreach (CheckBox check in checkBoxes)
                result.Add(new CheckBoxDTO(check.Name));

            return result;
        }
    }
}
