using StatisticCollector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatisticCollector.Repository
{
    public class UserDictionaryRepository
    {
        private ApplicationContext context;
        public UserDictionaryRepository(ApplicationContext db) => context = db;

        public void AddWord(SingleWord word)
        {
            context.Add(word);
            context.SaveChangesAsync();

        }
        public void UpdateWordFrequency(SingleWord word)
        {
            var wordToUpdate = context.Words.FirstOrDefault(x => x.Word == word.Word);
            wordToUpdate.Frequency += word.Frequency;
            context.SaveChangesAsync();

        }
        public SingleWord FindAWord(string word) =>context.Words.FirstOrDefault(x=>x.Word==word);

    }
}
