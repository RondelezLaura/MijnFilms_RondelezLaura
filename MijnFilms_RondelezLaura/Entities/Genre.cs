using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MijnFilms_RondelezLaura.Entities
{
    public class Genre
    {
        [Required]
        public int GenreID { get; set; }
        public string Description { get; set; }
    }
}
