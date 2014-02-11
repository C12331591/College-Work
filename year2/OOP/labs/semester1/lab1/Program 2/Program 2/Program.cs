/*Program to calculate the first 200 places of Fibonacci
 * Brian Willis
 * 17/9/2013
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int place = 2;
            ulong back1 = 1;
            ulong back2 = 0;
            ulong cur;

            Console.WriteLine(back2);
            Console.WriteLine(back1);

            while (place <= 200)
            {
                cur = back2 + back1;
                
                Console.WriteLine(cur);

                back2 = back1;
                back1 = cur;

                place++;
            }

            Console.ReadLine();
        }
    }
}
