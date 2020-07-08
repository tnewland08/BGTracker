using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGTracker.Models.GlucoseTrackerModels
{
    public class GlucoseTrackerEdit
    {
        public int TrackerId { get; set; }

        [Display(Name = "Date (MM/DD/YYYY)")]
        public DateTime Date { get; set; }

        [Display(Name = "Blood Glucose")]
        public int BloodGlucose { get; set; }

        [Display(Name = "Correction Dose (units)")]
        public decimal CorrectionDose { get; set; }

        [Display(Name = "Total Carbs")]
        public int TotalCarbs { get; set; }

        [Display(Name = "Food Dose (units)")]
        public decimal FoodDose { get; set; }

        [Display(Name = "Insulin Dose (total units)")]
        public decimal InsulinDose { get; set; }

        [Display(Name = "Time")]
        public TimeSpan TimeOfDose { get; set; }
    }
}
