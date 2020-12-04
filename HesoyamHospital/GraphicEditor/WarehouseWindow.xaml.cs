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
            DrawingShapesService drawingShapes = new DrawingShapesService();
            GraphicRepository graphicRepository = new GraphicRepository();
            List<GraphicalObject> list = graphicRepository.ReadFromFile("warehouse.txt");

            foreach (GraphicalObject graphicalObject in list)
            {
                Shape shape = drawingShapes.DrawShapes(graphicalObject);
                canvas1.Children.Add(shape);
            }
        }
    }
}
