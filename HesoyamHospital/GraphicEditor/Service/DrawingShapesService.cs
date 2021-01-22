
using Backend.Model.UserModel;
using Backend.Service.HospitalManagementService;
using Backend.Model.ManagerModel;
using Backend.Model.PatientModel;
using GraphicEditor.DTOs;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using GraphicEditor.View;
using Backend.Service.MedicalService;

namespace GraphicEditor
{
    class DrawingShapesService
    {
        private readonly GraphicRepository graphicRepository;
        private readonly MedicineService medicineService  = Backend.AppResources.getInstance().medicineService;
        private readonly InventoryService inventoryService = Backend.AppResources.getInstance().inventoryService;
        private readonly RoomService roomService = Backend.AppResources.getInstance().roomService;
        private readonly AppointmentService appointmentService = Backend.AppResources.getInstance().appointmentService;
        private readonly User loggedIn = Backend.AppResources.getInstance().loggedInUser;
       
        public DrawingShapesService()
        {
            graphicRepository = new GraphicRepository();
        }

        public (SolidColorBrush, SolidColorBrush) PickColor(string type)
        {
            switch (type)
            {
                case "hospital":
                    return (Brushes.Purple, Brushes.Transparent);
                case "warehouse":
                    return (Brushes.Purple, Brushes.Transparent);
                case "floor":
                    return (Brushes.LightGray, Brushes.Transparent);
                case "shop":
                    return (Brushes.Orange, Brushes.Transparent);
                case "bakery":
                    return (Brushes.Orange, Brushes.Transparent);
                case "cafe":
                    return (Brushes.Orange, Brushes.Transparent);
                case "room":
                    return (Brushes.PeachPuff, Brushes.Black);
                case "elevator":
                    return (Brushes.DarkGreen, Brushes.Black);
                case "stairs":
                    return (Brushes.DarkGreen, Brushes.Black);
                case "door":
                    return (Brushes.DarkRed, Brushes.Transparent);
                case "sidewalk":
                    return (Brushes.GhostWhite, Brushes.Transparent);
                case "grass":
                    return (Brushes.Green, Brushes.Transparent);
                case "road":
                    return (Brushes.Gray, Brushes.Transparent);
                case "parking":
                    return (Brushes.Gray, Brushes.Yellow);
                default:
                    return (Brushes.Black, Brushes.Transparent);
            }
        }

        public Shape DrawShapes(GraphicalObject graphicalObject)
        {
            string shape = graphicalObject.Shape;
            SolidColorBrush brush;
            SolidColorBrush stroke;
            (brush, stroke) = PickColor(graphicalObject.Type);

            switch (shape)
            {
                case "rectangle":
                    Rectangle rectangle = new Rectangle();
                    rectangle.Width = graphicalObject.Width;
                    rectangle.Height = graphicalObject.Height;

                    rectangle.Name = graphicalObject.Name;
                    rectangle.Fill = brush;
                    rectangle.ToolTip = rectangle.Name;

                    if (rectangle.Name == Global.SearchObjectName)
                    {
                        rectangle.StrokeThickness = 7;
                        rectangle.Stroke = Brushes.Red;
                    }
                    else
                    { 
                        rectangle.Stroke = stroke;
                    }

                    rectangle.Stroke = stroke;
                    rectangle.MouseLeftButtonDown += MouseLeftButtonDown;
                    rectangle.MouseRightButtonDown += MouseRightButtonDown;
                    rectangle.MouseLeftButtonDown += (sender2, e2) => DoubleClick(sender2, e2, rectangle.Name);
                    rectangle.VerticalAlignment = VerticalAlignment.Top;
                    Canvas.SetLeft(rectangle, graphicalObject.Left);
                    Canvas.SetTop(rectangle, graphicalObject.Top);
                    return rectangle;

                case "elipse":
                    Ellipse ellipse = new Ellipse();
                    ellipse.Width = graphicalObject.Width;
                    ellipse.Height = graphicalObject.Height;
                    ellipse.Fill = brush;

                    ellipse.Stroke = stroke;
                    ellipse.VerticalAlignment = VerticalAlignment.Top;
                    Canvas.SetLeft(ellipse, graphicalObject.Left);
                    Canvas.SetTop(ellipse, graphicalObject.Top);
                    return ellipse;
                default:
                    return new Rectangle();

            }
        }

        public void DoubleClick(object sender, MouseButtonEventArgs e, string roomName)
        {
            if (loggedIn.GetUserType() != UserType.PATIENT)
            {
                Rectangle rectangle = sender as System.Windows.Shapes.Rectangle;
                List<InventoryItemDTO> inventories = new List<InventoryItemDTO>();

                if (e.ClickCount == 2 && (rectangle.Name.Contains("room") || rectangle.Name.Contains("Storage")))
                {

                    long idRoom = FindIdForRoomName(roomName);

                    List<Medicine> medicine = (List<Medicine>)medicineService.GetMedicinesByRoomId(idRoom);
                    List<InventoryItemDTO> medicineDTO = InvertoryItemMapper.ConvertFromMedicineToDTO(medicine, roomName);
                    inventories.AddRange(medicineDTO);

                    List<InventoryItem> inventoryItems = (List<InventoryItem>)inventoryService.GetInventoryItemsByRoomId(idRoom);
                    List<InventoryItemDTO> inventoryItemDTO = InvertoryItemMapper.ConvertFromIventoryItemToDTO(inventoryItems);
                    inventories.AddRange(inventoryItemDTO);

                    DisplayInventories(inventories);

                }
            }
        }

        public void MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle rectangle = sender as System.Windows.Shapes.Rectangle;
            MainWindow mainWindow = new MainWindow();
            List<FileInformation> menuInformation = graphicRepository.readFileInformation("Map_Files\\buildings.txt");
            if (rectangle.Name.Contains("room")) {

                Room roomS = roomService.GetRoomByName(rectangle.Name);
                ChooseActionWindow chooseActionWindow = new ChooseActionWindow(roomS);
                chooseActionWindow.Show();
        
            }

            foreach (FileInformation inf in menuInformation)
                if (inf.Name == rectangle.Name) mainWindow.DisplayHospital(sender, e, inf.FilePath, inf.Name);
        }
        public void MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle rectangle = sender as System.Windows.Shapes.Rectangle;

            if (rectangle.Name.Contains("room"))
            {
                Information information = new Information();
                Room room = roomService.GetRoomByName(rectangle.Name);

                information.name.Text = room.RoomNumber;
                information.occupied.IsChecked = room.Occupied;
                information.roomType.Text = room.RoomType.ToString();

                information.name.IsEnabled = false;
                information.occupied.IsEnabled = false;
                information.roomType.IsEnabled = false;

                information.Show();
            }
        }

        private long FindIdForRoomName(string roomName)
        {
            Room room = roomService.GetRoomByName(roomName);
            return room.Id;
        }

        private static void DisplayInventories(List<InventoryItemDTO> result)
        {
            OverviewEquipmentAndMedicine window = new OverviewEquipmentAndMedicine();
            window.dataGridOverview.ItemsSource = result;
            window.ShowDialog();
        }

    }
}

