using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tunes
{
    public class Tune
    {
        private int index;
        public int Index
        {
            get
            {
                return index;
            }

            set
            {
                index = value;
            }
        }

        private string title;
        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        private string altTitle;
        public string AltTitle
        {
            get
            {
                return altTitle;
            }

            set
            {
                altTitle = value;
            }
        }

        private string keySig;
        public string KeySig
        {
            get
            {
                return keySig;
            }

            set
            {
                keySig = value;
            }
        }

        private string timeSig;
        public string TimeSig
        {
            get
            {
                return timeSig;
            }

            set
            {
                timeSig = value;
            }
        }

        public Tune(int i, string ti, string alt, string key, string tim)
        {
            Index = i;
            Title = ti;
            AltTitle = alt;
            KeySig = key;
            TimeSig = tim;
        }

        public Tune()
            : this(0, "", "", "", "")
        {
        }

        public override string ToString()
        {
            string written = (DetectEmptyInt(Index) + DetectEmptyString(Title) + DetectEmptyString(AltTitle) + DetectEmptyString(KeySig) + DetectEmptyString(TimeSig));
            return written;
        }

        public string DetectEmptyInt(int check)
        {
            if (check > 0)
            {
                string answer = (check+"; ");
                return answer;
            }
            else
            {
                string answer = ("");
                return answer;
            }
        }

        public string DetectEmptyString(string check)
        {
            if (check == "")
            {
                return ("");
            }
            else
            {
                return (check+"; ");
            }
        }
    }
    
    class Program
    {
        static List<Tune> tunes = new List<Tune>();

        static void LoadTunes(string filename)
        {
            string[] lines = System.IO.File.ReadAllLines(filename);

            Tune ATune = new Tune();//This will be filled and then added to the list
            bool mainTitle = true;//indicates the main title has yet to be found
            bool firstAltTitle = true;//indicates an alt title has yet to be found
            
            foreach (string line in lines)
            {
                string[] current = line.Split(':');

                if (current.Length == 2)//2 elements means it could be a relevant line
                {
                    if (current[0] == "X")//Detects an Index - Only if the letter is the only thing on the left will these execute
                    {
                        ATune.Index = Convert.ToInt32(current[1]);
                    }
                    else if (current[0] == "T" && mainTitle)//Detects a Main Title
                    {
                        ATune.Title = current[1];
                        mainTitle = false;
                    }
                    else if (current[0] == "T" && firstAltTitle)//Detects the first Alt Title
                    {
                        ATune.AltTitle = current[1];
                        firstAltTitle = false;
                    }
                    else if (current[0] == "M")//Detects a Key Sig
                    {
                        ATune.KeySig = current[1];
                    }
                    else if (current[0] == "K")//Detects a Time Sig
                    {
                        ATune.TimeSig = current[1];

                        //when it gets here, ATune contains a complete instance of Tune
                        tunes.Add(ATune);//ATune is inserted into tunes

                        //resetting the bools for the next iteration
                        mainTitle = true;
                        firstAltTitle = true;

                        ATune = new Tune();//resets ATune for the next tune
                    }
                }
            }
        }

        static void PrintTunes(string keyword)
        {
            foreach (Tune current in tunes)
            {
                if ((((current.Title.ToLower()).IndexOf(keyword)) != -1) || (((current.AltTitle.ToLower()).IndexOf(keyword)) != -1) || (keyword == ""))
                {
                    Console.WriteLine(current);
                }
            }
        }
        
        static void Main(string[] args)
        {
            string input;
            bool loop = true;

            LoadTunes("hnr1.abc");

            while (loop)
            {
                Console.WriteLine("Enter a keyword to search for or \"quit\" to quit");
                input = Console.ReadLine();

                if (input.ToLower() == "quit")
                {
                    loop = false;
                }
                else
                {
                    PrintTunes(input.ToLower());
                }
            }

            Console.WriteLine("Goodbye");
        }
    }
}
