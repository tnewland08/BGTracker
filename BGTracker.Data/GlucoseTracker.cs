﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGTracker.Data
{
    public class GlucoseTracker
    {
        [ForeignKey(nameof(ApplicationUser))]
        public string Id { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        [Key]
        public int TrackerId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        [Display(Name ="Date (MM/DD/YYYY)")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name ="Blood Glucose")]
        public int BloodGlucose { get; set; }

        [Required]
        [Display(Name ="Correction Dose (units)")]
        public decimal CorrectionDose { get; set; }

        [Required]
        [Display(Name ="Total Carbs")]
        public int TotalCarbs { get; set; }

        [Required]
        [Display(Name ="Food Dose (units)")]
        public decimal FoodDose { get; set; }

        [Required]
        [Display(Name ="Insulin Dose (total units)")]
        public decimal InsulinDose { get; set; }

        [Required]
        [Display(Name ="Time")]
        [DataType(DataType.Time)]
        public DateTimeOffset TimeOfDose { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
