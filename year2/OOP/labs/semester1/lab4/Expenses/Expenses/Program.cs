using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Expenses
{
    class Program
    {
        //part 4
        static void Main(string[] args)
        {
            LoadExpenses("expenses.txt");

            string input = "";

            while (input != "quit")
            {
                Console.WriteLine("Enter the name of a aparty or \"quit\" to quit");
                input = Console.ReadLine();
                PrintExpenses(input);
            }

            Console.WriteLine("Goodbye");
        }

        //part 1
        public class Expenses
        {
            public string name;
            public string party;
            public string constituency;
            public float returned;
            public float claimed;

            public float Total
            {
                get
                {
                    return (claimed - returned);
                }
            }

            Expenses()
            {
                this.name = "";
                this.party = "";
                this.constituency = "";
                this.returned = 0.0f;
                this.claimed = 0.0f;
            }

            public override string ToString()
            {
                string answer = (name + " " + party + " " + constituency + " " + Convert.ToString(returned) + " " + Convert.ToString(claimed) + " " + Convert.ToString(Total));
                
                return (answer);
            }
        }

        //part 2
        static public Expenses[] exArray = new Expenses[1];
        
        static void LoadExpenses(string filename)
        {
            string[] lines = System.IO.File.ReadAllLines(filename);
            string[] divided = new string[5];
            exArray = new Expenses[lines.Length];

            int i=0;
            
            foreach (string cur in lines)
            {
                divided = cur.Split('\t');

                exArray[i].name = divided[0];//bug here (NullReferenceException was unhandled) - I couldn't find the cause
                exArray[i].party = divided[1];
                exArray[i].constituency = divided[2];
                exArray[i].returned = (Convert.ToSingle(divided[3]));
                exArray[i].claimed = (Convert.ToSingle(divided[4]));

                i++;
            }
        }

        //part 3
        static void PrintExpenses(string partysearch)
        {
            bool foundparty = false;
            float total = 0.0f;
            int max = 0;
            int min = 0;
            int i = 0;
            
            for(i = 0; i < exArray.Length; i++)
            {
                if (exArray[i].party == partysearch)//bug here - couldn't fix it
                {
                    foundparty = true;
                    
                    Console.WriteLine(exArray[i]);

                    if (exArray[i].Total > exArray[max].Total)
                    {
                        max = i;
                    }

                    if (exArray[i].Total < exArray[min].Total)
                    {
                        min = i;
                    }
                }
            }

            if (foundparty)
            {
                Console.WriteLine("Total claimed for from party: {0} was {1}", partysearch, total);
                Console.WriteLine("Minimum claimed from party: {0} was {1} by {2}", partysearch, exArray[min].Total, exArray[min].name);
                Console.WriteLine("Maximum claimed from party: {0} was {1} by {2}", partysearch, exArray[max].Total, exArray[max].name);
            }
            else
            {
                Console.WriteLine("Party: {0} not found", partysearch);
            }
        }
    }
}
