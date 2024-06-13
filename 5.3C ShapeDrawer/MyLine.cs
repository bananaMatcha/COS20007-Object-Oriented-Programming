using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
using System.IO;

namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        private float _endX;
        private float _endY;

        public MyLine(Color color, float startX, float startY, float endX, float endY) : base(color)
        {
            _color = color;
            _x = startX;
            _y = startY;
            _endX = endX;
            _endY = endY;
        }

        public MyLine() : this(Color.Red, 0.0f, 0.0f, 200, 300)
        {
        }
        public float EndX
        {
            get { return _endX; }
            set { _endX = value; }
        }

        public float EndY
        {
            get { return _endY; }
            set { _endY = value; }
        }

        public override void Draw()
        {
            SplashKit.DrawLine(Color, _x, _y, _endX, _endY);
            if(_selected)
            {
                DrawOutline();
            }
        }

        public override void DrawOutline()
        {
            SplashKit.DrawCircle(Color.Black, _x, _y, 20);
            SplashKit.DrawCircle(Color.Black, 200, 300, 20);
        }

        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointOnLine(pt, SplashKit.LineFrom(new Point2D() { X = _x, Y = _y}, new Point2D() { X = _endX, Y = _endY }));
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Line");
            base.SaveTo(writer);

            writer.WriteLine(EndX);
            writer.WriteLine(EndY);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            EndX = reader.ReadSingle();
            EndY = reader.ReadSingle();
        }
    }
}

