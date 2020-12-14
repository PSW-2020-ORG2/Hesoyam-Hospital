using Backend.Model.ManagerModel;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Service.HospitalManagementService;
using GraphicEditor.DTOs;
using System;
using System.Collections.Generic;
using System.Windows;

namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        private MedicineService medicineService;
        private List<Medicine> medicines;
        private List<MedicineDTO> medicineDTOs;
        private List<InventoryItem> inventoryItems;
        private List<EquipmentDTO> inventoryItemsDTOs;
        private InventoryService inventoryService;
        private RoomService roomService;
        private SearchService searchService;

        public Search()
        {
            InitializeComponent();
            DataContext = this;
            Global.SearchObjectName = "";
            if (Global.LoggedInUserType.Equals("patient"))
            {
                searchEquipment.Visibility = Visibility.Hidden;
                searchMedicine.Visibility = Visibility.Hidden;
            }

            inventoryService = Backend.AppResources.getInstance().inventoryService;
            medicineService = Backend.AppResources.getInstance().medicineService;
            roomService = Backend.AppResources.getInstance().roomService;
            searchService = new SearchService();
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            String name = objectName.Text;
            SearchService searchService = new SearchService();
  
            if (searchType.SelectedIndex == 0)
            {
                List<MapLocation> results = searchService.FindObjectsByName(name);
                dataGridSearch.ItemsSource = results;
            }
            else if (searchType.SelectedIndex == 1)
            {
                Console.WriteLine("Uraditi pregled dostupnih soba");
            }
            else if (searchType.SelectedIndex == 2)
            {
                inventoryItemsDTOs = new List<EquipmentDTO>();
                inventoryItems = (List<InventoryItem>)inventoryService.GetInventoryItemsByName(name);
                foreach (InventoryItem item in inventoryItems)
                {
                    EquipmentDTO dto = new EquipmentDTO(item.Name, item.Room.RoomNumber, item.InStock);
                    inventoryItemsDTOs.Add(dto);
                }
                dataGridSearch.ItemsSource = inventoryItemsDTOs;
            }
            else
            {
                medicineDTOs = new List<MedicineDTO>();
                medicines = (List<Medicine>)medicineService.GetMedicinesByPartName(name);
                
                foreach (Medicine m in  medicines)
                {
                    MedicineDTO medicineDTO = new MedicineDTO();

                    medicineDTO.Name = m.Name;

                    switch (m.MedicineType)
                    {
                        case MedicineType.PILL:
                            medicineDTO.Type = "PILL";
                            break;
                        case MedicineType.IV:
                            medicineDTO.Type = "IV";
                            break;
                        case MedicineType.LIQUID:
                            medicineDTO.Type = "LIQUID";
                            break;
                        case MedicineType.TABLET:
                            medicineDTO.Type = "TABLET";
                            break;
                        case MedicineType.TOPICAL_MEDICINE:
                            medicineDTO.Type = "TOPICAL_MEDICINE";
                            break;
                        case MedicineType.DROPS:
                            medicineDTO.Type = "DROPS";
                            break;
                        case MedicineType.SUPPOSITORIES:
                            medicineDTO.Type = "SUPPOSITORIES";
                            break;
                        case MedicineType.INHALERS:
                            medicineDTO.Type = "INHALERS";
                            break;
                        default:
                            medicineDTO.Type = "INJECTIONS";
                            break;
                    }

                    medicineDTO.Quantity = m.InStock;
                    Room foundRoom = roomService.GetByID(m.RoomID);
                    medicineDTO.Room = foundRoom.RoomNumber;
                    
                    medicineDTOs.Add(medicineDTO);
                    
                }

                dataGridSearch.ItemsSource = medicineDTOs;
            }
       
        }

        private void Advanced_Search_Click(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (searchType.SelectedIndex == 0)
            {
                MapLocation mapLocation = (MapLocation)dataGridSearch.SelectedItem;
                if (mapLocation == null)
                {
                    return;
                }
                string name = mapLocation.Name;
                Global.SearchObjectName = name;
                string hospital = mapLocation.Hospital;
                string path = mapLocation.FilePath;
                string floor = mapLocation.Floor;
                string comboBoxPath = "";

                GraphicRepository graphicRepository = new GraphicRepository();
                List<FileInformation> menuInformation = graphicRepository.readFileInformation("Map_Files\\buildings.txt");
                foreach (FileInformation inf in menuInformation)
                {
                    if (inf.Name == hospital)
                        comboBoxPath = inf.FilePath;
                }

                HospitalWindow window = new HospitalWindow(hospital, comboBoxPath);
                window.Hospital.Content = new HospitalFloor(path);
                window.HospitalFloors.Text = floor;
                window.Show();
            }
            else if (searchType.SelectedIndex == 2)
            {
                EquipmentDTO equipment = (EquipmentDTO)dataGridSearch.SelectedItem;
                if (equipment == null) {
                    return;
                }
                string room = equipment.Room;

                MapLocation mapLocation = GetLocationByRoomName(room);

                DisplayResaults(mapLocation);
            }
            else if(searchType.SelectedIndex == 3)
            {
                MedicineDTO medicineDTO = (MedicineDTO)dataGridSearch.SelectedItem;
                if (medicineDTO == null)
                {
                    return;
                }

                string room = medicineDTO.Room;

                MapLocation mapLocation = GetLocationByRoomName(room);

                DisplayResaults(mapLocation);
            }
        }

        private MapLocation GetLocationByRoomName(string room)
        {
            List<MapLocation> mapLocations = searchService.FindObjectsByName(room);
            return mapLocations[0];
        }

        private void DisplayResaults(MapLocation mapLocation)
        {
            Global.SearchObjectName = mapLocation.Name;
            string hospital = mapLocation.Hospital;
            string path = mapLocation.FilePath;
            string floor = mapLocation.Floor;
            string comboBoxPath = "";

            GraphicRepository graphicRepository = new GraphicRepository();
            List<FileInformation> menuInformation = graphicRepository.readFileInformation("Map_Files\\buildings.txt");
            foreach (FileInformation inf in menuInformation)
            {
                if (inf.Name == hospital)
                    comboBoxPath = inf.FilePath;
            }

            HospitalWindow window = new HospitalWindow(hospital, comboBoxPath);
            window.Hospital.Content = new HospitalFloor(path);
            window.HospitalFloors.Text = floor;
            window.Show();
        }
    }
}
