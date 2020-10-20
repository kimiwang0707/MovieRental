using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieRental.Models
{
    public partial class Movies
    {
        public int MovieId { get; set; }
        public int? Cid { get; set; }
        public int DirectorId { get; set; }

        [Required, MinLength(3), MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public int ReleaseYear { get; set; }

        public Customers Borrowers { get; set; }
        public Directors Director { get; set; }
    }
}
