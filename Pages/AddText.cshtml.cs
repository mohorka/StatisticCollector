using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StatisticCollector.Services;

namespace StatisticCollector.Pages
{
    public class AddTextModel : PageModel
    {
        public string inputText { get; set; }
        public List<string> outputText { get; set; }
        public string language { get; set; }
        public string message { get; set; }
        public void OnGet()
        {
            message = "¬ведите текст, который хотите добавить.";
        }
        public void OnPost(string text)
        {
            try
            {
                outputText=ParserService.Parse(text);
                language = DefineLanguageService.GetLanguage(outputText);
                message = $"This is {language}.";
            }
            catch
            {
                message="Problems with parser's work";
            }


        }
    }
}
