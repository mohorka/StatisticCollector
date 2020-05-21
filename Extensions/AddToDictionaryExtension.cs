using StatisticCollector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using StatisticCollector.Services;
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
                    if (word.Length > 3)
                    {
                        dictionary.Add(word, 1);
                    }
                }

            }


        }
        private static DetectLanguageService languageService = new DetectLanguageService();
        public static void AddWords(this List<SingleWord> words,List<string> parsedText)
        {

            foreach(string word in parsedText)
            {
                if (words.Any(x => x.Word == word))
                {
                    words.FirstOrDefault(x => x.Word == word).Frequency++;
                }
                else
                {
                    if (word.Length > 3)
                    {
                        words.Add(new SingleWord
                        {
                            Frequency = 1,
                            Word = word,
                            Language = languageService.GetLanguage(word)
                        });
                    }
                }
            }
        }
    }
}

