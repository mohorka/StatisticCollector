using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StatisticCollector.Models;
using StatisticCollector.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace StatisticCollector.Pages.Statistics
{
    public class GetStatisticsModel : PageModel
    {
        private readonly ApplicationContext _context;
        public List<string> statistics { get; set; }
        public GetStatisticsModel(ApplicationContext context) => _context = context;
        public PartialViewResult OnGetResultPartial(string word) { 
            
            try
            {

                //statistics = _context.FrequencyInCompare(word.ToLower());
                //statistics.AddRange(_context.Ratio(word.ToLower()));
                statistics = _context.Ratio(word.ToLower());
                return new PartialViewResult
                {
                    ViewName = "_Statistics",
                    ViewData= new ViewDataDictionary<List<string>>(ViewData, statistics)

                };
               
                
            }
            catch(Exception e)
            {
                return new PartialViewResult
                {
                    ViewName = "_Statistics",
                    ViewData = new ViewDataDictionary<List<string>>(ViewData, new List<string>(new[] { e.Message }))
                };
                
            }
            
        }
    }
}
