﻿using System.Windows;
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
            Ellipse ellipse = sender as System.Windows.Shapes.Ellipse;
            MainWindow mainWindow = new MainWindow();

            
            if (rectangle.Name == "hospital1")
            {
                mainWindow.DisplayHospital(sender, e,"hospital1floors.txt", "Hospital 1" );
            }
            else if (rectangle.Name == "hospital2")
            {
                mainWindow.DisplayHospital(sender, e, "hospital2floors.txt", "Hospital 2");
            }
            else if (rectangle.Name == "warehouse")
            {
                mainWindow.DisplayHospital(sender, e, "warehousefloors.txt", "Warehouse");
            }
            else
            {
                return;
            }
        }
        public void MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle rectangle = sender as System.Windows.Shapes.Rectangle;
            MainWindow mainWindow = new MainWindow();

            if (rectangle.Name == "hospital1")
            {
                mainWindow.Display_Information_Window(sender, e);
            }
            else if (rectangle.Name == "hospital2")
            {
                mainWindow.Display_Information_Window(sender, e);
            }
            else if (rectangle.Name == "warehouse")
            {
                mainWindow.Display_Information_Window(sender, e);
            }
            else
            {
                return;
            }
        }

    }
}

