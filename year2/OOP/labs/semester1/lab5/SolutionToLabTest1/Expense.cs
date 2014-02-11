using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Expenses
{
    public class Expense
    {
        private string name;
        public string Name//property for name
	    {
		    get { return name; }
		    set { name = value; }
	    }
        private string party;
        public string Party//property for party
	    {
		    get { return party; }
		    set { party = value; }
	    }
        private string region;

        public string Region//property for region
        {
          get { return region; }
          set { region = value; }
        }
        private float returned;
        public float Returned//property for returned
	    {
		    get { return returned; }
		    set { returned = value; }
	    }
        private float claimed;
	    public float Claimed//property for claimed
	    {
		    get { return claimed; }
		    set { claimed = value; }
	    }

        public float Total
        {
          get { return claimed - returned; }
        }

        public Expense()//default construtor
        {
            name = "";
            party = "";
            region = "";
            returned = 0;
            claimed = 0;
        }

        public Expense(string line)//constructor for receiving the data as one string
        {
            string[] fields = line.Split('\t');//received line is split by tab into 5 fields
            name = fields[0];
            party = fields[1];
            region = fields[2];
            returned = float.Parse(fields[3]);//converted to a float as it is 
            claimed = float.Parse(fields[4]);
        }

        public override string ToString()//custom-defined method to represent this class as a string
        {
            return name + "\t" + party + "\t" + region + "\t" + returned + "\t" + claimed + "\t" + Total;
        }
    }
}
