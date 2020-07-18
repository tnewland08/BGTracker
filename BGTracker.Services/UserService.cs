using BGTracker.Data;
using BGTracker.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGTracker.Services
{
    public class UserService
    {
        private readonly Guid _userId;

        public UserService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<UserListItem> GetUser()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Users
                        .Where(a => a.OwnerId == _userId)
                        .Select(
                            a =>
                                new UserListItem
                                {
                                    Id = a.Id,
                                    FirstName = a.FirstName,
                                    LastName = a.LastName,
                                    TypeOne = a.TypeOne,
                                    TypeTwo = a.TypeTwo
                                }
                        );

                return query.ToArray();
            }
        }

        public UserDetail GetUserById(string id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var user =
                    ctx
                        .Users
                        .Single(a => a.Id == id && a.OwnerId == _userId);
                return
                    new UserDetail
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        BirthDate = user.BirthDate,
                        Diagnosed = user.Diagnosed,
                        TypeOne = user.TypeOne,
                        TypeTwo = user.TypeTwo
                    };
            }
        }

        public bool UpdateUser(UserEdit user)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Users
                        .Single(a => a.Id == user.Id && a.OwnerId == _userId);

                entity.Id = user.Id;
                entity.FirstName = user.FirstName;
                entity.LastName = user.LastName;
                entity.BirthDate = user.BirthDate;
                entity.Diagnosed = user.Diagnosed;
                entity.TypeOne = user.TypeOne;
                entity.TypeTwo = user.TypeTwo;
                entity.ModifiedUtc = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteUser(string userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var user =
                    ctx
                        .Users
                        .Single(u => u.Id == userId && u.OwnerId == _userId);

                ctx.Users.Remove(user);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
