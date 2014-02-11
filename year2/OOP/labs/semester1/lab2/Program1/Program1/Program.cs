using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "Wow that was so funny lol.";
            Console.WriteLine("The lolcount of " + s1 + " is " + lolCount(s1));

            string s2 = "lol!! I laughed so rhard! lol";
            Console.WriteLine("The lolcount of " + s2 + " is " + lolCount(s2));

            string s3 = "U r lame. lol lol lol";
            Console.WriteLine("The lolcount of " + s3 + " is " + lolCount(s3));

            string s4 = "lollollollollollollollol!!!!!";
            Console.WriteLine("The lolcount of " + s4 + " is " + lolCount(s4));

            Console.ReadLine();
        }

        static int lolCount(string rs)
        {
            int i, ans, count;
            count = 0;

            for (i = 0; i < ((rs.Length)-2); i++)//moving through the string one element at a time
            {
                ans = (rs.Substring(i, 3)).IndexOf("lol", 0);//searching 3 spaces from the current element

                if (ans != -1)//detecting if "lol" occurs in the current 3-element space
                {
                    count++;
                }
            }

            return (count);
        }
    }
}
