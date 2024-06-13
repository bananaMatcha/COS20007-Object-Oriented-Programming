using System;
using System.Net.Http.Headers;
using SplashKitSDK;
using System.IO;
namespace ShapeDrawer
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle, 
            Circle,
            Line
        }
        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 600);

            Drawing myDrawing = new Drawing();

            ShapeKind kindToAdd = ShapeKind.Circle; // shapekind variable

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                else if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }
                else if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }



                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    /* 3.3
                    Shape s = new MyCircle(Color.Yellow, SplashKit.MouseX(), SplashKit.MouseY(), 40);
                    myDrawing.AddShape(s);
                    */                   
                    Shape newShape;

                    switch (kindToAdd)
                    {
                        case ShapeKind.Circle:
                            newShape = new MyCircle();                           
                            break;
                        case ShapeKind.Line:
                            newShape = new MyLine();
                            break;                 
                        default:
                            newShape = new MyRectangle();                                                   
                            break;
                    }
                    newShape.X = SplashKit.MouseX();
                    newShape.Y = SplashKit.MouseY();
                    myDrawing.AddShape(newShape);
                }
                

                                            
                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    Point2D mousePosition = SplashKit.MousePosition();
                    myDrawing.SelectShapesAt(mousePosition);
                } 
                if (SplashKit.KeyTyped(KeyCode.SpaceKey)) //change the background color when user press SPACE
                {
                    myDrawing.Background = SplashKit.RandomColor();
                }

                if ((SplashKit.KeyTyped(KeyCode.DeleteKey)) || (SplashKit.KeyTyped(KeyCode.BackspaceKey)) ) 
                {
                    // Get the list of selected shapes
                    List<Shape> selectedShapes = myDrawing.SelectedShapes;

                    // Remove each selected shape from the drawing
                    foreach (Shape s in selectedShapes)
                    {
                        myDrawing.RemoveShape(s);
                    }
                }
                    
                myDrawing.Draw();
                                                        
                SplashKit.RefreshScreen();

                if (SplashKit.KeyTyped(KeyCode.SKey))
                {

                   // myDrawing.Save("TestDrawing.txt");

                    string desktopPath = "D:\\2nd year\\Sem 1\\COS20007 - Object Oriented Programming";
                    string filePath = Path.Combine(desktopPath, "TestDrawing.txt");
         
                    myDrawing.Save(filePath);

                }
                if (SplashKit.KeyTyped(KeyCode.OKey))
                {
                    string desktopPath = "D:\\2nd year\\Sem 1\\COS20007 - Object Oriented Programming";
                    string filePath = Path.Combine(desktopPath, "TestDrawing.txt");
                    
                    //exception: show error when the program is asked
                    //  to open an unexist file -> continue to run instead of stopping the program
                    try
                    {
                        myDrawing.Load(filePath);
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine("Error loading file: {0}", e.Message);
                    }
                }

            } while (!window.CloseRequested) ;

        }
        
    }
}
