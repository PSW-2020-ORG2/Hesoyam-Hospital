using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GraphicEditor
{
    class DrawingShapesService
    {

        public DrawingShapesService()
        {
        }

        public (SolidColorBrush, SolidColorBrush) PickColor(string type)
        {
            switch (type)
            {
                case "hospital":
                    return (Brushes.Purple, Brushes.Transparent);
                case "warehouse":
                    return (Brushes.Purple, Brushes.Transparent);
                case "floor":
                    return (Brushes.LightGray, Brushes.Transparent);
                case "shop":
                    return (Brushes.Orange, Brushes.Transparent);
                case "bakery":
                    return (Brushes.Orange, Brushes.Transparent);
                case "cafe":
                    return (Brushes.Orange, Brushes.Transparent);
                case "room":
                    return (Brushes.PeachPuff, Brushes.Black);
                case "elevator":
                    return (Brushes.DarkGreen, Brushes.Black);
                case "stairs":
                    return (Brushes.DarkGreen, Brushes.Black);
                case "door":
                    return (Brushes.DarkRed, Brushes.Transparent);
                case "sidewalk":
                    return (Brushes.GhostWhite, Brushes.Transparent);
                case "grass":
                    return (Brushes.Green, Brushes.Transparent);
                case "road":
                    return (Brushes.Gray, Brushes.Transparent);
                case "parking":
                    return (Brushes.Gray, Brushes.Yellow);
                default:
                    return (Brushes.Black, Brushes.Transparent);
            }
        }

        public Shape DrawShapes(GraphicalObject graphicalObject)
        { 
            string shape = graphicalObject.Shape;
            SolidColorBrush brush;
            SolidColorBrush stroke;
            (brush, stroke) = PickColor(graphicalObject.Type);

            switch (shape)
            {
                case "rectangle":
                    Rectangle rectangle = new Rectangle();
                    rectangle.Width = graphicalObject.Width;
                    rectangle.Height = graphicalObject.Height;
                    
                    rectangle.Name = graphicalObject.Name;
                    rectangle.Fill = brush;
                    rectangle.ToolTip = rectangle.Name;

                    if (rectangle.Name == Global.SearchObjectName)
                    { 
                        rectangle.StrokeThickness = 7;
                        rectangle.Stroke = Brushes.Red;
                    }
                    else {
                       
                        rectangle.Stroke = stroke;
                    }

                    rectangle.Stroke = stroke;
                    rectangle.MouseLeftButtonDown += MouseLeftButtonDown;
                    rectangle.MouseRightButtonDown += MouseRightButtonDown;
                    rectangle.VerticalAlignment = VerticalAlignment.Top;
                    Canvas.SetLeft(rectangle, graphicalObject.Left);
                    Canvas.SetTop(rectangle, graphicalObject.Top);
                    return rectangle;

                case "elipse":
                    Ellipse ellipse = new Ellipse();
                    ellipse.Width = graphicalObject.Width;
                    ellipse.Height = graphicalObject.Height;
                    ellipse.Fill = brush;

                    ellipse.Stroke = stroke;
                    ellipse.VerticalAlignment = VerticalAlignment.Top;
                    Canvas.SetLeft(ellipse, graphicalObject.Left);
                    Canvas.SetTop(ellipse, graphicalObject.Top);
                    return ellipse;
                default:
                    return new Rectangle();

            }
        }
        public void MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle rectangle = sender as System.Windows.Shapes.Rectangle;
            MainWindow mainWindow = new MainWindow();

            GraphicRepository graphicRepository = new GraphicRepository();
            List<FileInformation> menuInformation = graphicRepository.readFileInformation("Map_Files\\buildings.txt");

            foreach (FileInformation inf in menuInformation)
            {
                if(inf.Name == rectangle.Name)
                    mainWindow.DisplayHospital(sender, e, inf.FilePath, inf.Name);
            }
              
        }
        public void MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle rectangle = sender as System.Windows.Shapes.Rectangle;

            if (rectangle.Name.Contains("room"))
            { 
                Information information = new Information();
                information.name.Text = rectangle.Name;
                information.visiting.Text = Global.AdditionalInformation.VisitingHours;
                information.working.Text = Global.AdditionalInformation.WorkingHours;
                information.doctor.Text = Global.AdditionalInformation.Doctor;
                information.name.IsEnabled = false;
                information.visiting.IsEnabled = false;
                information.doctor.IsEnabled = false;
                information.working.IsEnabled = false;
                information.Show();

            }
        }

    }
}

