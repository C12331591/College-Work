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
            //TwoDANIs();
            string input = "";
            DaniCore DANI = new DaniCore();

            while (input != "quit")
            {
                input = Console.ReadLine();

                Console.WriteLine(DANI.Parse(input));
            }
        }

        static public void TwoDANIs()//experimental, hacktastic method. Do not use in final program.
        {
            string input = "";
            string input2 = "";
            DaniCore DANI1 = new DaniCore();
            DaniCore DANI2 = new DaniCore();
            bool which = true;
            string response = "";

            while (input != "quit")
            {
                Console.WriteLine("Override?");
                input2 = Console.ReadLine();

                if (input2 == "y")
                {
                    input = Console.ReadLine();
                }

                if (which)
                {
                    response = DANI1.Parse(input);
                    Console.WriteLine("DANI 1:" + response);

                    Console.WriteLine("Send to DANI2?");
                    input = Console.ReadLine();

                    if (input == "y")
                    {
                        which = false;
                        input = response;
                    }
                }
                else
                {
                    response = DANI2.Parse(input);
                    Console.WriteLine("DANI 2: " + response);

                    Console.WriteLine("Send to DANI1?");
                    input = Console.ReadLine();

                    if (input == "y")
                    {
                        which = true;
                        input = response;
                    }
                }
            }
        }
    }
}
