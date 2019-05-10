using System;
using System.Collections.Generic;

namespace TestTask
{
    static public class StringSeparator
    {
        public static List<string> GetListOfWords(string sentence)
        {
            var word = "";
            var listOfWords = new List<string>();

            foreach (var symbol in sentence)
            {
                if (symbol == ' ')
                {
                    if (word.Length > 0)
                    {
                        listOfWords.Add(word);
                    }

                    word = "";
                    continue;
                }

                word += symbol;
            }

            if (word.Length > 0)
            {
                listOfWords.Add(word);
            }

            return listOfWords;
        }
    }
}
