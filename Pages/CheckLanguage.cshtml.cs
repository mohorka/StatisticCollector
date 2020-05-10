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
        [BindProperty]
        public bool isChecked { get; set; }
        public List<string> outputText { get; set; }
        public List<string> languages = new List<string>();
        public string language { get; set; }
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
                if (isChecked)
                {
                    outputText = ParserService.Parse(inputText);
                    languages = languageService.GetLanguages(outputText);
                    string result = "This text probably contains ";
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
                else
                {
                    language = languageService.GetLanguage(inputText);
                    message= $"This is {language}. Now you can try another text.";
                }
            }
            catch (Exception e)
            {
                message = e.Message;
            }

            
           
            
              
            


        }
    }
}
