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
        public static List<string> Ratio(this ApplicationContext context, string word)
        {
            if (word == null)
            {
                throw new Exception("Nothing to search (Ratio method)");
            }
            else
            {
                List<string> result = new List<string>();
                var wordsToCount = context.Words.Where(x => x.Word == word);
                if (wordsToCount == null)
                {
                    result.Add("0");
                    return result;
                }
                else
                {
                    List<string> languages = new List<string>();
                    
                    foreach(SingleWord _word in wordsToCount)
                    {
                        if (!languages.Contains(_word.Language))
                            languages.Add(_word.Language);
                    }
                    foreach(string language in languages)
                    {
                        
                        IQueryable<SingleWord> wordsInDb = context.Words.Where(x => x.Language == language);
                        string answer = "The ratio is " + wordsInDb.WordsToDictionary(language).Dictionary.GetRatio(word).ToString() + " for " + language;
                        result.Add(answer);

                        
                    }

                    return result;
                }
            }


        }
        public static List<string> FrequencyInCompare(this ApplicationContext context, string word)
        {
            if (word == null)
            {
                throw new Exception("Nothing to search (FrequencyInCompare method)");
            }
            else
            {
                List<string> result = new List<string>();
                var wordsToCount = context.Words.Where(x => x.Word == word);
                if (wordsToCount == null)
                {
                    result.Add("This word isn't in dictionary now.");
                    return result;
                }
                else
                {
                    List<string> languages = new List<string>();
                    foreach (SingleWord _word in wordsToCount)
                    {
                        if (!languages.Contains(_word.Language))
                            languages.Add(_word.Language);
                    }
                    foreach (string language in languages)
                    {
                        IQueryable<SingleWord> wordsInDb = context.Words.Where(x => x.Language == language);
                        string answer = wordsInDb.WordsToDictionary(language).Dictionary.GetFrequencyInCompare(word) + "for "+ language;
                        result.Add(answer);
                    }

                    return result;
                }

            }
        }

    }
}
