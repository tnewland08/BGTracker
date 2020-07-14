using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGTracker.Models.FoodAndDrinkModels
{
    public class FoodAndDrinkCreate
    {
        [Required]
        public string Item { get; set; }

        [Required]
        [Display(Name = "Food")]
        public bool IsFood { get; set; }

        [Required]
        [Display(Name = "Drink")]
        public bool IsDrink { get; set; }

        [Required]
        [Display(Name = "Carbs per Serving")]
        public int CarbsPerServing { get; set; }

        [Required]
        [Display(Name ="Serving Size")]
        public string ServingSize { get; set; }

        [Required]
        [Display(Name = "Fast Acting Carb")]
        public bool FastActingCarb { get; set; }

        [Required]
        public bool Favorite { get; set; }
    }
}
