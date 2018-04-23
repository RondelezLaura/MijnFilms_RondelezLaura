using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MijnFilms_RondelezLaura.Entities
{
    public class MovieActor
    {
        [Required]
        public int MovieID { get; set; }
        [Required]
        public int ActorID { get; set; }
    }
}
