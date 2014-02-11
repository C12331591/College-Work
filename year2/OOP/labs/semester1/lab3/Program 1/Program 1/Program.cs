using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle c1 = new Circle();

            c1.Radius = 3.0f;
            c1.centre.X = 1.0f;
            c1.centre.Y = 2.0f;

            Console.WriteLine("A circle with the centre {0},{1} and the radius {2} has a circumference of {3} and an area of {4}.", c1.centre.X, c1.centre.Y, c1.Radius, c1.circumference, c1.area);
            Console.ReadLine();
        }
    }

    struct Point
    {
        private float x;
        public float X
        {
            get { return x; }
            set { x = value; }
        }

        private float y;
        public float Y
        {
            get { return y; }
            set { y = value; }
        }
    }

    struct Circle
    {
        public Point centre;

        private float radius;
        public float Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        public float circumference
        {
            get
            {
                return (2.0f * 3.14f * Radius);
            }
        }

        public float area
        {
            get
            {
                return (3.14f * (radius * Radius));
            }
        }
    }


}
