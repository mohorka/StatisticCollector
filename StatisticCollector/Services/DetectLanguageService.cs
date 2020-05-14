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
        private string detectedWord { get; set; }
        private List<string> words = new List<string>();
        public DetectLanguageService()
        {
            detector = new LanguageDetector();
            detector.AddAllLanguages();
        }
        public string GetLanguage(string word)
        {
            detectedWord = detector.Detect(word);
            if (detectedWord == "en")
            {
                return "english";
            }
            if (detectedWord == "ru")
            {
                return "russian";
            }
            if (detectedWord == "fr")
            {
                return "french";
            }
            if (detectedWord == "pt")
            {
                return "portuguese";
            }
            if (detectedWord == "es")
            {
                return "spanish";
            }
            if (detectedWord == "af")
            {
                return "afrikaans";
            }
            if (detectedWord == "ar")
            {
                return "arabic";
            }
            if (detectedWord == "bg")
            {
                return "bulgarian";
            }
            if (detectedWord == "bn")
            {
                return "bengali";
            }
            if (detectedWord == "cs")
            {
                return "czech";           
            }
            if (detectedWord == "da")
            {
                return "danish";
            }
            if (detectedWord == "de")
            {
                return "german";
            }
            if (detectedWord == "el")
            {
                return "modern greek";
            }
            if (detectedWord == "et")
            {
                return "estonian";
            }
            if (detectedWord == "fa")
            {
                return "persian";
            }
            if (detectedWord == "fi")
            {
                return "finnish";
            }
            if (detectedWord == "gu")
            {
                return "gujarati";
            }
            if (detectedWord == "he")
            {
                return "hebrew";
            }
            if (detectedWord == "hi")
            {
                return "hindi";
            }
            if (detectedWord == "hr")
            {
                return "croatian";
            }
            if (detectedWord == "hu")
            {
                return "hungarian";
            }
            if (detectedWord == "id")
            {
                return "indonesian";
            }
            if (detectedWord == "it")
            {
                return "italian";
            }
            if (detectedWord == "ja")
            {
                return "japanese";
            }
            if (detectedWord == "kn")
            {
                return "kannada";
            }
            if (detectedWord == "ko")
            {
                return "korean";
            }
            if (detectedWord == "lt")
            {
                return "lithuanian";
            }
            if (detectedWord == "lv")
            {
                return "latvian";
            }
            if (detectedWord == "mk")
            {
                return "macedonian";
            }
            if (detectedWord == "mr")
            {
                return "marathi";
            }
            if (detectedWord == "ne")
            {
                return "nepali";
            }
            if (detectedWord == "nl")
            {
                return "dutch";
            }
            if (detectedWord == "no")
            {
                return "norwegian";
            }
            if (detectedWord == "pa")
            {
                return "punjabi";
            }
            if (detectedWord == "pl")
            {
                return "polish";
            }
            if (detectedWord == "ro")
            {
                return "romanian";
            }
            if (detectedWord == "sk")
            {
                return "slovak";
            }
            if (detectedWord == "sl")
            {
                return "slovene";
            }
            if (detectedWord == "so")
            {
                return "somali";
            }
            if (detectedWord == "sq")
            {
                return "albanian";
            }
            if (detectedWord == "sv")
            {
                return "swedish";
            }
            if (detectedWord == "sw")
            {
                return "swahili";
            }
            if (detectedWord == "ta")
            {
                return "tamil";
            }
            if (detectedWord == "te")
            {
                return "telugu";
            }
            if (detectedWord == "th")
            {
                return "thai";
            }
            if (detectedWord == "tl")
            {
                return "tagalog";
            }
            if (detectedWord == "tr")
            {
                return "turkish";
            }
            if (detectedWord == "uk")
            {
                return "ukrainian";
            }
            if (detectedWord == "ur")
            {
                return "urdu";
            }
            if (detectedWord == "vi")
            {
                return "vietnamese";
            }
            if (detectedWord == "zh-cn")
            {
                return "simplified chinise";
            }
            if (detectedWord == "zh-tw")
            {
                return "taiwanese chinise";
            }
            else throw new Exception("Oops, looks like you use language which out of list pf supported ones.");
        }

        public List<string> GetLanguages(List<string> words)
        {
            List<string> detectedWords = new List<string>();
            string langOfWord;
            foreach(string word in words)
            {
                langOfWord = GetLanguage(word);
                if (!detectedWords.Contains(langOfWord))
                {
                    detectedWords.Add(langOfWord);
                }
            }
            return detectedWords;
        }

        
    }
}
