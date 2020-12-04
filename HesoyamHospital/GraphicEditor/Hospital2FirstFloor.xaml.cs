using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for Hospital2FirstFloor.xaml
    /// </summary>
    public partial class Hospital2FirstFloor : Page
    {
        public Hospital2FirstFloor()
        {
            InitializeComponent();
            DrawingShapesService drawingShapes = new DrawingShapesService();
            GraphicRepository graphicRepository = new GraphicRepository();
            List<GraphicalObject> list = graphicRepository.ReadFromFile("hospital2firstfloor.txt");

            foreach (GraphicalObject graphicalObject in list)
            {
                Shape shape = drawingShapes.DrawShapes(graphicalObject);
                canvas1.Children.Add(shape);
            }
        }
    }
}
