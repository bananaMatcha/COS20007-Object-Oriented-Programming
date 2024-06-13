using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
using System.IO;

namespace ShapeDrawer
{
    public class Drawing
    {
        private readonly List<Shape> _shapes;
        private SplashKitSDK.Color _background;


        public Drawing(SplashKitSDK.Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }
        public Drawing() : this(SplashKitSDK.Color.Yellow)
        {
            _shapes = new List<Shape>();
            _background = SplashKitSDK.Color.Yellow;
        }
        public int ShapeCount
        {
            get
            {
                return _shapes.Count;
            }
        }
        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> result = new List<Shape>(); //not understand yet
                foreach (Shape s in _shapes)
                {
                    if (s.Selected)
                    {
                        result.Add(s);
                    }
                }
                return result;
            }
        }
        public SplashKitSDK.Color Background
        {
            get
            {
                return _background;
            }

            set
            {
                _background = value;
            }
        }           
        public void AddShape(Shape s)
        {
            _shapes.Add(s);
        }
        public void RemoveShape(Shape s)
        {
            _ = _shapes.Remove(s); //discard assignment

        }

        public void Draw()
        {
            SplashKit.ClearScreen(_background);
            foreach (Shape s in _shapes)
            {
                s.Draw();
            }
        }
        public void SelectShapesAt(Point2D pt)
        {
            foreach (Shape s in _shapes)
            {
                //  s.Selected = s.IsAt(pt);
                if (s.IsAt(pt))
                {
                    // Toggle the selection state
                    s.Selected = !s.Selected;
                }
            }
        }

        public void Save(string filename)
        {
            StreamWriter writer;
            

            writer = new StreamWriter(filename);

            writer.WriteColor(Background);
            writer.WriteLine(ShapeCount);

            foreach (Shape s in _shapes)
            {
                s.SaveTo(writer);
            }
            writer.Close();
        }

        public void Load(string filename) 
        {
            StreamReader reader;
           
            int count;
            Shape s;
            string kind;

            reader = new StreamReader(filename);

            Background = reader.ReadColor();
            count = reader.ReadInteger();

            //ask shapes to clear its list
            _shapes.Clear();

            for (int i = 0; i < count; i++) 
            {   
                kind = reader.ReadLine();

               switch(kind)
                {
                    case "Rectangle":
                        s = new MyRectangle();
                        break;
                    case "Circle":
                        s = new MyCircle();
                        break;
                    case "Line":
                        s = new MyLine();
                        break;
                    default:
                        throw new InvalidDataException("Unknown shape kind: " + kind);
                }
                //tell s to Load From reader
                s.LoadFrom(reader);
                AddShape(s);
            }
             //make sure the reader will always close no matter what happen
            try
            {                
            }
            finally
            {
                reader.Close();
            }

            reader.Close();
        }
    }
}
