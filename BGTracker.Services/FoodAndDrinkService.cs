using BGTracker.Data;
using BGTracker.Models.FoodAndDrinkModels;
using BGTracker.Models.GlucoseTrackerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BGTracker.Services
{
    public class FoodAndDrinkService
    {
        private readonly Guid _userid;

        public FoodAndDrinkService(Guid userId)
        {
            _userid = userId;
        }

        public bool CreateFoodAndDrinkItem(FoodAndDrinkCreate item)
        {
            var newItem =
                new FoodAndDrink()
                {
                    Id = _userid.ToString(),
                    OwnerId = _userid,
                    Item = item.Item,
                    IsFood = item.IsFood,
                    IsDrink = item.IsDrink,
                    CarbsPerServing = item.CarbsPerServing,
                    ServingSize = item.ServingSize,
                    FastActingCarb = item.FastActingCarb,
                    Favorite = item.Favorite,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.FoodAndDrinks.Add(newItem);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<FoodAndDrinkListItem> GetFoodAndDrinkList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .FoodAndDrinks
                        .Where(f => f.OwnerId == _userid)
                        .Select(
                            f =>
                                new FoodAndDrinkListItem
                                {
                                    ItemId = f.ItemId,
                                    Item = f.Item,
                                    CarbsPerServing = f.CarbsPerServing,
                                    ServingSize = f.ServingSize,
                                    Favorite = f.Favorite
                                }
                        );

                return query.ToArray();
            }
        }

        public FoodAndDrinkDetail GetFoodAndDrinkById(int itemId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var food =
                    ctx
                        .FoodAndDrinks
                        .Single(f => f.ItemId == itemId && f.OwnerId == _userid);
                return
                    new FoodAndDrinkDetail
                    {
                        ItemId = food.ItemId,
                        Item = food.Item,
                        IsFood = food.IsFood,
                        IsDrink = food.IsDrink,
                        CarbsPerServing = food.CarbsPerServing,
                        ServingSize = food.ServingSize,
                        FastActingCarb = food.FastActingCarb,
                        Favorite = food.Favorite,
                        CreatedUtc = food.CreatedUtc,
                        ModifiedUtc = food.ModifiedUtc
                    };
            }
        }

        public bool UpdateFoodAndDrinkItem(FoodAndDrinkEdit item)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .FoodAndDrinks
                        .Single(f => f.ItemId == item.ItemId && f.OwnerId == _userid);

                entity.ItemId = item.ItemId;
                entity.Item = item.Item;
                entity.IsFood = item.IsFood;
                entity.IsDrink = item.IsDrink;
                entity.CarbsPerServing = item.CarbsPerServing;
                entity.ServingSize = item.ServingSize;
                entity.FastActingCarb = item.FastActingCarb;
                entity.Favorite = item.Favorite;
                entity.ModifiedUtc = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteFoodAndDrinkItem(int itemId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var food =
                    ctx
                        .FoodAndDrinks
                        .Single(f => f.ItemId == itemId && f.OwnerId == _userid);

                ctx.FoodAndDrinks.Remove(food);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
