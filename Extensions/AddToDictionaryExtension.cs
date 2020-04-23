using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatisticCollector.Extensions
{
    public static class AddToDictionaryExtension
    {
        public static void AddWords(this Dictionary<string, uint> dictionary,
           List<string> newWords)
        {
            foreach (string word in newWords)
            {
                if (dictionary.ContainsKey(word))
                {
                    dictionary[word]++;
                }
                else
                {
                    dictionary.Add(word, 1);
                }

            }


        }
    }
}

