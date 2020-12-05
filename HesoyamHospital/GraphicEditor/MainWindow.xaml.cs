using System.Collections.Generic;
using System.Windows;
using System.Windows.Shapes;

namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Global.SearchObjectName = "";
            InitializeComponent();
            
            Global.AdditionalInformation = new InformationObject("14:00h-16:00h", "08:00h-17:00h", "Marija Prokic");

            DrawingShapesService drawingShapes = new DrawingShapesService();
            GraphicRepository graphicRepository = new GraphicRepository();
            List<GraphicalObject> list = graphicRepository.ReadFromFile("hospitalmap.txt");

            foreach (GraphicalObject graphicalObject in list)
            {
                Shape shape = drawingShapes.DrawShapes(graphicalObject);
                canvas1.Children.Add(shape);
            }
        }

        public void Display_Hospital1(object sender, RoutedEventArgs e)
        {
            Hospital1Window hospital1 = new Hospital1Window();
            hospital1.Show();
        }

        public void Display_Hospital2(object sender, RoutedEventArgs e)
        {
             Hospital2Window hospital2 = new Hospital2Window();
             hospital2.Show();
        }

        public void Display_Warehouse(object sender, RoutedEventArgs e)
        {
             WarehouseWindow warehouse = new WarehouseWindow();
             warehouse.Show();
        }

        public void Display_Search_Window(object sender, RoutedEventArgs e)
        {
            Search search = new Search();
            search.Show();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
