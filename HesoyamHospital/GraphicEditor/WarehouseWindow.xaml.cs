using System.Collections.Generic;
using System.Windows;
using System.Windows.Shapes;

namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for WarehouseWindow.xaml
    /// </summary>
    public partial class WarehouseWindow : Window
    {
        public WarehouseWindow()
        {
            InitializeComponent();
            DrawingShapesService drawing_shapes = new DrawingShapesService();
            GraphicRepository graphic_repository = new GraphicRepository();
            List<GraphicalObject> list = graphic_repository.ReadFromFile("warehouse.txt");

            foreach (GraphicalObject graphical_object in list)
            {
                Shape shape = drawing_shapes.draw_Shapes(graphical_object);
                canvas1.Children.Add(shape);
            }
        }
    }
}
