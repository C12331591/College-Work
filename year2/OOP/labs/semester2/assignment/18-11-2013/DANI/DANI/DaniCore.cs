using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;//needed for stringreader

namespace DANI
{
    public class Word
    {
        public string word;//maybe make a property or two for this
        public List<string> next = new List<string>();

        /*bools to indicate some of the word's attributes
         * false doesn't necessarily mean that it can't be used in the context; it just means it isn't known to have been used in the context
         * similarly, true means simply that the word was used in the context. It doesn't restrict it to only the true context(s)
         * These bools will be used to make more suitable (in theory) words more likely to be chosen
         */
        public bool start = false;
        public bool question = false;
        public bool answer = false;

        public bool upper = false;//this indicates whether the word should begin with a capital.

        public Word(string Word, string Next)
        {
            if (Word != "")
            {
                word = Word;
            }

            if (Next != "")
            {
                next.Add(Next);
            }
        }

        public Word(string Word)
            : this(Word, "")
        {
        }

        public Word()
            : this("", "")
        {
        }

        public void AddNewNext(string addition)
        {
            foreach (string currentNext in next)
            {
                if (addition == currentNext)
                {
                    return;
                }
            }

            next.Add(addition);
        }

        public int Follow
        {
            get
            {
                return next.Count;
            }
        }
    }
    
    public class DaniCore
    {
        public List<Word> Vocabulary = new List<Word>();

        public string Parse(string Sentence)
        {
            bool question = false;
            string[] words = new string[0];
            int i = 0;
            int wordPos = 0;
            StringReader letterchecker;

            if (Sentence.IndexOf("?") != -1)
            {
                question = true;
            }

            Sentence = RemovePunctuation(Sentence);
            words = Sentence.Split(' ');
            
            for (i = 0; i < words.Length; i++)
            {
                 letterchecker = new StringReader(words[i]);
                char[] firstletter = new char[1];
                letterchecker.Read(firstletter, 0, 1);
                bool upper = false;

                if (Char.IsUpper(firstletter[0]))
                {
                    upper = true;
                    
                    words[i] = words[i].ToLower();
                }
                
                words[i] = words[i].ToLower();
                
                wordPos = WordPos(words[i]);
                
                if ( wordPos != -1 && i < (words.Length-1) )
                {
                    Vocabulary[wordPos].AddNewNext(words[i + 1]);

                    if (i == 0)
                    {
                        Vocabulary[wordPos].start = true;
                    }

                    if (question)
                    {
                        Vocabulary[wordPos].question = true;
                    }

                    if (upper && i > 0)
                    {
                        Vocabulary[wordPos].upper = true;
                    }
                }
                else if ( wordPos == -1 && i < (words.Length-1) )
                {
                    Word newWord = new Word(words[i], words[i+1]);

                    if (i == 0)
                    {
                        newWord.start = true;
                    }

                    if (question == true)
                    {
                        newWord.question = true;
                    }

                    if (upper && i > 0)
                    {
                        Vocabulary[wordPos].upper = true;
                    }

                    Vocabulary.Add(newWord);
                }
                else if (wordPos == -1)
                {
                    Word newWord = new Word(words[i]);

                    if (i == 0)
                    {
                        newWord.start = true;
                    }

                    if (question == true)
                    {
                        newWord.question = true;
                    }

                    if (upper && i > 0)
                    {
                        Vocabulary[wordPos].upper = true;
                    }

                    Vocabulary.Add(newWord);
                }
            }

            return (Answer(words, question));
        }

        private string Answer(string[] parsedSentence, bool question)
        {
            string response = "";
            string current = "";
            int wordPos = 0;

            current = ChooseWord(parsedSentence, question, true);//choosing the beginning word
            response = response + current;
            wordPos = WordPos(current);

            while ( Vocabulary[wordPos].Follow != 0 )
            {
                response = response + " ";

                //check the upper flag for each word and make the first letter upper case where necessary.

                current = ChooseWord(Vocabulary[wordPos].next.ToArray(), question, false);//choosing all subsequent words
                response = response + current;

                wordPos = WordPos(current);
            }

            //add a way to determine if it's asking a question
            //and then add a way to add a . or ? to the end

            return(response);
        }

        private int WordPos(string search)//similar to IndexOf, but finds a string in an array of strings rather than a substring in a single string
        {
            int i = 0;

            for (i = 0; i < Vocabulary.Count; i++)
            {
                if (Vocabulary[i].word == search)
                {
                    return (i);
                }
            }

            return (-1);
        }

        private string RemovePunctuation(string sentence)
        {
            string[] remove = { "?", "!", "\"", ".", "," };

            foreach (string current in remove)
            {
                sentence = sentence.Replace(current, "");
            }

            return sentence;
        }

        Random ran = new Random();//This is for use with ChooseWord. It has to be outside because otherwise it is unreliable
        
        private string ChooseWord(string[] choices, bool question, bool start)
        {
            List<string> Chances = new List<string>();
            string chosen = "";

            foreach (string current in choices)
            {
                Chances.Add(current);//Every word is given a chance. Additional chances are given for fulfilling a condition.
            }

            foreach (string current in choices)
            {
                if (Vocabulary[WordPos(current)].Follow > 2)//An additional chance is given to words with a good choice of following words
                {
                    Chances.Add(current);
                }
            }

            if (question)
            {
                foreach (string current in choices)
                {
                    if (Vocabulary[WordPos(current)].answer)
                    {
                        Chances.Add(current);
                    }
                }
            }

            if (start)
            {
                foreach (string current in choices)
                {
                    if (Vocabulary[WordPos(current)].start)
                    {
                        Chances.Add(current);
                    }
                }
            }

            chosen = Chances[ran.Next(0, Chances.Count)];

            return chosen;
        }
    }
}
