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
                }
                else if ( wordPos == -1 && i < (words.Length-1) )
                {
                    Word newWord = new Word(words[i], words[i+1]);

                    Vocabulary.Add(newWord);
                }
                else if (wordPos == -1)
                {
                    Word newWord = new Word(words[i]);

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

        public int WordPos(string search)
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
