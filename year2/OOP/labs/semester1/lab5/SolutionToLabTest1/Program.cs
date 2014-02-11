using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Expenses
{
    class Program
    {
        static Expense[] expenses;//an instance of the class Expense called expenses

        static void LoadExpenses(string filename)//function taking one string as a parameter to use as a the name of a file to access
        {
            string[] lines = System.IO.File.ReadAllLines(filename);//creates a string array called lines and populates it with lines from the file with the name that was passed to the function
            expenses = new Expense[lines.Length];//expenses is given the same number of elements as lines
            for (int i = 0; i < lines.Length; i++)
            {
                expenses[i] = new Expense(lines[i]);//passes the current string in lines to the constructor of Expense to be converted in to an element in expenses
            }
        }

        static void PrintExpenses(string search, bool isitp)//function which accepts a string to represent the party or constituency it will search for and an indicator of which to search for
        {
            float total = 0.0f;
            float min = float.MaxValue;
            float max = float.MinValue;
            int minIndex = 0, maxIndex = 0;
            bool found = false;
            for (int i = 0; i < expenses.Length; i++)
            {
                if (isitp)
                {
                    if (expenses[i].Party.ToLower() == search)
                    {
                        found = true;
                        Console.WriteLine(expenses[i]);//writes the current element to console, since it matches the specified party
                        total += expenses[i].Total;//adds the current element's Total to total 
                        if (expenses[i].Total > max)//detecting the maximum Total so far
                        {
                            max = expenses[i].Total;//the current Total is copied into max
                            maxIndex = i;//the current position is recorded in maxIndex
                        }
                        if (expenses[i].Total < min)//detecting the minimum Total so far
                        {
                            min = expenses[i].Total;//the current Total is copied into max
                            minIndex = i;//the current position is recorded in minIndex
                        }
                    }
                }
                else
                {
                    if (expenses[i].Region.ToLower().Substring(0,3) == search)
                    {
                        found = true;
                        Console.WriteLine(expenses[i]);//writes the current element to console, since it matches the specified party
                        total += expenses[i].Total;//adds the current element's Total to total 
                        if (expenses[i].Total > max)//detecting the maximum Total so far
                        {
                            max = expenses[i].Total;//the current Total is copied into max
                            maxIndex = i;//the current position is recorded in maxIndex
                        }
                        if (expenses[i].Total < min)//detecting the minimum Total so far
                        {
                            min = expenses[i].Total;//the current Total is copied into max
                            minIndex = i;//the current position is recorded in minIndex
                        }
                    }
                }
            }
            if (found && isitp)//making sure there was at least one match for a party
            {
                Console.WriteLine("Total claimed for party: " + search + " was " + total);
                Console.WriteLine("Minimum claimed from party: " + search + " was " + expenses[minIndex].Total + " by " + expenses[minIndex].Name);
                Console.WriteLine("Maximum claimed from party: " + search + " was " + expenses[maxIndex].Total + " by " + expenses[maxIndex].Name);
            }
            else if (found)//making sure there was at least one match for a constituency
            {
                Console.WriteLine("Total claimed for constituency: " + search + " was " + total);
                Console.WriteLine("Minimum claimed from constituency: " + search + " was " + expenses[minIndex].Total + " by " + expenses[minIndex].Name);
                Console.WriteLine("Maximum claimed from constituency: " + search + " was " + expenses[maxIndex].Total + " by " + expenses[maxIndex].Name);
            }
            else if (isitp)//if there were no matches for a party
            {
                Console.WriteLine("Party " + search + " not found");
            }
            else//if there were no matches for a constituency
            {
                Console.WriteLine("Constituency " + search + " not found");
            }
        }

        static void Main(string[] args)
        {
            LoadExpenses("expenses.txt");//passes the string "expenses.txt" to LoadExpenses, so the function will draw data from the file expenses.txt

            string input;
            
            while (true)//infinite loop to be broken from within
            {
                Console.WriteLine("Enter C to search by the first 3 letters of the constituency or P to search by party or \"quit\" to quit.");
                input = Console.ReadLine();
                
                if (input.ToLower() == "p")
                {
                    Console.WriteLine("Enter the name of a party or \"quit\" to quit");
                    string party = Console.ReadLine();//reads input from the user
                    if (party.ToLower() == "quit")//detecting if the user input "quit"
                    {
                        break;
                    }
                    PrintExpenses(party, true);//calls PrintExpenses to search for the specified party
                }
                else if (input.ToLower() == "c")
                {
                    Console.WriteLine("Enter the first 3 letters of a constituency or \"quit\" to quit");
                    string con = Console.ReadLine();//reads input from the user
                    if (con.ToLower() == "quit")//detecting if the user input "quit"
                    {
                        break;
                    }
                    PrintExpenses(con.Substring(0,3), false);//calls PrintExpenses to search for the specified constituency
                }
                else if (input.ToLower() == "quit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
    }
}
