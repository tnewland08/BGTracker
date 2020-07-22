using BGTracker.Data;
using BGTracker.Models.GlucoseTrackerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGTracker.Services
{
    public class GlucoseTrackerService
    {
        private readonly Guid _userid;

        public GlucoseTrackerService(Guid userId)
        {
            _userid = userId;
        }

        public bool CreateGlucoseTracker(GlucoseTrackerCreate glucose)
        {
            var newGlucose =
                new GlucoseTracker()
                {
                    Id = glucose.Id,
                    OwnerId = _userid,
                    Date = glucose.Date,
                    BloodGlucose = glucose.BloodGlucose,
                    CorrectionDose = glucose.CorrectionDose,
                    TotalCarbs = glucose.TotalCarbs,
                    FoodDose = glucose.FoodDose,
                    InsulinDose = glucose.InsulinDose,
                    TimeOfDose = glucose.TimeOfDose,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Glucose.Add(newGlucose);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GlucoseTrackerListItem> GetGlucoseTracker()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Glucose
                        .Where(g => g.OwnerId == _userid)
                        .Select(
                            g =>
                                new GlucoseTrackerListItem
                                {
                                    TrackerId = g.TrackerId,
                                    Date = g.Date,
                                    BloodGlucose = g.BloodGlucose,
                                    InsulinDose = g.InsulinDose,
                                    TimeOfDose = g.TimeOfDose
                                }
                        );

                return query.ToArray();
            }
        }

        public GlucoseTrackerDetail GetGlucoseTrackerById(int trackerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var glucose =
                    ctx
                        .Glucose
                        .Single(g => g.TrackerId == trackerId && g.OwnerId == _userid);
                return
                    new GlucoseTrackerDetail
                    {
                        TrackerId = glucose.TrackerId,
                        Date = glucose.Date,
                        BloodGlucose = glucose.BloodGlucose,
                        CorrectionDose = glucose.CorrectionDose,
                        TotalCarbs = glucose.TotalCarbs,
                        FoodDose = glucose.FoodDose,
                        InsulinDose = glucose.InsulinDose,
                        TimeOfDose = glucose.TimeOfDose,
                        CreatedUtc = glucose.CreatedUtc,
                        ModifiedUtc = glucose.ModifiedUtc
                    };
            }
        }

        public bool UpdateGlucoseTracker(GlucoseTrackerEdit glucose)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Glucose
                        .Single(g => g.TrackerId == glucose.TrackerId && g.OwnerId == _userid);

                entity.TrackerId = glucose.TrackerId;
                entity.Date = glucose.Date;
                entity.BloodGlucose = glucose.BloodGlucose;
                entity.CorrectionDose = glucose.CorrectionDose;
                entity.TotalCarbs = glucose.TotalCarbs;
                entity.FoodDose = glucose.FoodDose;
                entity.InsulinDose = glucose.InsulinDose;
                entity.TimeOfDose = glucose.TimeOfDose;
                entity.ModifiedUtc = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGlucoseTracker(int trackerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var glucose =
                    ctx
                        .Glucose
                        .Single(g => g.TrackerId == trackerId && g.OwnerId == _userid);

                ctx.Glucose.Remove(glucose);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
