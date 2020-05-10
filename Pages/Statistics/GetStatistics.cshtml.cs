using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StatisticCollector.Models;
using StatisticCollector.Extensions;

namespace StatisticCollector.Pages.Statistics
{
    public class GetStatisticsModel : PageModel
    {
        private readonly ApplicationContext _context;
     
        public GetStatisticsModel(ApplicationContext context) => _context = context;
        public JsonResult OnGetResult(string word) { 
            
            try
            {
                
                return new JsonResult(_context.Ratio(word));
                
            }
            catch(Exception e)
            {
                return new JsonResult(e.Message);
            }
            
        }
    }
}
