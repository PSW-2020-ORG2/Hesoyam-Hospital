using Backend.Model.PatientModel;
using Backend.Service.HospitalManagementService;
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
        private List<Medicine> medicines = new List<Medicine>();
        private List<MedicineDTO> medicineDTOs = new List<MedicineDTO>();
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

            this.medicineService = Backend.AppResources.getInstance().medicineService;
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
                // avaiable rooms 1
                List<MapLocation> results = searchService.FindObjectsByName(name);
                dataGridSearch.ItemsSource = results;
            }
            else if (searchType.SelectedIndex == 2)
            {
                Console.WriteLine("equipment - 2");
            }
            else
            {
                medicines = (List<Medicine>)medicineService.GetAll();
                
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
                    medicineDTO.Room = m.RoomID;

                    medicineDTOs.Add(medicineDTO);

                }
                dataGridSearch.ItemsSource = medicineDTOs;
            }
       
        }

        private void Advanced_Search_Click(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            MapLocation mapLocation = (MapLocation)dataGridSearch.SelectedItem;
            if (mapLocation == null) {
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
    }
}
