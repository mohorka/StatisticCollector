using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StatisticCollector.Models
{
    public class SingleWord
    {
        public int Id { get; set; }
        [Required]
        public string Word { get; set; }
        [Required]
        public string Language { get; set; }
        public uint Frequency { get; set; }

    }
}
