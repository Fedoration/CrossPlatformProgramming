using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2Laputin.Models
{
    public class Pipe
    {
        public int ID { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal diameter { get; set; }
        public int length { get; set; }
    }
}
