/*Program to calculate the two roots of a quadratic equation
 * Brian Willis
 * 17/9/2013
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program_3
{
    class Program
    {
        static void Main(string[] args)
        {
            float a, b, c;
            float r1, r2;
            float negb=0;

            Console.WriteLine("Input the value of A:");
            a = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Input the value of B:");
            b = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Input the value of C:");
            c = Convert.ToSingle(Console.ReadLine());

            negb = negb-b;

            r1 = (negb + ((float)Math.Sqrt((b * b) - ((4.0f * a) * c)))) / (2.0f * a);
            r2 = (negb - ((float)Math.Sqrt((b * b) - ((4.0f * a) * c)))) / (2.0f * a);

            Console.WriteLine("The two roots are {0} and {1}", r1, r2);

            Console.ReadLine();
        }
    }
}
