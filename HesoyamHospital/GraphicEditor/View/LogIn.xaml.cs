using System.Windows;
using Backend.Model.UserModel;
using Backend.Service.UsersService;

namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        private UserService userService = Backend.AppResources.getInstance().userService;

        public LogIn()
        {
            InitializeComponent();
        }

        public void Button_Click_Map(object sender, RoutedEventArgs e)
        {
            string username = Username.Text;
            string password = Password.Password;

            userService.Login(username, password);
            User loggedIn = Backend.AppResources.getInstance().loggedInUser;
            
            if(loggedIn == null)
            {
                MessageBox.Show("Incorrect username or password!");
            }
            else
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();

            }

        }

    }
}