using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;//needed for stringreader

namespace daniWindow
{
    public class Word
    {
        private string text;//what the word is

        public string Text
        {
            get
            {
                return text;
            }
        }

        public List<string> next = new List<string>();

        /* bools to indicate some of the word's attributes
         * false doesn't necessarily mean that it can't be used in the context; it just means it isn't known to have been used in the context
         * similarly, true means simply that the word was used in the context. It doesn't restrict it to only the true context(s)
         * These bools will be used to make more suitable (in theory) words more likely to be chosen
         */
        public bool start = false;
        public bool end = false;
        public bool question = false;
        public bool answer = false;

        public bool upper = false;//this indicates whether the word should begin with a capital.

        public Word(string Word, string Next)
        {
            text = Word;

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

        public int Follow//The number of following words
        {
            get
            {
                return next.Count;
            }
        }
    }
    
    public class DaniCore
    {
        private List<Word> Vocabulary = new List<Word>();
        private Random ran = new Random();

        public string Parse(string Sentence, bool answer)
        {
            bool question = false;
            List<string> words = new List<string>();
            int i = 0;
            int wordPos = 0;
            StringReader letterchecker;

            if (Sentence.IndexOf("?") != -1)
            {
                question = true;
            }

            Sentence = RemovePunctuation(Sentence);
            words = Sentence.Split(' ').ToList<string>();
            words.Remove("");//If the input had multiple spaces in a row, then the words list will contain empty elements. This removes them.
            
            for (i = 0; i < words.Count; i++)
            {
                letterchecker = new StringReader(words[i]);
                char[] firstletter = new char[1];
                letterchecker.Read(firstletter, 0, 1);
                bool upper = false;

                if (Char.IsUpper(firstletter[0]))
                {
                    upper = true;
                }
                
                words[i] = words[i].ToLower();//every word is stored in all lower case
                
                wordPos = WordPos(words[i]);

                if ( wordPos != -1 )//a new word
                {
                    if (i < (words.Count-1) )
                    {
                        Vocabulary[wordPos].AddNewNext( words[i + 1].ToLower() );
                    }

                    if (i == 0)
                    {
                        Vocabulary[wordPos].start = true;
                    }

                    if (question)
                    {
                        Vocabulary[wordPos].question = true;
                    }

                    if (answer)
                    {
                        Vocabulary[wordPos].answer = true;
                    }

                    if (upper && i > 0)//detecting if the word should be capitalised
                    {
                        Vocabulary[wordPos].upper = true;
                    }

                    if (i == (words.Count-1) )
                    {
                        Vocabulary[wordPos].end = true;
                    }
                }
                else//an existing word
                {
                    Word newWord;
                    
                    if (i < (words.Count - 1))
                    {
                        newWord = new Word(words[i], words[i + 1].ToLower());//add current word with a follow word
                    }
                    else
                    {
                        newWord = new Word(words[i]);//add current word only
                    }

                    if (i == 0)
                    {
                        newWord.start = true;
                    }

                    if (question)
                    {
                        newWord.question = true;
                    }

                    if (answer)
                    {
                        newWord.answer = true;
                    }

                    if (upper && i > 0)
                    {
                        newWord.upper = true;
                    }

                    if (i == (words.Count - 1))
                    {
                        newWord.end = true;
                    }

                    Vocabulary.Add(newWord);
                }
            }

            return (Answer(words, question));
        }

        private string Answer(List<string> parsedSentence, bool question)
        {
            string response = "";
            string current = "";
            
            int wordPos = 0;
            int length = 0;
            int questionCount = 0;
            bool asking = false;
            bool endSentence = false;

            current = ChooseWord(parsedSentence, question, true);//choosing the beginning word
            wordPos = WordPos(current);//this must be set before capitalisation occurs, otherwise the word cannot be detected

            current = char.ToUpper(current[0]) + current.Substring(1);//The beginning word should always be capitalised
            response = response + current;

            while ( Vocabulary[wordPos].Follow != 0 && length < 20 && !endSentence )//a sentence in excess of 20 words is rarely coherent anyway
            {
                response = response + " ";

                current = ChooseWord(Vocabulary[wordPos].next, question, false);//choosing all subsequent words
                wordPos = WordPos(current);

                if (Vocabulary[wordPos].upper)//detecting if the word should be capitalised
                {
                    current = char.ToUpper(current[0]) + current.Substring(1);
                }

                response = response + current;

                length++;

                if (Vocabulary[wordPos].question)
                {
                    questionCount++;
                }

                if (Vocabulary[wordPos].end && (ran.Next(2) == 1) )//if the current word is an end word, there is a chance to end the sentence
                {
                    endSentence = true;
                }
            }

            if (questionCount > length / 2)//deciding if the sentence is a question
            {
                asking = true;
            }

            if (asking)
            {
                response = response + "?";
            }
            else
            {
                response = response + ".";
            }

            return(response);
        }

        private int WordPos(string search)//similar to IndexOf, but finds a string in the Vocabulary list rather than a substring in a single string
        {
            int i = 0;

            for (i = 0; i < Vocabulary.Count; i++)
            {
                if (Vocabulary[i].Text == search)
                {
                    return (i);
                }
            }

            return (-1);
        }

        private string RemovePunctuation(string sentence)
        {
            string[] remove = { "?", "!", "\"", ".", "," };//all the characters to remove

            foreach (string current in remove)
            {
                sentence = sentence.Replace(current, "");
            }

            return sentence;
        }

        private string ChooseWord(List<string> choices, bool question, bool start)
        {
            List<string> Chances = new List<string>();
            string chosen = "";
            int wordPos = -1;

            foreach (string current in choices)
            {
                wordPos = WordPos(current);
                
                Chances.Add(current);//Every word is given a chance. Additional chances are given for fulfilling a condition. The most suitable word(s) will get the most chances

                if (Vocabulary[wordPos].Follow > 2)//An additional chance is given to words with a good choice of following words
                {
                    Chances.Add(current);
                }

                if (question)
                {
                    if (Vocabulary[wordPos].answer)
                    {
                        Chances.Add(current);
                    }
                }

                if (start)
                {
                    if (Vocabulary[wordPos].start)
                    {
                        Chances.Add(current);
                    }
                }

                if (Vocabulary[wordPos].end)
                {
                    Chances.Add(current);
                }
            }

            chosen = Chances[ran.Next(0, Chances.Count)];

            return chosen;
        }
    }
}
