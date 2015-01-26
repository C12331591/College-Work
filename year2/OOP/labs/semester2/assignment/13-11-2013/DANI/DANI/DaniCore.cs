using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DANI
{
    private class Word
    {
        public string word;//maybe make a property or two for this
        public List<string> next;

        /*bools to indicate some of the word's attributes
         * false doesn't necessarily mean that it can't be used in the context; it just means it isn't known to have been used in the context
         * similarly, true means simply that the word was used in the context. It doesn't restrict it to only the true context(s)
         * These bools will be used to choose hopefully preferable words by preferring ones marked for the context 
         */
        public bool start = false;

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
    }
    
    public class DaniCore
    {
        public List<Word> Vocabulary;

        public string Parse(string Sentence)
        {
            string[] words = Sentence.Split(' ');
            int i = 0;
            int wordPos = 0;

            for (i = 0; i < words.Length; i++)
            {
                //remove punctuation here or earlier
                wordPos = WordPos(words[i]);
                
                if ( wordPos != -1 && i < (words.Length-1) )
                {
                    Vocabulary[wordPos].AddNewNext(words[i + 1]);

                    if (i == 0)
                    {
                        Vocabulary[wordPos].start = true;
                    }
                }
                else if ( wordPos == -1 && i < (words.Length-1) )
                {
                    Word newWord = new Word(words[i], words[i+1]);

                    if (i == 0)
                    {
                        newWord.start = true;
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

                    Vocabulary.Add(newWord);
                }
            }

            return (Answer(words));
        }

        private string Answer(string[] parsedSentence)
        {
            string response = "";
            //logic for creating an answer here
            return (response);
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
    }
}
