using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StatisticCollector.Extensions;
using StatisticCollector.Models;
using StatisticCollector.Services;

namespace StatisticCollector.Pages.UserDictionaries
{
    public class CreateModel : PageModel
    {
        private ApplicationContext _context;
      
        private List<string> newWords { get; set; }
        private List<string> languages { get; set; }
        private List<SingleWord> wordsToAdd = new List<SingleWord>();
        private IQueryable<SingleWord> wordsInDb { get; set; }
        public DetectLanguageService languageService = new DetectLanguageService();

        [BindProperty]
        public string text { get; set; }

        public CreateModel(ApplicationContext db) => _context = db;
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {   
                    newWords = ParserService.Parse(text);
                    wordsToAdd.AddWords(newWords);
                    languages = languageService.GetLanguages(newWords);
                    foreach(string language in languages)
                    {
                        wordsInDb = _context.Words.Where(x => x.Language == language);
                        if (wordsInDb == null)
                        {
                            _context.AddRange(wordsToAdd);
                        }
                        else
                        {
                            foreach(SingleWord word in wordsToAdd)
                            {
                                var wordToUpdate = wordsInDb.FirstOrDefault(x => x.Word == word.Word);
                                if (wordToUpdate != null)
                                {
                                    _context.Words.Find(wordToUpdate.Id).Frequency += word.Frequency;
                                }
                                else
                                    _context.Add(word);
                            }
                      
                        }
                        
                    }


                    await _context.SaveChangesAsync();
                    return RedirectToPage("../Index");

                }
                catch(Exception e) 
                {
                    return NotFound(e.Message);
                }
             
            }
            return Page();
        }
    }
}
