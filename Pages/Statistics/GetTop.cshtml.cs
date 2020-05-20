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
    public class GetTopModel : PageModel
    {
        private readonly ApplicationContext _context;
        public List<string> top { get; set; }
        public GetTopModel(ApplicationContext context) => _context = context;
        public PartialViewResult OnGetTopPartial(string language)
        {
            try
            {
                top = _context.GetTop(language.ToLower());
                return new PartialViewResult
                {
                    ViewName="_Top",
                    ViewData= new ViewDataDictionary<List<string>>(ViewData, top)
                };

            }
            catch(Exception e)
            {
                return new PartialViewResult
                {
                    ViewName = "_Top",
                    ViewData = new ViewDataDictionary<List<string>>(ViewData, new List<string>(new[] { e.Message }))
                };
            }
        }
    }
        
}
