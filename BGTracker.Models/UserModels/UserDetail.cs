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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public int Diagnosed { get; set; }
        public bool TypeOne { get; set; }
        public bool TypeTwo { get; set; }
    }
}
