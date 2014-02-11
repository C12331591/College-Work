using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program2
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "The desired result";
            Console.WriteLine("Original string: " + s);
            Console.WriteLine("Encrypted string: " + encrypt(s));
            string en = "umvtfs!efsjtfe!fiU";
            Console.WriteLine("Decrypted string: " + decrypt(en));

            Console.ReadLine();
        }//end main

        static string encrypt(string rs)
        {
            char[] conv = rs.ToCharArray();//copying rs to a char array to edit the elements

            int i;

            for (i = 0; i < rs.Length; i++)
            {
                conv[i] = (char)((int)conv[i] + 1);//offsetting the values by 1
            }

            conv=conv.Reverse().ToArray();//reversing the array

            rs = new string(conv);//copying the array back to rs

            return (rs);
        }//end encrypt

        static string decrypt(string rs)
        {
            char[] conv = rs.ToCharArray();//copying rs to a char array to edit the elements

            int i;

            for (i = 0; i < rs.Length; i++)
            {
                conv[i] = (char)((int)conv[i] - 1);//offsetting the values by -1 back to the original value
            }

            conv = conv.Reverse().ToArray();//reversing the array, making it the correct way round

            rs = new string(conv);//copying the array back to rs

            return (rs);
        }//end decrypt
    }
}
