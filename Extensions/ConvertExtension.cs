using StatisticCollector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatisticCollector.Extensions
{
    public static class ConvertExtension
    {
        public static List<SingleWord> DictionaryToSingleWords(this UserDictionary dictionary)
        {
            var WordsInDictionary = dictionary.Dictionary.Keys;
            List<SingleWord> SingleWords = new List<SingleWord>();
            foreach (string word in WordsInDictionary)
            {
                SingleWords.Add(new SingleWord
                {
                    Word = word,
                    Frequency = dictionary.Dictionary[word],
                    Language = dictionary.Language
                });
            }
            return SingleWords;

        }
        public static UserDictionary WordsToDictionary(this IQueryable<SingleWord> words, string language)
        {
            UserDictionary userDictionary = new UserDictionary { Language = language };
            words.Where(x => x.Language == language)
                .ToList()
                .ForEach(x => userDictionary.Dictionary.Add(x.Word, x.Frequency));
            return userDictionary;

        }

    }
}
