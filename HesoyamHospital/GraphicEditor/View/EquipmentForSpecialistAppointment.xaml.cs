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
        private List<InventoryNameDTO> inventoryNamesDTOs;

        //private List<CheckBoxDTO> checkBoxDTOs;

        public EquipmentForSpecialistAppointment()
        {
            InitializeComponent();  
            inventoryService = Backend.AppResources.getInstance().inventoryService;  
            inventoryItems = (List<InventoryItem>)inventoryService.GetInventoryItems();
            inventoryNamesDTOs = InvertoryItemMapper.ConvertFromIventoryItemNameToDTO(inventoryItems);
            equipmentDataGrid.ItemsSource = inventoryNamesDTOs;
        }
    }
}
