using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for Hospital2GroundFloor.xaml
    /// </summary>
    public partial class Hospital2GroundFloor : Page
    { 
        public Hospital2GroundFloor()
        {
            InitializeComponent();
            DrawingShapesService drawing_shapes = new DrawingShapesService();
            GraphicRepository graphic_repository = new GraphicRepository();
            List<GraphicalObject> list = graphic_repository.ReadFromFile("hospital2groundfloor.txt");

            foreach (GraphicalObject graphical_object in list)
            {
                Shape shape = drawing_shapes.draw_Shapes(graphical_object);
                canvas1.Children.Add(shape);
            }
        }
    }
}