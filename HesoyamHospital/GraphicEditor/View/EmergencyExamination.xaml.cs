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
        private UserService userService = Backend.AppResources.getInstance().userService;

        public EmergencyExamination()
        {
            InitializeComponent();
            inventoryService = Backend.AppResources.getInstance().inventoryService;
            userService = Backend.AppResources.getInstance().userService;
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
            List<User> users = (List<User>)userService.GetAll();

            string name = Name.Text;
            string surname = Surname.Text;
            string jmbg = JMBG.Text;

            /*User user = new User(name, jmbg, name, surname, null, jmbg, Sex.OTHER, new DateTime(2021,01,01), null, null, null, null, null);   
            
            foreach(User user1 in users)
            {
                if(jmbg != user1.Jmbg)
                {
                    userService.Create(user);
                }
                else
                {
                    user = user1;
                }
            }
            */
           
            //User loggedIn = Backend.AppResources.getInstance().loggedInUser;


        }
    }
}
