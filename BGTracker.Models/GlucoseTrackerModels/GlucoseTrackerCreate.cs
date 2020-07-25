using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGTracker.Models.GlucoseTrackerModels
{
    public class GlucoseTrackerCreate
    {
        [Required]
        [Display(Name = "Date (MM/DD/YYYY)")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Blood Glucose")]
        public int BloodGlucose { get; set; }

        [Required]
        [Display(Name = "Correction Dose (units)")]
        public decimal CorrectionDose { get; set; }

        [Required]
        [Display(Name = "Total Carbs")]
        public int TotalCarbs { get; set; }

        [Required]
        [Display(Name = "Food Dose (units)")]
        public decimal FoodDose { get; set; }

        [Required]
        [Display(Name = "Insulin Dose (total units)")]
        public decimal InsulinDose { get; set; }

        [Required]
        [Display(Name = "Time")]
        public TimeSpan TimeOfDose { get; set; }
    }
}
