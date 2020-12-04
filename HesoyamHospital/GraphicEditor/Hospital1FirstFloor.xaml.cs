using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for Hospital1FirstFloor.xaml
    /// </summary>
    public partial class Hospital1FirstFloor : Page
    {
        public Hospital1FirstFloor()
        {
            InitializeComponent();
            DrawingShapesService drawingShapes = new DrawingShapesService();
            GraphicRepository graphicRepository = new GraphicRepository();
            List<GraphicalObject> list = graphicRepository.ReadFromFile("hospital1firstfloor.txt");

            foreach (GraphicalObject graphicalObject in list)
            {
                Shape shape = drawingShapes.DrawShapes(graphicalObject);
                canvas1.Children.Add(shape);
            }
        }
    }
}
