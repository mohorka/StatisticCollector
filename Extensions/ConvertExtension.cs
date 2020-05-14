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
            var wordsInDictionary = dictionary.Dictionary.Keys;
            List<SingleWord> singleWords = new List<SingleWord>();
            foreach (string word in wordsInDictionary)
            {
                singleWords.Add(new SingleWord
                {
                    Word = word,
                    Frequency = dictionary.Dictionary[word],
                    Language = dictionary.Language
                });
            }
            return singleWords;

        }
        public static List<SingleWord> DictionaryToSingleWords(this Dictionary<string,uint> dictionary,string language)
        {
            var wordsInDictionary = dictionary.Keys;
            List<SingleWord> singleWords = new List<SingleWord>();
            foreach(string word in wordsInDictionary)
            {
                singleWords.Add(new SingleWord
                {
                    Word = word,
                    Frequency=dictionary[word],
                    Language=language
                });
            }
            return singleWords;

        }
        public static UserDictionary WordsToDictionary(this IQueryable<SingleWord> words, string language)
        {
            UserDictionary userDictionary = new UserDictionary { Dictionary = new Dictionary<string, uint>(), Language = language };
            words.Where(x => x.Language == language)
                .ToList()
                .ForEach(x => userDictionary.Dictionary.Add(x.Word, x.Frequency));

            /*List<SingleWord> some_words = words.Where(x => x.Language == language).ToList();
            foreach (SingleWord word in some_words )
            {
               
                userDictionary.Dictionary.Add(word.Word, word.Frequency); // troubles with adding- throw nullptr exception
               

            }*/
            return userDictionary;

        }
        

    }
}
