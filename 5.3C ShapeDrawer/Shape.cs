using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ShapeDrawer
{
    public abstract class Shape
    {
        protected Color _color;
        protected float _x;
        protected float _y;
     
        protected bool _selected;

        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }
        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }
        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }
        public bool Selected
        {
            get 
            {
                return _selected;   
            }
            set
            {
                    
                _selected = value;
            }
        }
        
        public Shape(Color Color)
        {
            _color = Color;
            _x = 0.0f;
            _y = 0.0f;
        }
        public abstract void Draw();
        public abstract bool IsAt(Point2D pt);
        public abstract void DrawOutline();

        public virtual void SaveTo(StreamWriter writer)
        {
            writer.WriteColor(Color);
            writer.WriteLine(X);
            writer.WriteLine(Y);
        }

        public virtual void LoadFrom(StreamReader reader)
        {
            Color = reader.ReadColor();
            X = reader.ReadInteger();
            Y = reader.ReadInteger();
        }
    }
}
