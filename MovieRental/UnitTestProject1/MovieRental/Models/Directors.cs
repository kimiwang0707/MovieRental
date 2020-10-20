using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieRental.Models
{
    public partial class Directors
    {
        public Directors()
        {
            Movies = new HashSet<Movies>();
        }

        public int Did { get; set; }

        [Required, MinLength(3), MaxLength(50)]
        [RegularExpression("^([a-zA-Z]{2,}\\s[a-zA-Z]{1,}'?-?[a-zA-Z]{2,}\\s?([a-zA-Z]{1,})?)",
         ErrorMessage = "Valid Name include first name and last name seperated by space")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter gender")]
        public string Gender { get; set; }

        public ICollection<Movies> Movies { get; set; }
    }
}
