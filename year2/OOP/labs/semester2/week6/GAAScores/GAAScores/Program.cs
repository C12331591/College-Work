using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GAAScores
{
    class Score
    {
        private int goals;
        private int points;
        private int scoreAsPoints;

        public int Goals
        {
            get { return goals; }
            set
            {
                goals = value;
                ScoreAsPoints = (goals * 3) + points;
            }
        }

        public int Points
        {
            get { return points; }
            set
            {
                points = value;
                ScoreAsPoints = (goals * 3) + points;
            }
        }

        public int ScoreAsPoints
        {
            get { return scoreAsPoints; }
            set { scoreAsPoints = value; }
        }

        public Score()
        {
            Goals = 0;
            Points = 0;
        }

        public static Score operator +(Score s1, Score s2)
        {
            Score added = new Score();
            added.Goals = s1.goals + s2.goals;
            added.points = s1.points + s2.points;
            return added;
        }

        public static bool operator ==(Score s1, Score s2)
        {
            return (s1.ScoreAsPoints == s2.ScoreAsPoints);
        }

        public static bool operator !=(Score s1, Score s2)
        {
            return !(s1 == s2);
        }

        public static bool operator >(Score s1, Score s2)
        {
            return (s1.ScoreAsPoints > s2.ScoreAsPoints);
        }

        public static bool operator <(Score s1, Score s2)
        {
            return (s1.ScoreAsPoints < s2.ScoreAsPoints);
        }

        public static bool operator >=(Score s1, Score s2)
        {
            return (s1 > s2 || s1 == s2);
        }

        public static bool operator <=(Score s1, Score s2)
        {
            return (s1 < s2 || s1 == s2);
        }

        public override string ToString()
        {
            return Goals + " Goals, " + Points + " Points";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Score score1 = new Score();
            Score score2 = new Score();
            Score score3 = new Score();

            score1.Goals = 1;
            score1.Points = 6;

            score2.Goals = 2;
            score2.Points = 3;

            score3.Goals = 2;
            score3.Points = 5;

            Console.WriteLine("Score 1 is {0}", score1);
            Console.WriteLine("Score 2 is {0}", score2);
            Console.WriteLine("Score 3 is {0}", score3);

            if (score1 == score2)
            {
                Console.WriteLine("{0} == {1}", score1, score2);
            }
            else
            {
                Console.WriteLine("{0} != {1}", score1, score2);
            }

            if (score1 == score3)
            {
                Console.WriteLine("{0} == {1}", score1, score3);
            }
            else
            {
                Console.WriteLine("{0} != {1}", score1, score3);
            }

            Score combination1 = score1 + score2;
            Score combination2 = score1 + score3;
            Score combination3 = score2 + score3;

            /*Console.WriteLine("{0} + {1} = {2} or {4})", score1, score2, score1 + score2, combination1.ScoreAsPoints);
            Console.WriteLine("{0} + {1} = {2} or {4})", score2, score3, (score2 + score3), (score2 + score3).ScoreAsPoints);
            Console.WriteLine("{0} + {1} = {2} or {4})", score1, score3, (score1 + score3), (score1 + score3).ScoreAsPoints);*/

            Console.WriteLine("Score1 + Score2 = {0}", combination1);
            Console.WriteLine("Score1 + Score3 = {0}", combination2);
            Console.WriteLine("Score2 + Score3 = {0}", combination3);

            if (score3 > score1)
            {
                Console.WriteLine("{0} > {1}", score3, score1);
            }

            if (score2 < score3)
            {
                Console.WriteLine("{0} < {1}", score2, score3);
            }

            if (score1 <= score3)
            {
                Console.WriteLine("{0} <= {1}", score1, score3);
            }

            if (score1 <= score2)
            {
                Console.WriteLine("{0} <= {1}", score1, score2);
            }

            if (combination1 >= combination2)
            {
                Console.WriteLine("{0} >= {1}", combination1, combination2);
            }

            if (combination3 >= combination1)
            {
                Console.WriteLine("{0} >= {1}", combination3, combination1);
            }

            Console.ReadLine();
        }
    }
}
