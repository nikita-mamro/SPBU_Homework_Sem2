using System;
using System.Collections.Generic;

namespace TestTask
{
    /// <summary>
    /// Разделитель строки на слова
    /// </summary>
    static public class StringSeparator
    {
        /// <summary>
        /// Принимает строку и возвращает список слов в ней
        /// </summary>
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
