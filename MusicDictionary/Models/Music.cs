using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicDictionary.Models
{
    public class Music
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string SubGenre { get; set; }
        [Required]
        public string Country { get; set; }
        public string City { get; set; }
    }
}
