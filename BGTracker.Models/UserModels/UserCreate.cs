using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGTracker.Models.UserModels
{
    public class UserCreate
    {
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Date of Birth (MM/DD/YYY)")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Display(Name = "Diagnosed since (year)")]
        public int Diagnosed { get; set; }

        [Required]
        [Display(Name = "Type 1")]
        public bool TypeOne { get; set; }

        [Required]
        [Display(Name = "Type 2")]
        public bool TypeTwo { get; set; }
    }
}
