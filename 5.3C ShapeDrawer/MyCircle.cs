using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ShapeDrawer
{
    public class MyCircle : Shape
    {
        private int _radius;

        public MyCircle(Color color, int radius) : base(color)
        {
            _color = color;
            _radius = radius;
        }

        public MyCircle() : this(Color.Blue, 50)
        {
        }

        public int Radius
        {
          get { return _radius; }
          set { _radius = value; }
        }
        public override void Draw()
        {
            SplashKit.FillCircle(_color, _x, _y,_radius);

            if (_selected)
            {
                DrawOutline();
            }
        }

        public override void DrawOutline()
        {
            SplashKit.DrawCircle(Color.Black, _x, _y, _radius + 2);
        }
        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointInCircle(pt, SplashKit.CircleAt(_x, _y, _radius)); 
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Circle");
            base.SaveTo(writer);

            writer.WriteLine(Radius);          
        }
        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Radius = reader.ReadInteger();
        }
    }
}
