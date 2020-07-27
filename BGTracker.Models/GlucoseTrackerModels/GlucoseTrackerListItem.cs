using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGTracker.Models.GlucoseTrackerModels
{
    public class GlucoseTrackerListItem
    {
        public int TrackerId { get; set; }

        [Display(Name = "Date (MM/DD/YYYY)")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Blood Glucose")]
        public int BloodGlucose { get; set; }

        [Display(Name = "Insulin Dose (total units)")]
        public decimal InsulinDose { get; set; }

        [Display(Name = "Time")]
        [DataType(DataType.Time)]
        public TimeSpan TimeOfDose { get; set; }

    }
}
