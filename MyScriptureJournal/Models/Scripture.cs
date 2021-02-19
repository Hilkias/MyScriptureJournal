using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyScriptureJournal.Models
{
    public class Scripture
    {
        public int ScriptureId { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Book { get; set; }

        [Required]
        public string Chapter { get; set; }

        [Required]
        public string Verse { get; set; }

        public string Note { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
