using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatisticCollector.Models
{
    public class SingleWord
    {
        public int Id { get; set; }
        public string Word { get; set; }
        public string Language { get; set; }
        public uint Frequency { get; set; }

    }
}
