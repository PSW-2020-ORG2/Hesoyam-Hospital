using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for Hospital1GroundFloor.xaml
    /// </summary>
    public partial class HospitalFloor : Page
    {
        public HospitalFloor(string path)
        {
            InitializeComponent();
            DrawingShapesService drawingShapes = new DrawingShapesService();
            GraphicRepository graphicRepository = new GraphicRepository();
            List<GraphicalObject> list = graphicRepository.ReadFromFile(path);

            foreach (GraphicalObject graphicalObject in list)
            {
                Shape shape = drawingShapes.DrawShapes(graphicalObject);
                canvas1.Children.Add(shape);
            }
        }
    }
}
