using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGTracker.Data
{
    public class FoodAndDrink
    {
        [ForeignKey(nameof(User))]
        public string Id { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Key]
        public int FoodId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Item { get; set; }

        [Required]
        [Display(Name ="Food")]
        public bool IsFood { get; set; }

        [Required]
        [Display(Name ="Drink")]
        public bool IsDrink { get; set; }

        [Required]
        [Display(Name ="Carbs per Serving")]
        public int CarbsPerServing { get; set; }

        [Required]
        [Display(Name ="Serving Size")]
        public string ServingSize { get; set; }

        [Required]
        [Display(Name ="Fast Acting Carb")]
        public bool FastActingCarb { get; set; }

        [Required]
        public bool Favorite { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
