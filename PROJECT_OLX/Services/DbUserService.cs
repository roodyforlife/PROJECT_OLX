using PROJECT_OLX.Interfaces;
using PROJECT_OLX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT_OLX.Services
{
    public class DbUserService : IDbUserService
    {
        private readonly ApplicationContext db;
        public DbUserService(ApplicationContext db)
        {
            this.db = db;
        }
        public void Add(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void BlockOrUnblock(User user)
        {
            Del(user);
            user.IsBanned = !(user.IsBanned);
            Add(user);
        }

        public void Del(User user)
        {
            db.Users.Remove(user);
            db.SaveChanges();
        }
        public User Get(string user)
        {
            return db.Users.FirstOrDefault(x => x.Login == user);
        }

        public List<User> GetAll()
        {
            return db.Users.ToList();
        }

        public void MakeAdmin(string userId)
        {
            var user = Get(userId);
            Del(user);
            user.IsAdmin = !user.IsAdmin;
            Add(user);
        }
    }
}
