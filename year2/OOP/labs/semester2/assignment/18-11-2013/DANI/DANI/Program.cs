using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DANI
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            DaniCore DANI = new DaniCore();

            while (input != "quit")
            {
                input = Console.ReadLine();

                Console.WriteLine(DANI.Parse(input));
            }
        }
    }
}
