﻿using BGTracker.Data;
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

        public bool CreateUser(UserCreate user)
        {
            var newUser =
                new User()
                {
                    OwnerId = _userId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Birthday = user.Birthday,
                    Diagnosed = user.Diagnosed,
                    TypeOne = user.TypeOne,
                    TypeTwo = user.TypeTwo,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Users.Add(newUser);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<UserListItem> GetUser()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Users
                        .Where(u => u.OwnerId == _userId)
                        .Select(
                            u =>
                                new UserListItem
                                {
                                    UserId = u.UserId,
                                    FirstName = u.FirstName,
                                    LastName = u.LastName,
                                    TypeOne = u.TypeOne,
                                    TypeTwo = u.TypeTwo
                                }
                        );

                return query.ToArray();
            }
        }

        public UserDetail GetUserById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var user =
                    ctx
                        .Users
                        .Single(u => u.UserId == id && u.OwnerId == _userId);
                return
                    new UserDetail
                    {
                        UserId = user.UserId,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Birthday = user.Birthday,
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
                        .Single(u => u.UserId == user.UserId && u.OwnerId == _userId);

                entity.UserId = user.UserId;
                entity.FirstName = user.FirstName;
                entity.LastName = user.LastName;
                entity.Birthday = user.Birthday;
                entity.Diagnosed = user.Diagnosed;
                entity.TypeOne = user.TypeOne;
                entity.TypeTwo = user.TypeTwo;
                entity.ModifiedUtc = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteUser(int userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var user =
                    ctx
                        .Users
                        .Single(u => u.UserId == userId && u.OwnerId == _userId);

                ctx.Users.Remove(user);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}