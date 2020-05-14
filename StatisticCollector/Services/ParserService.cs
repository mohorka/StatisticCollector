using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatisticCollector.Services
{
    public static class ParserService
    {
        private static bool TextExist(string text) => text != null;

        public static List<string> Parse(string text)
        {
            if (TextExist(text))
            {
                List<string> parcedText = new List<string>();
                parcedText = text.ToLower().Split(new[] { ' ','-', ',', ':', '?', '!', '.', ';','1',
                '2','3','4','5','6','7','8','9','0'}, StringSplitOptions.RemoveEmptyEntries).ToList();
                return parcedText;
            }
            else throw new Exception("No text to parse!");
        }


    }
}
