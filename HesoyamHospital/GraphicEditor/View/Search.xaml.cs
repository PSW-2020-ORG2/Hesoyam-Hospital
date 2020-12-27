using Backend.Model.ManagerModel;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Service.HospitalManagementService;
using GraphicEditor.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        private MedicineService medicineService;
        private List<Medicine> medicines;
        private List<Room> rooms;
        private List<MedicineDTO> medicineDTOs;
        private List<InventoryItem> inventoryItems;
        private List<InventoryItemDTO> inventoryItemsDTOs;
        private List<RoomDTO> roomDTOs;
        private InventoryService inventoryService;
        private RoomService roomService;
        private SearchService searchService;

        public Search()
        {
            InitializeComponent();
            DataContext = this;
            Global.SearchObjectName = "";
            User loggedIn = Backend.AppResources.getInstance().loggedInUser;
            
            if (loggedIn.GetUserType() == UserType.PATIENT)
            {
                searchEquipment.Visibility = Visibility.Hidden;
                searchMedicine.Visibility = Visibility.Hidden;
            }

            inventoryService = Backend.AppResources.getInstance().inventoryService;
            medicineService = Backend.AppResources.getInstance().medicineService;
            roomService = Backend.AppResources.getInstance().roomService;
            searchService = new SearchService();
        }
        public void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (searchType.SelectedIndex == 1)
            {
                if (labelText != null)
                {
                    labelText.Visibility = Visibility.Hidden;
                    objectName.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                if (labelText != null)
                {
                    labelText.Visibility = Visibility.Visible;
                    objectName.Visibility = Visibility.Visible;
                }
            }

        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            String name = objectName.Text;
            if (searchType.SelectedIndex == 0)
            {
                List<MapLocation> results = searchService.FindObjectsByName(name);
                dataGridSearch.ItemsSource = results;
                dataGridSearch.Columns[3].Visibility = Visibility.Hidden;
            }
            else if (searchType.SelectedIndex == 1)
            {
                rooms = roomService.GetRoomsByOccupied(false).ToList();
                roomDTOs = ConvertFromRoomToDTO(rooms);
                dataGridSearch.ItemsSource = roomDTOs;
            }
            else if (searchType.SelectedIndex == 2)
            {
                inventoryItems = (List<InventoryItem>)inventoryService.GetInventoryItemsByName(name);
                inventoryItemsDTOs = InvertoryItemMapper.ConvertFromIventoryItemToDTO(inventoryItems);
                dataGridSearch.ItemsSource = inventoryItemsDTOs;
            }
            else
            {
                medicines = (List<Medicine>)medicineService.GetMedicinesByPartName(name);
                medicineDTOs = ConvertMedicineToDTO(medicines);
                dataGridSearch.ItemsSource = medicineDTOs;
            }
       
        }

        private void Advanced_Search_Click(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (searchType.SelectedIndex == 0)
            {
                MapLocation mapLocation = (MapLocation)dataGridSearch.SelectedItem;
                if (mapLocation == null) return;

                searchService.DisplayResults(mapLocation);
            }
            else if (searchType.SelectedIndex == 2)
            {
                InventoryItemDTO equipment = (InventoryItemDTO)dataGridSearch.SelectedItem;

                if (equipment == null) return;

                string room = equipment.Room;

                MapLocation mapLocation = searchService.GetLocationByRoomName(room);

                searchService.DisplayResults(mapLocation);
            }
            else if (searchType.SelectedIndex == 3)
            {
                MedicineDTO medicineDTO = (MedicineDTO)dataGridSearch.SelectedItem;

                if (medicineDTO == null) return;

                string room = medicineDTO.Room;

                MapLocation mapLocation = searchService.GetLocationByRoomName(room);

                searchService.DisplayResults(mapLocation);
            }
        }

        private List<RoomDTO> ConvertFromRoomToDTO(List<Room> rooms)
        {
            List<RoomDTO> result = new List<RoomDTO>();

            foreach (Room r in rooms)
                result.Add(new RoomDTO(r.RoomNumber, r.RoomType, r.Floor));

            return result;
        }

        private List<MedicineDTO> ConvertMedicineToDTO(List<Medicine> medicines)
        {
            List<MedicineDTO> medicineDTOs = new List<MedicineDTO>();

            foreach (Medicine m in medicines)
                medicineDTOs.Add(new MedicineDTO(m.Name, m.MedicineType.ToString(), 
                                 roomService.GetByID(m.RoomID).RoomNumber, m.InStock));
            
            return medicineDTOs;
        }
    }
}
