using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlossaryApp.Models
{
    public class Glossary
    {
        
        public int ID { get; set; }

        [StringLength(30, MinimumLength = 2)]
        [Required]
        public string Term { get; set; }

        [StringLength(120, MinimumLength = 2)]
        [Required]
        public string Definition { get; set; }
    }
}
