using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace shapes
{
    public class Point
    {
        private float x;
        public float X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        private float y;
        public float Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }

        public Point(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public Point()
            : this(0.0f, 0.0f)
        {
        }

        public override string ToString()
        {
            string written = ("Point " + X + ", " + Y);
            return written;
        }
    }

    public class Line
    {
        public Point start = new Point();
        public Point end = new Point();

        public float Slope
        {
            get
            {
                return ((end.Y - start.Y) / (end.X - start.X));
            }
        }

        public float Intercept
        {
            get
            {
                return (start.Y - (Slope * start.X));
            }
        }

        public Line(Point Start, Point End)
        {
            start = new Point(Start.X, Start.Y);
            end = new Point(End.X, End.Y);
        }

        public Line()
            : this(new Point(), new Point())
        {
        }

        public override string ToString()
        {
            string written = ("Line " + start.X + ", " + start.Y + " to " + end.X + ", " + end.Y);
            return written;
        }
    }

    public class Shape
    {
        public Point centre = new Point();

        public virtual float Area()
        {
            Console.WriteLine("Couldn't calculate the area.");
            return (0.0f);
        }

        public Shape(Point Centre)
        {
            centre = Centre;
        }

        public Shape()
            : this(new Point())
        {
        }

        public override string ToString()
        {
            string written = ("Shape " + "centre: " + centre);
            return written;
        }
    }

    public class Box : Shape
    {
        public float width;

        public override float Area()
        {
            return (width * width);
        }

        public Box(Point Centre, float Width)
        {
            centre = Centre;
            width = Width;
        }

        public Box()
            : this(new Point(), 0.0f)
        {
        }

        public override string ToString()
        {
            string written = ("Box " + "centre: " + centre + " width: " + width);
            return written;
        }
    }

    public class Circle : Shape
    {
        public float radius;

        public float Pi
        {
            get
            {
                return 3.14f;
            }
        }

        public override float Area()
        {
            return (Pi) * (radius * radius);
        }

        public Circle(Point Centre, float Radius)
        {
            centre = Centre;
            radius = Radius;
        }

        public Circle()
            : this(new Point(), 0.0f)
        {
        }

        public override string ToString()
        {
            string written = ("Circle " + "centre: " + centre + " radius: " + radius);
            return written;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Line exampleLine = new Line(new Point(2.0f, 3.0f), new Point(3.0f, 2.0f));
            Box exampleBox = new Box(new Point(1.0f , 2.0f) ,5.5f);
            Circle exampleCircle = new Circle(new Point(2.0f , 1.0f) ,6.5f);

            Console.WriteLine(exampleLine);
            Console.WriteLine("Slope: {0} Intercept:{1}", exampleLine.Slope, exampleLine.Intercept);
            
            Console.WriteLine(exampleBox);
            Console.WriteLine("Area: {0}", exampleBox.Area());

            Console.WriteLine(exampleCircle);
            Console.WriteLine("Area: {0}", exampleCircle.Area());
        }
    }
}
