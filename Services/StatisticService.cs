using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatisticCollector.Services
{
    public static class StatisticService
    {
        public static float GetRatio(this Dictionary<string,uint> dictionary,string word)
        {
            if (dictionary == null)
            {
                throw new Exception("You're trying to look up (GetRatio method) in empty dictionary");
            }
            else
            {
                if (word == null)
                {
                    throw new Exception("No word to search (GetRatio method)");
                }
                else
                {
                    uint sum=0;
                   foreach(uint frequency in dictionary.Values)
                    {
                        sum += frequency;
                    }
                    return (float)dictionary[word] / (float)sum;
                }

            }

                

        }
        public static string GetFrequencyInCompare(this Dictionary<string,uint>dictionary,string word)
        {
            if (dictionary == null)
            {
                throw new Exception("You're trying to look up (GetFrequencyInCompare method) in empty dictionary");
            }
            else
            {
                if (word == null)
                {
                    throw new Exception("No word to search (GetFrequencyInCompare method)");
                }
                else
                {
                    uint sum = 0;
                    foreach (uint frequency in dictionary.Values)
                    {
                        sum += frequency;
                    }
                    return "The frequency is " + dictionary[word].ToString() + " out of " + sum.ToString();
                }

            }


        }
    }
}
