using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Synthesis;

namespace DANI
{
    class Program
    {
        static void Main(string[] args)
        {
            //TwoDANIs();
            SpeechSynthesizer talkingDANI = new SpeechSynthesizer();

            string input = "";
            string response = "";
            DaniCore DANI = new DaniCore();

            while (input != "quit")
            {
                input = Console.ReadLine();

                if (input != "quit")//no point in processing everything if it is quit
                {
                    if (response.IndexOf("?") == -1)//detecting if DANI asked a question
                    {
                        response = DANI.Parse(input, false);
                    }
                    else
                    {
                        response = DANI.Parse(input, true);
                    }

                    Console.WriteLine(response);
                    talkingDANI.SpeakAsync(response);
                }
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
                    response = DANI1.Parse(input, false);
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
                    response = DANI2.Parse(input, false);
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
