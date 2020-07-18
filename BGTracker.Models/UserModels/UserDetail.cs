using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGTracker.Models.UserModels
{
    public class UserDetail
    {
        public string Id { get; set; }

        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        [Display(Name ="Date of Birth")]
        public DateTime BirthDate { get; set; }
        [Display(Name ="Diagnosed since (year):")]
        public int Diagnosed { get; set; }
        [Display(Name ="Type 1")]
        public bool TypeOne { get; set; }
        [Display(Name ="Type 2")]
        public bool TypeTwo { get; set; }
    }
}
