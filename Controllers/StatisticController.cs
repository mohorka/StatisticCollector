using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StatisticCollector.Models;
using StatisticCollector.Extensions;

namespace StatisticCollector.Controllers
{
    
    [ApiController]
    [Route("[Controller]")]
    public class StatisticController:ControllerBase
    {
        private readonly ApplicationContext _context;

        public StatisticController(ApplicationContext context) => _context = context;

        [HttpGet]
        [Route("get/{word}")]
        public string GetStatistics(string word)
        {
            try
            {
                return $"{_context.FrequencyInCompare(word)}.The ratio is {_context.Ratio(word)}.";

            }
            catch(Exception e)
            {
                return e.Message;
            }
        }
    }
}