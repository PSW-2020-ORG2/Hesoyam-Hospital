using Backend.Model.UserModel;
using Backend.Service.HospitalManagementService;
using System.Windows;

namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for Information.xaml
    /// </summary>
    public partial class Information : Window
    {
        private readonly RoomService roomService = Backend.AppResources.getInstance().roomService;
        public Information()
        {
            InitializeComponent();
            Global.SearchObjectName = "";
            if (Global.LoggedInUserType == "patient")
            {
                change.Visibility = Visibility.Hidden;
            }

        }
        private void ChangeInformationClick(object sender, RoutedEventArgs e)
        {
            name.IsEnabled = false;
            occupied.IsEnabled = true;
            roomType.IsEnabled = true;
            change.Visibility = Visibility.Hidden;
            save.Visibility = Visibility.Visible;
        }

        private void saveChangedInformation(object sender, RoutedEventArgs e)
        {
            
            string roomName = name.Text;
            bool roomOccupied = (bool)occupied.IsChecked;
            string t = roomType.Text;
            RoomType.TryParse(t, out RoomType type);
            Room room = roomService.GetRoomByName(roomName);
            room.Occupied = roomOccupied;
            room.RoomType = type;
            roomService.Update(room);

            Close();
        }

    }
}
