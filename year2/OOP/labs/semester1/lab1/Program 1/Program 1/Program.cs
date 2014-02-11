/*Program to repeatedly print a phrase with different spacing
 * Brian Willis
 * 17/9/2013
 */

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
            int spaces = 0;
            int i, j;

            for (i = 0; i < 21; i++)
            {
                for (j = 0; j < spaces; j++)
                {
                    Console.Write(" ");
                }
                
                Console.WriteLine("I Love DIT!!!");

                if (i < 10)
                {
                    spaces++;
                }
                else
                {
                    spaces--;
                }//end if
            }//end for

            Console.ReadLine();
        }
    }
}
