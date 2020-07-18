using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGTracker.Models.UserModels
{
    public class UserEdit
    {
        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public int Diagnosed { get; set; }

        [Required]
        public bool TypeOne { get; set; }

        [Required]
        public bool TypeTwo { get; set; }
    }
}
