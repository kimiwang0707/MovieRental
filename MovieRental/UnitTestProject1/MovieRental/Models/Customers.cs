using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieRental.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Movies = new HashSet<Movies>();
        }

        public int Cid { get; set; }

        [Required, MinLength(2), MaxLength(50)]
        [RegularExpression("^([a-zA-Z]{2,}\\s[a-zA-Z]{1,}'?-?[a-zA-Z]{2,}\\s?([a-zA-Z]{1,})?)",
         ErrorMessage = "Valid Name include first name and last name seperated by space")]
        public string Name { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, RegularExpression("^[0-9]*$",
         ErrorMessage = "Please enter valid phone number.")]
        public string Phone { get; set; }

        public ICollection<Movies> Movies { get; set; }
    }
}
