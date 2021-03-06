﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGTracker.Models.FoodAndDrinkModels
{
    public class FoodAndDrinkListItem
    {
        public int ItemId { get; set; }
        public string Item { get; set; }

        [Display(Name = "Carbs per Serving")]
        public int CarbsPerServing { get; set; }

        [Display(Name ="Serving Size")]
        public string ServingSize { get; set; }

        public bool Favorite { get; set; }
    }
}
