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
            Person[] people;
            people = new Person[10];

            people[0].name = "Pat";
            people[0].intake = 12;

            people[1].name = "Francois";
            people[1].intake = 18;

            people[2].name = "Bryan";
            people[2].intake = 10;

            people[3].name = "derek";
            people[3].intake = 25;

            people[4].name = "Mario";
            people[4].intake = 35;

            people[5].name = "Shane";
            people[5].intake = 12;

            people[6].name = "Millhouse";
            people[6].intake = 0;

            people[7].name = "Stephen";
            people[7].intake = 0;

            people[8].name = "Barry";
            people[8].intake = 10;

            people[9].name = "Liam";
            people[9].intake = 40;
            
            foreach (Person cur in people)
            {
                Console.Write("{0}\t{1}\t", cur.name, cur.intake);

                if (cur.intake > 21)
                {
                    Console.WriteLine("EXCESSIVE");
                }
                else if (cur.intake > 15)
                {
                    Console.WriteLine("WARNING");
                }
                else
                {
                    Console.WriteLine("SAFE");
                }
            }//end foreach

            Console.ReadLine();
        }
    }

    struct Person
    {
        public string name;
        public int intake;
    }
}
