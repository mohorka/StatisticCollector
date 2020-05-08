using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanguageDetection;

namespace StatisticCollector.Services
{
    public class DetectLanguageService
    {
        LanguageDetector detector;
        public DetectLanguageService()
        {
            detector = new LanguageDetector();
            detector.AddAllLanguages();
        }
        public string GetLanguage(string word)
        {
            if (detector.Detect(word) == "en")
            {
                return "english";
            }
            if (detector.Detect(word) == "ru")
            {
                return "russian";
            }
            if (detector.Detect(word) == "fr")
            {
                return "french";
            }
            if (detector.Detect(word) == "pt")
            {
                return "portuguese";
            }
            if (detector.Detect(word) == "es")
            {
                return "spanish";
            }
            else throw new Exception("Language is out of list of supported ones.");
        }
    }
}
