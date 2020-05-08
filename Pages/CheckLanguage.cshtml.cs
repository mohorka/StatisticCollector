using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StatisticCollector.Services;

namespace StatisticCollector.Pages
{
    public class CheckLanguageModel : PageModel
    {
        [BindProperty]
        public string inputText { get; set; }
        public List<string> outputText { get; set; }
        public List<string> languages = new List<string>();
        public string message { get; set; }

        public DetectLanguageService languageService = new DetectLanguageService();
        public void OnGet()
        {
            message = "Input text to define language.";
        }
        public void OnPost()
        {
            try
            {
                outputText = ParserService.Parse(inputText);
                string langOfWord;
                foreach (string word in outputText)
                {
                    langOfWord = languageService.GetLanguage(word);
                    if (!languages.Contains(langOfWord))
                    {
                        languages.Add(langOfWord);
                    }
                }
                string result = "This text contains ";
                if (languages.Count > 1)
                {
                    for (int i = 0; i < (languages.Count) - 1; ++i)
                    {
                        result += languages[i];
                        result += ",";
                    }
                }
                result += languages[(languages.Count) - 1];
                result += ". Now you can try another text if you wish.";
                message = result;
            }
            catch
            {
               message="Oops,it looks like your text does not belong to any supported languages.";
            }


        }
    }
}
