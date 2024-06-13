using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ShapeDrawer
{
    public class MyRectangle : Shape
    {
        private int _width;
        private int _height;
        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        public MyRectangle(Color color, float x, float y, int width, int height) : base(color)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public MyRectangle() : this(Color.Green, 0.0f, 0.0f, 100, 100)
        {
        }

        public override void Draw()
        {
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);

            if (_selected)
            {
                DrawOutline();
            }
        }

        // Override the DrawOutline method using base class implementation
        public override void DrawOutline()
        {
            SplashKit.DrawRectangle(Color.Black, _x - 2, _y -2 , _width + 4, _height + 4);
        }

        // Override the IsAt method using base class implementation
        public override bool IsAt(Point2D pt)
        {
           
            return pt.X >= _x && pt.X <= _x + _width &&
                   pt.Y >= _y && pt.Y <= _y + _height;
           
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Rectangle");
            base.SaveTo(writer);

            writer.WriteLine(Width);
            writer.WriteLine(Height);
        }
        public override void LoadFrom(StreamReader reader)
        {           
            base.LoadFrom(reader);
            Width = reader.ReadInteger();
            Height = reader.ReadInteger();
        }
    }
}
