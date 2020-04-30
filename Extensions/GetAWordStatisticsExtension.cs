using StatisticCollector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StatisticCollector.Services;

namespace StatisticCollector.Extensions
{
    public static class GetAWordStatisticsExtension
    {
        public static float Ratio(this ApplicationContext context, string word)
        {
            string _word = word;
            if (_word == null)
            {
                throw new Exception("Nothing to search (Ratio method)");
            }
            else
            {
                var wordToCount = context.Words.FirstOrDefault(x => x.Word == _word);
                if (wordToCount == null)
                {
                    return 0;
                }
                else
                {
                    IQueryable<SingleWord> wordsInDb = context.Words.Where(x => x.Language == wordToCount.Language);
                    return wordsInDb.WordsToDictionary(wordToCount.Language).Dictionary.GetRatio(wordToCount.Word);
                }
            }


        }
        public static string FrequencyInCompare(this ApplicationContext context, string word)
        {
            if (word == null)
            {
                throw new Exception("Nothing to search (FrequencyInCompare method)");
            }
            else
            {
                var wordToCount = context.Words.FirstOrDefault(x => x.Word == word);
                if (wordToCount == null)
                {
                    return "This word isn't in dictionary now.";
                }
                else
                {
                    IQueryable<SingleWord> wordsInDb = context.Words.Where(x => x.Language == wordToCount.Language);
                    return wordsInDb.WordsToDictionary(wordToCount.Language)
                        .Dictionary.GetFrequencyInCompare(wordToCount.Word);
                }

            }
        }

    }
}
