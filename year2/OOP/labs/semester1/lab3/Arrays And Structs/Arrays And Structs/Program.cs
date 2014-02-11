using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arrays_And_Structs
{
    // Struct definitions should appear *immediately* after the namespace
    // See this article http://msdn.microsoft.com/en-us/library/aa288471(v=vs.71).aspx
 
    // A Struct to represent a 2D point (x and y)
    // A struct is just a template like int, float etc. You have to create a variable of the struct type
    // for it to "exist" in the computers memory
    struct Point
    {
        // private means the member can only be used by methods inside the class
        private float x;
        // So we make a property so we can access the member x outside the class
        // This might seem pointless and a lot of people think it is. Just do a google search for "c# properties are evil"
        // And you will find lots of articles on this subject
        // Also check out this article http://msdn.microsoft.com/en-us/library/x9fsa0sw.aspx for a discussion about properties in general
        public float X
        {
            get { return x; }
            set { x = value; }
        }
        // The same for y
        private float y;
        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        // You should always include a ToString method exactly like this this one
        // To convert the object to a string
        // This will get called automatically if you use the object in the place where a string would go
        // For example Console.WriteLine
        // Check out this article http://msdn.microsoft.com/en-us/library/ms173154.aspx
        public override string ToString()
        {
            return "(" + x + ", " + y + ")";
        }

        // A constructor! We can make an instance of this struct by passing in the x and y
        public Point(float x, float y)
        {
            // this is used to DISAMBIGUATE between the parameters x and y and the fields x and y
            this.x = x;
            this.y = y;
        }
    }

    struct Line
    {
        // A line consists of a start Point and an end Point
        public Point StartPoint;
        public Point EndPoint;
        // Construct the line by passing in the two parameters
        public Line(Point startPoint, Point endPoint)
        {
            this.StartPoint = startPoint;
            this.EndPoint = endPoint;
        }

        // A READONLY calculated property
        // Its readonly because there is only a set and no get
        public float Slope
        {
            get
            {
                return (EndPoint.Y - StartPoint.Y) / (EndPoint.X - StartPoint.X);
            }           
        }

        // Another readonly property
        public float Intercept
        {
            get
            {
                return (StartPoint.Y - Slope * StartPoint.X);
            }            
        }

        // A method!
        bool IsPointOn(Point p)
        {
            return (((Slope * p.X) + Intercept - p.Y) == 0);
        }

        public override string ToString()
        {
            return "Start: " + StartPoint + " End: " + EndPoint;
        }
    }

    struct Person
    {
        public int age;
        public string name;      
        public Person(int age, string name)
        {
            this.age = age;
            this.name = name;
        }

        public override string ToString()
        {
            return name + "\t" + age;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
                
            int[] ages = new int[5];

            for (int i = 0; i < ages.Length; i++)
            {
                ages[i] = (r.Next() % 10) + 20;
            }

            // min
            int minVal = int.MaxValue;
            for (int i = 0; i < ages.Length; i++)
            {
                if (ages[i] < minVal)
                {
                    minVal = ages[i];
                }
            }
            Console.WriteLine("Min: " + minVal);

            // max
            int maxVal = int.MinValue;
            for (int i = 0; i < ages.Length; i++)
            {
                if (ages[i] > minVal)
                {
                    maxVal = ages[i];
                }
            }
            Console.WriteLine("Max: " + maxVal);

            // Average
            int sum = 0;
            for (int i = 0; i < ages.Length; i++)
            {
                sum += ages[i];              
            }
            Console.WriteLine("Average: " + (sum / ages.Length));

            // Searching?
            bool found = false;
            int toFind  = 25;
            int where = 0;
            while (!found && where < ages.Length)
            {
                if (ages[where] == toFind)
                {
                    found = true;
                }
                else
                {
                    where++;
                }
            }
            if (found)
            {
                Console.WriteLine("Found {0} at position {1}", toFind, where);
            }
            else
            {
                Console.WriteLine("No instance of {0} in the array", toFind);
            }

            // Constructing a struct
            Line line = new Line();
            line.StartPoint = new Point();
            line.EndPoint = new Point();
            line.StartPoint = new Point();
            line.StartPoint.X = 5;
            line.StartPoint.Y = 5;

            line.EndPoint.X = 5;
            line.EndPoint.Y = 5;

            Console.WriteLine(line);
        }
    }
}
