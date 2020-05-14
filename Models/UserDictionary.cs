using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatisticCollector.Models
{
    public class UserDictionary
    {
        public string Language { get; set; }
        public Dictionary<string,uint> Dictionary { get; set; }
    }
}
