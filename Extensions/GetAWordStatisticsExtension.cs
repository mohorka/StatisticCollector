using StatisticCollector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StatisticCollector.Services;
using Microsoft.EntityFrameworkCore;

namespace StatisticCollector.Extensions
{
    public static class GetAWordStatisticsExtension
    {
        public static List<string> Ratio(this ApplicationContext context, string word)
        {
            if (word == null)
            {
                throw new Exception("Nothing to count, please make sure you have entered a word.");
            }
            else
            {
               
                var wordsToCount = context.Words.AsNoTracking().Where(x => x.Word == word).ToList();
                if (wordsToCount == null)
                {
                    throw new Exception("This word is not in dictionaries for now.");
                }
                else
                {
                    if (wordsToCount.Count == 0)
                    {
                        throw new Exception("This word is not in dictionaries for now.");
                    }
                    else
                    {
                        List<string> result = new List<string>();
                        List<string> languages = new List<string>();
                        foreach (SingleWord _word in wordsToCount)
                        {
                            languages.Add(_word.Language);
                        }
                        foreach (string language in languages)
                        {
                            IQueryable<SingleWord> wordsInDb = context.Words.AsNoTracking().Where(x => x.Language == language);
                            string answer = "The ratio is " + wordsInDb.WordsToDictionary(language)
                                .Dictionary.GetRatio(word).ToString() + "  for  " + language;
                            result.Add(answer);

                        }
                        return result;

                    }
                }

            }
            

        }


        
        public static List<string> FrequencyInCompare(this ApplicationContext context, string word)
        {
            if (word == null)
            {
                throw new Exception("Nothing to count, please make sure you have entered a word.");
            }
            else
            {
                var wordsToCount = context.Words.AsNoTracking().Where(x => x.Word == word).ToList();
                if (wordsToCount == null)
                {
                    throw new Exception("This word is not in dictionaries for now.");
                }
                else
                {
                    if (wordsToCount.Count == 0)
                    {
                        throw new Exception("This word is not in dictionaries for now.");
                    }
                    else
                    {
                        List<string> result = new List<string>();
                        List<string> languages = new List<string>();
                        foreach (SingleWord _word in wordsToCount)
                        {
                            languages.Add(_word.Language);
                        }
                        foreach(string language in languages)
                        {
                            IQueryable<SingleWord> wordsInDb = context.Words.AsNoTracking().Where(x => x.Language == language);
                            string answer = wordsInDb.WordsToDictionary(language).Dictionary.GetFrequencyInCompare(word) + " for  " + language;
                            result.Add(answer);
                        }
                        return result;

                    }
                }

            }


        }

    }
}
