using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MijnFilms_RondelezLaura.Entities
{
    public class Movie
    {
        [Required]
        public int MovieID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int GenreID { get; set; }
        [Required]
        public int DirectorID { get; set; }
        [Required]
        public int Stars { get; set; }
        public string Description { get; set; }
    }
}
